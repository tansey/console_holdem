using System;
using System.IO;
using System.Text;
using holdem_engine;
using HoldemHand;
using System.Threading;

namespace console_poker
{
	class MainClass
	{
		const string CLASSIFIER_DIR = "/Users/wesley/poker/classifiers/";
		public static void Main (string[] args)
		{
			Console.WriteLine("Loading opponents...");
			var seats = new Seat[6];
			seats[0] = new Seat(1, "TeeJayorTJ5", 1000, new WekaPlayer(CLASSIFIER_DIR + "preflop.model",CLASSIFIER_DIR + "flop.model",CLASSIFIER_DIR + "turn.model",CLASSIFIER_DIR + "river.model"));
			seats[1] = new Seat(2, "Dave_Wilkes", 1000, new WekaPlayer(CLASSIFIER_DIR + "preflop.model",CLASSIFIER_DIR + "flop.model",CLASSIFIER_DIR + "turn.model",CLASSIFIER_DIR + "river.model"));
			seats[2] = new Seat(3, "Some_Killa", 1000, new WekaPlayer(CLASSIFIER_DIR + "preflop.model",CLASSIFIER_DIR + "flop.model",CLASSIFIER_DIR + "turn.model",CLASSIFIER_DIR + "river.model"));
			seats[3] = new Seat(4, "Better_Boy", 1000, new WekaPlayer(CLASSIFIER_DIR + "preflop.model",CLASSIFIER_DIR + "flop.model",CLASSIFIER_DIR + "turn.model",CLASSIFIER_DIR + "river.model"));
			seats[4] = new Seat(5, "Kiddo1973", 1000, new WekaPlayer(CLASSIFIER_DIR + "preflop.model",CLASSIFIER_DIR + "flop.model",CLASSIFIER_DIR + "turn.model",CLASSIFIER_DIR + "river.model"));
			seats[5] = new Seat(6, "Human", 1000, new ConsolePlayer());
			var blinds = new double[] { 10, 20 };
			uint handNumber = 0;
			Console.WriteLine("Starting simulation");
			HandEngine engine = new HandEngine();
			while(true)
			{
				HandHistory results = new HandHistory(seats, handNumber, handNumber % (uint)seats.Length + 1, blinds, 0, BettingStructure.Limit);
				//engine.PlayHand(results, cachedHands[(int)handNumber]);
				engine.PlayHand(results);

				Console.WriteLine(results.ToString(true));
				Thread.Sleep(2000);

				foreach(var seat in seats)
					if(seat.Chips == 0)
					{
						Console.WriteLine("{0} rebuys for $1000", seat.Name);
						seat.Chips = 1000;
					}

				handNumber++;
			}
		}
	}
}
