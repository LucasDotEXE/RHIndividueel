using Server;
using System;

namespace ErgoConnect
{
	/// <summary>
	/// BLEDataPage16 class contains specific data which is received by BLE. This is part of a specific protocol. This class contains elapsed time, distance travelled, speed and heart rate.
	/// </summary>
	[Serializable]
	public class BLEDataPage16 : BLEData
	{
		public double ElapsedTime { get; }
		public double DistanceTravelled { get; }
		public double Speed { get; }
		public double HeartRate { get; }

		/// <summary>
		/// Receives data upon constructing, and saves this for later purpose by calling its base class.
		/// </summary>
		/// <param name="data"></param>
		public BLEDataPage16(double[] data) : base(data)
		{
			this.ElapsedTime = data[0];
			this.DistanceTravelled = data[1];
			this.Speed = data[2];
			this.HeartRate = data[3];
		}

		/// <summary>
		/// Implementation of printing data to the console.
		/// </summary>
		public override void PrintData()
		{
			Console.WriteLine($"Elapsed Time: {Math.Round(this.ElapsedTime)} sec\t\t Distance: {this.DistanceTravelled} m\t\t Speed: {Math.Round(this.Speed)} kmph\t\t Heart rate: {this.HeartRate} bpm");
		}

		public override string GetData()
		{
			return $"<{Tag.ET.ToString()}>{this.ElapsedTime}<{Tag.DT.ToString()}>{this.DistanceTravelled}<{Tag.SP.ToString()}>{this.Speed}<{Tag.HR.ToString()}>{this.HeartRate}";
		}
	}
}
