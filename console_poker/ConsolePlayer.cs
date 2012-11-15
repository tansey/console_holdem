using System;
using System.IO;
using System.Text;
using holdem_engine;
using HoldemHand;
using weka.classifiers;
using weka.core;
using HoldemFeatures;

namespace console_poker
{
	public class ConsolePlayer : IPlayer
	{

		#region IPlayer implementation

		public void GetAction (HandHistory history, out holdem_engine.Action.ActionTypes action, out double amount)
		{
			Console.WriteLine(history.ToString());
			action = getAction();
			amount = 0;
		}

		private holdem_engine.Action.ActionTypes getAction()
		{
			string cmd = Console.ReadLine().ToLower().Trim();
			switch(cmd)
			{
			case "raise":
			case "bet":
			case "b":
			case "r": return holdem_engine.Action.ActionTypes.Raise;
			case "fold":
			case "f": return holdem_engine.Action.ActionTypes.Fold;
			case "call":
			case "check":
			case "c": return holdem_engine.Action.ActionTypes.Call;
			default: Console.WriteLine("Unknown action. Options are fold, call, raise.");
				return getAction();
			}
		}

		#endregion
	}
}

