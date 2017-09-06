using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.CE {
	class Game : IRunnable {

		private Board board;
		private ConsoleManager console;

		public Game() {
			this.console = new ConsoleManager(new Board());
			this.console.CurrentPosition = new Position(0, 0, true);
		}

		public void Run() {

			this.console.MaxLineAmount = Console.WindowHeight - 1;
			this.console.MaxLineLength = Console.WindowWidth - 1;

			this.console.Display();
		}
	}
}
