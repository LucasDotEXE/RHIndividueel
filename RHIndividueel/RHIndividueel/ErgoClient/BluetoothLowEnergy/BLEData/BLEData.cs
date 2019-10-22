using System;

namespace ErgoConnect
{
	/// <summary>
	/// Simple abstract class that defines potential BLEData. Can be implemented and expended by data classes.
	/// </summary>
	[Serializable]
	public abstract class BLEData
	{
		private readonly double[] data;

		/// <summary>
		/// Costructor needs data, to define a corresponding action.
		/// </summary>
		/// <param name="data"></param>
		public BLEData(double[] data)
		{
			this.data = data;
		}

		/// <summary>
		/// Abstract implementation the print data in the console. Must be implemented for testing and debug purposes.
		/// </summary>
		public abstract void PrintData();
		public abstract string GetData();
	}
}
