using System;

namespace Server
{
	public enum Tag
	{
		// Page 16
		ET, // Elapsed time
		DT, // Distance travelled
		SP, // Speed
		HR, // Heartrate

		// Page 25
		EC, // Event count
		IC, // Instanteous cadence
		AP, // Accumulated power
		IP, // Instanteous power

		// Extra
		EOF,// End Of File
		AC, // Action
		UN, // Username
		PW, // Password
		ID, // Tag of Ergometer / simulator ID
		TS, // Timestamp
		MT, // The Message type of the message
		SR, // Set resistance percentage
		DM,  // Doctors message
		PNA, // The name of the patient
		PNU, // The number of the patient
		DATA, // Data tag
		LR  //Login Reaction
	}

	public class TagDecoder
	{
		public static string GetValueByTag(Tag tag, string packet)
		{
			char openTag = '<';
			char closeTag = '>';
			if (tag != Tag.EOF)
			{
				string completeTag = $"{openTag}{tag.ToString()}{closeTag}";
				if (packet.Contains(completeTag))
				{
					//  Console.WriteLine("Found and processed tag! {tag.ToString()}");
					int startPosition = -1;
					int endPosition = -1;
					for (int i = packet.IndexOf(completeTag); i < packet.Length; i++)
					{
						char characterAtIndex = packet[i];
						if (characterAtIndex == closeTag && i + 1 < packet.Length)
						{
							startPosition = i + 1;
							break;
						}
					}
					for (int i = startPosition; i < packet.Length; i++)
					{
						char characterAtIndex = packet[i];
						if (characterAtIndex == openTag && i - 1 >= 0)
						{
							endPosition = i;
							break;
						}
					}
					try
					{
						string value = packet.Substring(startPosition, endPosition - startPosition);
						//Console.WriteLine($"Found value corresponding with tag : {completeTag}{value}");
						return value;
					}
					catch (ArgumentOutOfRangeException e) { Console.WriteLine($"Apparently something went wrong in the GetValueByTag() method located in the ServerClient class. Have you changed any code? {e.ToString()}"); }
				}
				// else Console.WriteLine("String does not contain your searched tag, have you added tags? Search tag: " + tag.ToString());
			}
			return null;
		}
	}
}
