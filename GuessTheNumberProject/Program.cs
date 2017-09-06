using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumberProject {

	class Program {
		const int MaxGuesses = 7;
		int NbrOfGuesses = MaxGuesses;

		int GenerateMagicNumber(int HighestNumber) {
			Random rnd = new Random();
			return rnd.Next(HighestNumber+1);
		}
		int AskForTheGuess() {
			NbrOfGuesses--; // same as NbrOfGuesses = NbrOfGuesses - 1;
			Console.Write($"Enter your guess : ");
			var TheGuess = Console.ReadLine();
			return int.Parse(TheGuess);
		}
		int CompareGuessToMagicNumber(int MagicNumber, int TheGuess) {
			if (MagicNumber == TheGuess) { // is the guess correct? 
				return 0;
			} else if (MagicNumber > TheGuess) { // guess it too low
				return -1;
			} else {
				return 1;
			}
		}
		bool PrintOutcomeResult(int Result) {
			switch (Result) {

				case 0:  // the guess matched - they won
					Debug("Correct! - You Won!");
					return true;

				case -1:  // the guess is too low
					Debug($"Too low. You have {NbrOfGuesses} guesses remaining.");
					if (NbrOfGuesses == 0) {
						Debug("You're out of guesses - you Lose!");
						return true;
					}
					return false;

				case 1:  // the guess is too high
					Debug($"Too high. You have {NbrOfGuesses} guesses remaining.");
					if (NbrOfGuesses == 0) {
						Debug("You're out of guesses - you Lose!");
						return true;
					}
					return false;

				default:
					return true;
			}
		}
		void Debug(string message) {
			Console.WriteLine(message);
		}
		void RunGameOnce() {
			NbrOfGuesses = MaxGuesses;
			var MagicNumber = GenerateMagicNumber(100);
			bool GameOver = false;
			while (GameOver == false) {
				var UserGuess = AskForTheGuess();
				var GuessResult = CompareGuessToMagicNumber(MagicNumber, UserGuess);
				GameOver = PrintOutcomeResult(GuessResult);
			}
		}
		void Run() {
			bool PlayAgain = true;
			while (PlayAgain == true) {
				RunGameOnce();
				Console.Write($"Do you want to play again? Y/N : "); 
				//var answer = Console.ReadLine();
				//if(answer == "Y" || answer == "y") {
				//	PlayAgain = true;
				//} else {
				//	PlayAgain = false;
				//}
				PlayAgain = Console.ReadLine().ToUpper().StartsWith("Y");
			}
		}

			static void Main(string[] args) {
			new Program().Run();
		}
	}
}
