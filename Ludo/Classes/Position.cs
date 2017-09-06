using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo {
	public struct Position {

		private int x,y;
		private bool allowChange;

		public int X {
			get => this.x;
		}

		public int Y {
			get => this.y;
		}

		public bool CanChange {
			get => this.allowChange;
		}

		public Position(int x,int y,bool allowchange = false) {
			this.x = x;
			this.y = y;
			this.allowChange = allowchange;
		}

		public void MoveTo(int x, int y) {

			if(this.CanChange) {
				this.x = x;
				this.y = y;
			}

		}

		public void Move(int x, int y) {

			if(this.CanChange) {
				this.x += x;
				this.y += y;
			}

		}

		public static Position New(int x,int y) {
			return new Position(x,y);
		}

	}
}
