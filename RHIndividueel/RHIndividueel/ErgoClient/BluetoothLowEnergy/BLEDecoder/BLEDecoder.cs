using System;

namespace ErgoConnect
{
	/// <summary>
	/// The BLEDecryptor class decrypts specific data. This class is abstract, for a how-to-use example, refer to BLEDecryptor.
	/// </summary>
	public abstract class BLEDecoder
	{
		public const bool printChecksum = false;

		/// <summary>
		/// The Decrypt method should be implemented, so a specific byte[] data can be decoded.
		/// </summary>
		/// <param name="rawData"></param>
		/// <param name="bLEDataHandler"></param>
		public static void Decrypt(byte[] rawData, BLEDataHandler bLEDataHandler) { }

		/// <summary>
		/// Checks whether the checksum is correct or not, to _almsot_ make sure there is no incorrect data received.
		/// </summary>
		/// <param name="data"></param>
		/// <param name="checksum"></param>
		/// <returns></returns>
		public static bool CheckXorValue(byte[] data, byte[] checksum)
		{
			//byte xorValue = 0;
			//for (int i = 0; i < data.Length - 1; i++)
			//    xorValue ^= data[i];
			//if (printChecksum)
			//    Console.WriteLine($"Xorvalue: {xorValue} Checksum: {data[data.Length - 1]}");
			byte xorValue = GetXorValue(data);
			return xorValue == data[data.Length - 1]; // Return the entire data xor value.
		}

		public static byte GetXorValue(byte[] data)
		{
			byte xorValue = 0;
			for (int i = 0; i < data.Length - 1; i++)
			{
				xorValue ^= data[i];
			}

			if (printChecksum)
			{
				Console.WriteLine($"Xorvalue: {xorValue} Checksum: {data[data.Length - 1]}");
			}

			return xorValue;
		}
	}
}