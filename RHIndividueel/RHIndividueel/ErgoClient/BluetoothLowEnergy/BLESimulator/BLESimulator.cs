using Client;
using System.Collections.Generic;
using System.IO;

namespace ErgoConnect
{
	/// <summary>
	/// The WriteOption enumeration defines two options to help identify actions. These are Ergo and Heartrate.
	/// </summary>
	public enum WriteOption
	{
		Ergo, Heartrate
	}

	/// <summary>
	/// BLESimulator replicates data output by using a 1 : 1 copy of a team member cycling on the ergometer.
	/// </summary>
	public class BLESimulator
	{
		private readonly List<byte[]> _bytesErgo = new List<byte[]>();
		private readonly List<byte[]> _bytesHeartRate = new List<byte[]>();
		private readonly string _ergoID;
		private readonly string _patientName;
		private readonly string _patientNumber;
		private readonly IClient _iClient;
		public BLEDataHandler bLEDataHandler;

		/// <summary>
		/// The ergoID is needed to define the save location of the Ergometer data.
		/// </summary>
		/// <param name="ergoID"></param>
		public BLESimulator(string ergoID, IClient iClient, string patientName, string patientNumber)
		{
			this._ergoID = ergoID;
			this._iClient = iClient;
			this._patientName = patientName;
			this._patientNumber = patientNumber;
		}

		/// <summary>
		/// Use only for BLEConnect
		/// </summary>
		/// <param name="ergoID"></param>

		public BLESimulator(string ergoID)
		{
			this._ergoID = ergoID;
		}

		/// <summary>
		/// Run the simulator with a data transfer time of 4Hz, just like the real protocol.
		/// </summary>

		public void RunSimulator()
		{
			this.bLEDataHandler = new BLEDataHandler(this._ergoID, this._patientName, this._patientNumber);
			int i = 0;
			List<byte[]> data = new List<byte[]>();
			while (true)
			{
				data = this.ReadData(ApplicationSettings.GetReadWritePath(this._ergoID), WriteOption.Ergo);
				BLEDecoderErgo.Decrypt(data[i], this.bLEDataHandler);
				string toSend = this.bLEDataHandler.ReadLastData(); // Data that should be send to the client.
				this._iClient.Write(toSend);
				if (i >= data.Count - 1)
				{
					i = 0;
				}

				i++;
				System.Threading.Thread.Sleep(250);
			}
		}

		/// <summary>
		/// Save bytes for record purposes of Ergometer.
		/// </summary>
		/// <param name="data"></param>
		public void SaveBytesErgo(byte[] data)
		{
			this._bytesErgo.Add(data);
		}

		/// <summary>
		/// Save bytes for record purposes of heart rate monitor.
		/// </summary>
		/// <param name="data"></param>
		public void SaveBytesHeartRate(byte[] data)
		{
			this._bytesHeartRate.Add(data);
		}

		/// <summary>
		/// Read data for simulating purposes. Returns a list of byte[] of data.
		/// </summary>
		/// <param name="filePath"></param>
		/// <param name="ergoOrHeartRate"></param>
		/// <returns></returns>
		public List<byte[]> ReadData(string filePath, WriteOption ergoOrHeartRate)
		{
			filePath = GetErgoHeartRatePath(filePath, ergoOrHeartRate);
			List<byte[]> deSerializedObject = ReadToFileBinary<List<byte[]>>(filePath);
			return deSerializedObject;
		}

		/// <summary>
		/// Read in a file and receive a binary desiralization.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="pathToFile"></param>
		/// <returns></returns>
		private static T ReadToFileBinary<T>(string pathToFile)
		{
			try
			{
				using (Stream stream = File.Open(pathToFile, FileMode.Open))
				{
					System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
					return (T)binaryFormatter.Deserialize(stream);
				}
			}
			catch (FileNotFoundException)
			{
				using (File.Create(pathToFile))
				{
					return ReadToFileBinary<T>(pathToFile);
				}
			}
		}

		/// <summary>
		/// Write to file, writeOption is needed to define the path.
		/// </summary>
		/// <param name="writeOption"></param>
		public void WriteData(WriteOption writeOption)
		{
			string pathToFile = GetErgoHeartRatePath(ApplicationSettings.GetReadWritePath(this._ergoID), writeOption);
			List<byte[]> dataToWrite = new List<byte[]>();
			switch (writeOption)
			{
				case WriteOption.Ergo:
					dataToWrite = this._bytesErgo;
					break;
				case WriteOption.Heartrate:
					dataToWrite = this._bytesHeartRate;
					break;

			}
			WriteToFileBinary(pathToFile, dataToWrite);
		}
		/// <summary>
		/// Receive the Ergometer or Heart rate data path.
		/// </summary>
		/// <param name="pathToFile"></param>
		/// <param name="ergoOrHeartRate"></param>
		/// <returns></returns>
		private static string GetErgoHeartRatePath(string pathToFile, WriteOption ergoOrHeartRate)
		{
			string newPath = pathToFile;
			switch (ergoOrHeartRate)
			{
				case WriteOption.Ergo:
					newPath += "_Ergometer";
					break;
				case WriteOption.Heartrate:
					newPath += "_HRMonitor";
					break;
			}
			return newPath;
		}

		/// <summary>
		/// Write binary data to a file (serialize).
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="pathToFile"></param>
		/// <param name="objectToWrite"></param>
		/// <param name="newFile"></param>
		private static void WriteToFileBinary<T>(string pathToFile, T objectToWrite, bool newFile = false)
		{
			using (System.IO.Stream stream = System.IO.File.Open(pathToFile, newFile ? System.IO.FileMode.Create : System.IO.File.Exists(pathToFile) ? System.IO.FileMode.Truncate : System.IO.FileMode.Create))
			{
				System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
				binaryFormatter.Serialize(stream, objectToWrite);
			}

		}
	}
}
