using System.Linq;

namespace ErgoConnect
{
	/// <summary>
	/// Decryptor inheritance for the Ergometer. Decodes a byte[] rawdata.
	/// </summary>
	public class BLEDecoderErgo : BLEDecoder
	{
		/// <summary>
		/// Decodes the data for all data pages. Hence, when you add a DataPage, also add it here!
		/// </summary>
		/// <param name="rawData"></param>
		/// <param name="bLEDataHandler"></param>
		public static void Decrypt(byte[] rawData, BLEDataHandler bLEDataHandler)
		{
			int messageLength = rawData[1];
			byte[] message = rawData.Skip(4).Take(messageLength).ToArray();
			int pageNumber = message[0];
			byte[] checksum = rawData.Skip(4).Skip(messageLength).ToArray();
			bool isCorrect = CheckXorValue(rawData, checksum);

			if (isCorrect)
			{
				if (pageNumber == 16)
				{
					// decode page 16
					double elapsedTime = message[2] * 0.25; //seconds
					int distanceTraveled = message[3]; //metres
					byte speedLSB = message[4];
					byte speedMSB = message[5];
					int heartRate = message[6]; // bpm
					double speed = ((speedMSB << 8) | speedLSB) / 1000.0 * 3.6; //kmph

					double[] data = { elapsedTime, distanceTraveled, speed, heartRate };
					bLEDataHandler.AddBLEDataForDataPage16(data);
				}
				else if (pageNumber == 25)
				{
					// decode page 25
					int updateEventCount = message[1]; //count
					int instanteousCadence = message[2]; //rpm
					byte accumulatedPowerLSB = message[3];
					byte accumulatedPowerMSB = message[4];
					byte instanteousPowerLSB = message[5];
					byte instanteousPowerMSB = message[6];

					int accumulatedPower = (accumulatedPowerMSB << 8) | accumulatedPowerLSB; //watt
					int instanteousPower = (((instanteousPowerMSB | 0b11110000) ^ 0b11110000) << 8) | instanteousPowerLSB; //watt

					double[] data = { updateEventCount, instanteousCadence, accumulatedPower, instanteousPower };
					bLEDataHandler.AddBLEDataForDataPage25(data);
				}
				//bLEDataHandler.printLastData();
			}
		}


	}
}
