using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo {
	internal interface IGame : IActivatable {

		bool GameActive { get; }//Returns true ít main loop has been broken.

		void CleanUp();//Cleans Up the Game and resets assets.

	}
}
