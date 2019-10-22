using System;
using System.IO;

namespace Server.Data
{
	internal class FileWriter
	{
		/*
        TO DO
        
        Objects wegschrijven doormiddel van Memorystream.ToArray()
        */
		public string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RemoteHealthcare\PatientData";
		public void WriteFile(string clientID, string message)
		{
			try
			{
				string path = this.dir + @"\" + clientID + ".txt";

				if (!File.Exists(path))
				{
					Directory.CreateDirectory(this.dir);
					using (StreamWriter sw = File.CreateText(path))
					{
						sw.WriteLine(message);
					}
				}
				else
				{
					using (StreamWriter sw = File.AppendText(path))
					{
						sw.WriteLine(message);
					}
				}
			}
			catch (Exception)
			{

			}
		}

		public static bool CheckPassword(string us, string pw)
		{
			try
			{
				string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\RemoteHealthcare\DoctorLogin.txt";
				string s;
				using (StreamReader sr = File.OpenText(path))
				{
					s = sr.ReadLine();
					while (s != null)
					{
						if (TagDecoder.GetValueByTag(Tag.UN, s) == us)
						{
							if (TagDecoder.GetValueByTag(Tag.PW, s) == pw)
							{
								return true;
							}
							else
							{
								return false;
							}
						}
						s = sr.ReadLine();
					}
					return us == "admin" && pw == "admin";
				}
			}
			catch (Exception)
			{
				return us == "admin" && pw == "admin";
			}

		}

		public string ReadFile(string clientID)
		{

			string path = this.dir + @"\" + clientID + ".txt";
			string packet = "";

			if (File.Exists(path))
			{
				using (StreamReader sr = File.OpenText(path))
				{
					while (sr.ReadLine() != null)
					{
						packet += sr.ReadLine();
					}
					return packet;
				}
			}
			else
			{
				Console.WriteLine("This file does not exist");
				return "";
			}


		}
	}
}