using MemberManager.Defines.Interfaces;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MemberManage.Services
{
	public class CsvService : ICsvService
	{		
		public IEnumerable<T> Read<T>(string path)
		{
			using (var reader = new StreamReader(path))
			{
				using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
				{
					 var records = csv.GetRecords<T>().ToList();
					return records;
				}
			}
		}
	}
}
