using System;

// HERE POP UP MESSAGES ARE HANDELED


namespace TheMessageHandler
{
	public static class MessagePrinter
	{

		public static void Print(string message)
		{
			theAndroidInterface.AndroidInterface.androidMessagePrinter(message);
		}

		public static void NumberPrinter(string exp)
		{
			theAndroidInterface.AndroidInterface.androidNumberPrinter (exp);
		}

	}
}

