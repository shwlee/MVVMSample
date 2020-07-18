using System.Collections.Generic;

namespace MemberManager.Defines.Interfaces
{
	public interface IMemberStoreService
	{
		void Load<T>(string path) where T : IMember;

		void Save(string path);

		IMember GetMember(string name);

		IEnumerable<IMember> GetAllMembers();

		void SetMember(IMember member);

		void ClearMembers();
	}
}
