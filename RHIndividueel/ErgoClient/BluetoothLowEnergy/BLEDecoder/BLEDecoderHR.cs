namespace ErgoConnect
{
	/// <summary>
	/// Decoder inheritance for 
	/// </summary>
	public class BLEDecoderHR : BLEDecoder
	{
		/// <summary>
		/// Decode data for the heart rate monitor. In this case the only useful value is byte[1], so far the success data transfer rate has been 100%. Therefor the checksum is not used at the moment.
		/// </summary>
		/// <param name="rawData"></param>
		/// <param name="bLEDataHandler"></param>
		public static void Decrypt(byte[] rawData, BLEDataHandler bLEDataHandler)
		{
			;
			//byte[] checksum = { rawData[rawData.Length - 1] };
			//bool isCorrect = CheckXorValue(rawData, checksum);

			int heartRate = rawData[1];
			bLEDataHandler.SetHeartrate(heartRate);
		}

	}
}
