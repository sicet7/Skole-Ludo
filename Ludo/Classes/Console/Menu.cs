using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.CE {
	class Menu : IRunnable {

		private ConsoleManager console;

		public Menu() {
			this.console = new ConsoleManager();
		}

		public void Run() {

			this.console.MaxLineLength = Console.WindowWidth - 1;
			this.console.MaxLineAmount = Console.WindowHeight - 1;
			this.console.CurrentPosition = Position.New(10, 10);

			this.console.Dispose();

			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");
			this.console.WriteLine("##########");

			this.console.Draw(Position.New(20,10),Position.New(27,17),new String('æ',64),ConsoleColor.Red);

			this.console.Display();

			Console.ReadKey();

		}

	}
}
