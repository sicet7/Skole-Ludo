using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.CE {
	class LineModification {

		public readonly Position Position;
		public readonly ConsoleColor Color;
		public readonly char Value;

		public LineModification(Position p,ConsoleColor c, char v) {
			this.Position = p;
			this.Color = c;
			this.Value = v;
		}

		public void Draw() {
			ConsoleColor oldColor = Console.ForegroundColor;
			Console.ForegroundColor = this.Color;
			Console.Write(this.Value.ToString());
			Console.ForegroundColor = oldColor;
		}

	}
}
