using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo {

	class Program {

		static IGame game = null;
		static void Main() {


			do {
				Console.Clear();
				Console.WriteLine("Choose how to play the game!");
				Console.WriteLine();
				Console.WriteLine("1) Play in A Windows Form Application");
				Console.WriteLine("2) Play in A Console Application");
				Console.WriteLine("3) Exit");
				char input = Console.ReadKey().KeyChar;

				if(input=='1')
					Program.game=new WFE.WindowsFormGame();

				if(input=='2')
					Program.game=new CE.ConsoleGame();


				if(input=='3')
					return;

			} while(game == null);


            Program.game.Activate();
			if(!Program.game.GameActive) {
				Program.game.CleanUp();
			}

			Program.game=null;

		}
	}
}
