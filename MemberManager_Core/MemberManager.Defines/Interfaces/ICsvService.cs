using System.Collections.Generic;

namespace MemberManager.Defines.Interfaces
{
	public interface ICsvService
	{
		IEnumerable<T> ReadCsv<T>(string path);

		void WriteCsv<T>(IEnumerable<T> model, string path);
	}
}
