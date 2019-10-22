using Server;
using System;

namespace ErgoConnect
{
	/// <summary>
	/// BLEDataPage25 contains specific data which is received by BLE.  This is part of a specific protocol. This class contains update event count, cadence, accumulated power and instanteous power.
	/// </summary>
	[Serializable]
	public class BLEDataPage25 : BLEData
	{
		private double UpdateEventCount { get; }
		private double InstanteousCadence { get; }
		private double AccumulatedPower { get; }
		private double InstanteousPower { get; }
		/// <summary>
		/// Receives data upon constructing, and saves this for later purpose by calling its base class.
		/// </summary>
		/// <param name="data"></param>
		public BLEDataPage25(double[] data) : base(data)
		{
			this.UpdateEventCount = data[0];
			this.InstanteousCadence = data[1];
			this.AccumulatedPower = data[2];
			this.InstanteousPower = data[3];
		}
		/// <summary>
		/// Implementation of printing data to the console.
		/// </summary>
		public override void PrintData()
		{
			Console.WriteLine($"Count: {Math.Round(this.UpdateEventCount)}\t\t Cadence: {this.InstanteousCadence} rpm\t\t Acc power: {Math.Round(this.AccumulatedPower)} Watt\t\t Inst power: {this.InstanteousPower} Watt");
		}

		public override string GetData()
		{
			return $"<{Tag.EC.ToString()}>{this.UpdateEventCount}<{Tag.IC.ToString()}>{this.InstanteousCadence}<{Tag.AP.ToString()}>{this.AccumulatedPower}<{Tag.IP.ToString()}>{this.InstanteousPower}";
		}
	}
}
