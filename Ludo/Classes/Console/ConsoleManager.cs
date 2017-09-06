using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.CE {
	class ConsoleManager : IDisposable {

		public int MaxLineLength = 255;
		public int MaxLineAmount = 10;
		private List<string> lines;
		private List<LineModification> lineMods;

		public Position CurrentPosition;
		public Position BottomRightPosition {
			get {
				int x = this.CurrentPosition.X + this.MaxLineLength;
				int y = this.CurrentPosition.Y + this.MaxLineAmount;
				return new Position(x, y);
			}
		}

		public List<int> ModedLines {
			get {
				return new List<int>(this.lineMods.Select(C => C.Position.Y));
			}
		}

		public void Dispose() {
			this.lines = new List<string>();
			this.lineMods = new List<LineModification>();
		}

		public void WriteCenterLine(string line,char sideFill = ' ') {
			int sideWidth = Convert.ToInt32((this.MaxLineLength / 2) - (line.Length / 2));
			this.lines.Add((new String(sideFill, sideWidth - (2 + (line.Length % 2))) + line + (new String(sideFill, sideWidth + 2))));
		}

		public void WriteLine(string line) {
			this.lines.Add(line);
		}

		#region Constructers

		public ConsoleManager() {
			this.lines = new List<string>();
			this.lineMods = new List<LineModification>();
			this.CurrentPosition = new Position(0, 0);
		}

		public ConsoleManager(IEnumerable<string> lines) {
			this.lines = new List<string>(lines);
			this.lineMods = new List<LineModification>();
			this.CurrentPosition = new Position(0, 0);
		}

		public ConsoleManager(IEnumerable<string> lines, Position pos) {
			this.lines = new List<string>(lines);
			this.lineMods = new List<LineModification>();
			this.CurrentPosition = pos;
		}

		#endregion

		#region Draw

		public void Draw(Position start, Position end, string content, ConsoleColor c) {

			int height = (end.Y == start.Y ? 1 : end.Y - (start.Y-1));
			int width = (end.X == start.X ? 1 : end.X - (start.X-1));
			int length = height * width;
			char[] chars = content.ToCharArray();

			for(int i = 0; i < length; i++) {

				int y = (i == 0 ? 0 : Convert.ToInt32(Math.Floor(i.ToDecimal() / width.ToDecimal())));
				int x = (i == 0 ? 0 : i % width);

				if(i > content.Length)
					break;

				Position pos = new Position(start.X+x,start.Y+y);

				this.lineMods.Add(new LineModification(pos, c, chars[i]));

			}

		}

		public void Draw(Position start, Position end, string content) {
			this.Draw(start, end, content, Console.ForegroundColor);
		}

		#endregion

		public void Display(bool clearFirst = true) {
			if(clearFirst)
				Console.Clear();

			for(int y = this.CurrentPosition.Y; y < this.BottomRightPosition.Y; y++) {

				List<LineModification> lineMods = this.lineMods
				.Where(C => (
						C.Position.Y == y
					)
				).OrderBy(
					C => C.Position.X
				).ToList();

				string line = (y <= (this.lines.Count-1) ? this.lines[y] : String.Empty);

				if(lineMods.Count > 0) {

					char[] lineChars = line.ToCharArray();

					for(int x = this.CurrentPosition.X; x < this.BottomRightPosition.X; x++) {

						if(x > lineMods[(lineMods.Count - 1)].Position.X && lineChars.ElementAtOrDefault(x) == default(char))
							break;

						if(lineMods.Where(C => C.Position.X == x).ToList().Count == 1) {
							LineModification lineMod = lineMods.Where(C => C.Position.X == x).ToList()[0];
							lineMod.Draw();
						} else {
							Console.Write(lineChars.ElementAtOrDefault(x));
						}

					}
					Console.WriteLine();
				} else {

					Console.WriteLine(line.Substr(this.CurrentPosition.X, this.BottomRightPosition.X));

				}

				

			}

		}

	}
}
