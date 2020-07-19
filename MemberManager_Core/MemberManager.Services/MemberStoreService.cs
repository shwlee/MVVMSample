using MemberManager.Common.Utils.IoC;
using MemberManager.Defines.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MemberManager.Services
{
	public class MemberStoreService : IMemberStoreService
	{
		private readonly List<IMember> _members = new List<IMember>();

		public void Load<T>(string path) where T : IMember
		{
			this._members.Clear();

			var csv = ServiceBag.Resolve<ICsvService>();
			var members = csv.ReadCsv<T>(path);
			foreach (var member in members)
			{
				this._members.Add(member);
			}
		}

		public void Save(string path)
		{
			var csv = ServiceBag.Resolve<ICsvService>();
			csv.WriteCsv(this._members, path);
		}

		public IEnumerable<IMember> GetAllMembers()
		{
			return this._members.Select(m => m.DeepCopy()).ToList();
		}

		public IMember GetMember(string name)
		{
			var member = this._members.FirstOrDefault(m => string.CompareOrdinal(name, m.Name) == 0);
			return member?.DeepCopy();
		}

		public void SetMember(IMember member)
		{
			// TODO : 별도의 key 를 주고 처리한다.
			this._members.RemoveAll(m => string.CompareOrdinal(member.Name, m.Name) == 0);
			this._members.Add(member);
		}

		public void ClearMembers()
		{
			this._members.Clear();
		}
	}
}
