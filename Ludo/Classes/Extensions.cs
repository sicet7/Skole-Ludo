using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo {
	public static class Extensions {

		public static string Substr(this string text, int start, int length) {

			string str = (start < 0 ? new String(' ', (start * -1)) : "");//prepends spaces if start is below 0
			int nStart = (start < 0 ? 0 : start);

			return (str + text).Length <= nStart ? ""
				: (str+text).Length - nStart <= length ? (str + text).Substring(nStart)
				: (str + text).Substring(nStart, length);
		}

		public static decimal ToDecimal(this int i) {
			return Convert.ToDecimal(i);
		}

		public static IList<T> Swap<T>(this IList<T> list, int indexA, int indexB) {
			T tmp = list[indexA];
			list[indexA] = list[indexB];
			list[indexB] = tmp;
			return list;
		}

		public static int Diff(this int a,int b) {

			long fromA = Convert.ToInt64(a);
			long fromB = Convert.ToInt64(b);

			long result = Math.Abs(fromA - fromB);

			if(result > Convert.ToInt64(int.MaxValue))
				return int.MaxValue;

			if(result < Convert.ToInt64(int.MinValue))
				return int.MinValue;

			return Convert.ToInt32(result);

		}

	}
}
