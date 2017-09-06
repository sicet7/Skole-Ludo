using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo{
	internal interface IPlayer {

		string Name { get; set; }//Gets and Sets the name of the player
		bool Finished { get; }//Gets when the player is done player i.e All the players pieces are in goal.
		bool Playing { get; set; }

		void CreatePieces();//Creates GamePieces

	}
}
