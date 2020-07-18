using CsvHelper;
using MemberManager.Defines.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MemberManager.Services.Utils
{
	public class CsvService : ICsvService
	{
		public IEnumerable<T> ReadCsv<T>(string path)
		{
			IEnumerable<T> records = null;
			using (var reader = new StreamReader(path))
			{
				using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
				{
					records = csv.GetRecords<T>().ToList();
				}
			}

			return records;
		}

		public void WriteCsv<T>(IEnumerable<T> models, string path)
		{
			using (var writer = new StreamWriter(path))
			{
				using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
				{
					csv.WriteRecords(models);
				}
			}
		}
	}
}
