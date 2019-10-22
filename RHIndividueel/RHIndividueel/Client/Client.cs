using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ErgoConnect;

namespace Client
{
    class Client
    {

        private static NetworkStream stream;
        private static byte[] buffer = new byte[1024];
        static string totalBuffer = "";


        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();
            client.Connect("localhost", 1717); // was 1717

            stream = client.GetStream();
            string clientErgoID = "00457";

            //BLEconnect ergoClient = new BLEconnect(clientErgoID);

            BLESimulator simulator = new BLESimulator(clientErgoID);

            List<byte[]> rawData = new List<byte[]>();
            rawData = simulator.ReadData(ApplicationSettings.GetReadWritePath(clientErgoID), WriteOption.Ergo);
            BLEDataHandler dataHandler = new BLEDataHandler(clientErgoID);

            for (int i = 0; i < rawData.Count; i++)
            {
                BLEDecoderErgo.Decrypt(rawData[i], dataHandler);
  
            }

            List<BLEData> data = dataHandler._bleData;

            string dataMessage = Environment.UserName + "#";

            //stream.BeginRead(buffer, 0, buffer.Length, new AsyncCallback(OnRead), null);

            Write("Connect", Environment.UserName);

            foreach (BLEData dataPacket in data)
            {
                dataMessage += dataPacket.GetData() + "\n";
                System.Threading.Thread.Sleep(1000);
                Write("Datapackage", dataMessage);
                dataMessage = Environment.UserName + "#";
            }
        }

        private static void Write(string tag, string message)
        {
            string fullMessage = tag + "#" + message;

            Console.WriteLine("Writing: " + fullMessage);

            stream.Write(Encoding.ASCII.GetBytes(fullMessage), 0, fullMessage.Length);
            stream.Flush();
        }

        private static void OnRead(IAsyncResult ar)
        {
            Console.WriteLine("Data received");
            //server response handling
        }
    }
}
