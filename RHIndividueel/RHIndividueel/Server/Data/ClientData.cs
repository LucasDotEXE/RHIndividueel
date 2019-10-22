using Server.Data;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
	public class ClientData
	{
		private readonly List<TimeData> _elapsedTime;
		private readonly List<TimeData> _distanceTravelled;
		private readonly List<TimeData> _speed;
		private readonly List<TimeData> _heartRate;
		private readonly List<TimeData> _eventCount;
		private readonly List<TimeData> _instanteousCadance;
		private readonly List<TimeData> _accumulatedPower;
		private readonly List<TimeData> _instanteousPower;
		private string patientName = string.Empty;
		private string patientNumber = string.Empty;

		public ClientData()
		{
			this._elapsedTime = new List<TimeData>();
			this._distanceTravelled = new List<TimeData>();
			this._speed = new List<TimeData>();
			this._heartRate = new List<TimeData>();
			this._eventCount = new List<TimeData>();
			this._instanteousCadance = new List<TimeData>();
			this._accumulatedPower = new List<TimeData>();
			this._instanteousPower = new List<TimeData>();
		}

		public override string ToString()
		{
			string message = $"<PNA>{this.patientName}<PNU>{this.patientNumber}";
			if (this._elapsedTime.Count > 0)
			{
				message += $"<ET>{this._elapsedTime.Last()}";
			}
			if (this._distanceTravelled.Count > 0)
			{
				message += $"<DT>{this._distanceTravelled.Last()}";
			}
			if (this._speed.Count > 0)
			{
				message += $"<SP>{this._speed.Last()}";
			}
			if (this._heartRate.Count > 0)
			{
				message += $"<HR>{this._heartRate.Last()}";
				message += $"<TS>{this._heartRate.Last().Time}";
			}
			if (this._eventCount.Count > 0)
			{
				message += $"<EC>{this._eventCount.Last()}";
			}
			if (this._instanteousCadance.Count > 0)
			{
				message += $"<IC>{this._instanteousCadance.Last()}";
			}
			if (this._accumulatedPower.Count > 0)
			{
				message += $"<AP>{this._accumulatedPower.Last()}";
			}
			if (this._instanteousPower.Count > 0)
			{
				message += $"<IP>{this._instanteousPower.Last()}";
			}
			message += $"<EOF>";
			return message;
		}

		public void AddET(string et, string datetime)
		{
			this._elapsedTime.Add(new TimeData(et, datetime));
		}

		public void AddDT(string dt, string datetime)
		{
			this._distanceTravelled.Add(new TimeData(dt, datetime));
		}

		public void AddSP(string sp, string datetime)
		{
			this._speed.Add(new TimeData(sp, datetime));
		}

		public void AddHR(string hr, string datetime)
		{
			this._heartRate.Add(new TimeData(hr, datetime));
		}

		public void AddEC(string ec, string datetime)
		{
			this._eventCount.Add(new TimeData(ec, datetime));
		}

		public void AddIC(string ic, string datetime)
		{
			this._instanteousCadance.Add(new TimeData(ic, datetime));
		}

		public void AddAP(string ap, string datetime)
		{
			this._accumulatedPower.Add(new TimeData(ap, datetime));
		}

		public void AddIP(string ip, string datetime)
		{
			this._instanteousPower.Add(new TimeData(ip, datetime));
		}

		public void SetPNA(string patientName)
		{
			if (this.patientNumber == string.Empty)
			{
				this.patientName = patientName;
			}
		}

		public void SetPNU(string patientNumber)
		{
			if (this.patientNumber == string.Empty)
			{
				this.patientNumber = patientNumber;
			}
		}
	}
}
