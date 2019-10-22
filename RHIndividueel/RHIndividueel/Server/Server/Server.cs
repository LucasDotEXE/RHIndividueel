using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
	public class Server
	{
		private readonly TcpListener listener;
		public List<ServerClient> Clients { get; set; }
		public bool Streaming { get; set; }
		public ServerClient Doctor { get; set; }
		public Dictionary<string, ClientData> ClientDatas { get; set; }

		private static void Main(string[] args)
		{
			new Server();
			Console.ReadKey();
		}

		public Server()
		{
			this.Clients = new List<ServerClient>();
			this.ClientDatas = new Dictionary<string, ClientData>();
			this.listener = new TcpListener(IPAddress.Any, 1717); // Was 1717
			this.listener.Start();

			this.listener.BeginAcceptTcpClient(new AsyncCallback(this.OnConnect), null);
			Console.WriteLine("Listening..");
		}

		private void OnConnect(IAsyncResult ar)
		{
			TcpClient newClient = this.listener.EndAcceptTcpClient(ar);
			this.Clients.Add(new ServerClient(newClient, this));
			Console.WriteLine("New client connected");

			this.listener.BeginAcceptTcpClient(new AsyncCallback(this.OnConnect), null);
		}

		public void StartStreamingDataToDoctor()
		{
			while (this.Streaming)
			{
				foreach (string key in this.ClientDatas.Keys)
				{
					string message = $"<{Tag.MT.ToString()}>data<{Tag.ID.ToString()}>{key}{this.ClientDatas[key]}";
					this.Doctor.Write(message);
				}
				Thread.Sleep(250);
			}
		}

		public void WriteToSpecificErgo(string ergoID, string message)
		{
			foreach (ServerClient client in this.Clients)
			{
				if (ergoID == client.ErgoID)
				{
					client.Write(message);
				}
			}
		}

		public void BroadcastDoctorsMessage(string message)
		{
			foreach (ServerClient client in this.Clients)
			{
				if (client != this.Doctor)
				{
					client.Write(message);
				}
			}
		}
	}
}
