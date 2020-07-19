using System.Collections.Generic;

namespace MemberManager.Defines.Interfaces
{
	public interface ICsvService
	{
		IEnumerable<T> Read<T>(string path);
	}
}
