namespace Server.Data
{
	public class TimeData
	{
		public string Time { get; }
		public string Data { get; }

		public TimeData(string data, string time)
		{
			this.Time = time;
			this.Data = data;
		}

		public override string ToString()
		{
			return this.Data;
		}
	}
}
