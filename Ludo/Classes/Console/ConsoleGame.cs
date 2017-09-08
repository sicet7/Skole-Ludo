using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ludo.CE {
	class ConsoleGame : IGame {

		private bool running = true;
        public bool first = true;

		public bool GameActive {
			get => this.running;
		}

		
		private Menu menu;
		private ConsoleManager console;

		public ConsoleGame() {
			this.menu = new Menu();
			this.console = new ConsoleManager(new Board());
			this.console.CurrentPosition = new Position(0, 0, true);
		}

		public void CleanUp() {
			throw new NotImplementedException();
		}

		public void Activate() {

			do {

				if(this.first) {
					this.menu.Run();
				} else {
					this.console.MaxLineAmount = Console.WindowHeight - 1;
					this.console.MaxLineLength = Console.WindowWidth - 1;

					this.console.Display();
				}

			} while(this.running);


			//TESTING!!!

			//this.output = new BoardOutputer(Path.Combine(this.assetsDirectory,fileName));

			/*for(uint y = 0; y <= (Convert.ToUInt32(lines.Length)-1); y++) {

				char[] line = lines[y].ToCharArray();

				for(uint x = 0; x <= (Convert.ToUInt32(line.Length)-1);x++) {
					char unit = line[x];

					if(unit != ' ') {

						boardChars.Add(, unit);
					}

				}

			}*/

			/*foreach(string line in lines) {
				Console.WriteLine(line.Substring(0, Console.WindowWidth - 1));
				lineCount++;
				if(lineCount >= Console.WindowHeight - 1) {
					break;
				}
			}*/

			/*
						string AssetsDirectory = Path.Combine(Environment.CurrentDirectory, "Assets");

						string[] lines = File.ReadAllLines(AssetsDirectory + "\\Board.txt");

						string board = string.Join(Environment.NewLine, lines);
						*/

			//Console.WriteLine(lines.Length);

			//uint lineCount = 0;

			//string board = string.Join(Environment.NewLine, lines);

			//Console.WriteLine(ConsoleGame.Sha256(board));

			/*foreach(string line in lines) {
				Console.WriteLine(line.Substring(0,Console.WindowWidth-1));
				lineCount++;
				if(lineCount >= Console.WindowHeight-1) {
					break;
				}
			}*/
			//Console.WriteLine(boardChars.Count);

			/*Console.SetWindowSize(84, 50);

			Console.Clear();


			Console.SetCursorPosition(20,20);//<- DONT USE THIS!
			Console.Write("hhhh");

			//Console.WriteLine(Hasher.Sha256(board));

			Console.ReadLine();*/

		}

	}
}
