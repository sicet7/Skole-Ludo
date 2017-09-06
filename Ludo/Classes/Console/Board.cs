using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Ludo.CE {

	class Board : IDisposable, IEnumerable<string> {

		private const string boardHash = "d6caba032a5f7aa4be4a563bcffae415cdd4c9c08257f833fc14087b8185e0b9";
		private const string fileName = "Board.txt";
		private const string assetDirName = "Assets";

		private string assetsDirectory;

		private string[] boardLines;

		public string[] Lines {
			get => this.boardLines;
		}

		public string BoardString{
			get {
				return string.Join(Environment.NewLine, this.boardLines);
			}
		}

		public Board() {

			this.assetsDirectory = Path.Combine(Environment.CurrentDirectory, assetDirName);

			if(!Directory.Exists(this.assetsDirectory))
				throw new FileNotFoundException("Could not find board file!");

			string file = Path.Combine(this.assetsDirectory, fileName);

			if(!File.Exists(file))
				throw new FileNotFoundException("Could not find board file!");

			this.boardLines = File.ReadAllLines(file);

			if(Hasher.Sha256(this.BoardString) != boardHash)
				throw new FileNotFoundException("Could not find board file!");

		}

		public void Dispose() {
			throw new NotImplementedException();
		}

		public IEnumerator<string> GetEnumerator() {
			return (new List<string>(this.Lines)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return this.GetEnumerator();
		}
	}
}
