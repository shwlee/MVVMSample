using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberManager.Defines.Interfaces
{
	public interface IMemberStoreService<T>
	{
		void Load(IEnumerable<T> members);

		IEnumerable<T> GetAllMemebers();
	}
}
