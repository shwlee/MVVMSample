using MemberManager.Defines.Interfaces;
using MemberManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace MemberManage.Services
{
	public class MemberStoreService : IMemberStoreService<Member>
	{
		private List<Member> _members = new List<Member>();

		public void Load(IEnumerable<Member> members)
		{
			this._members.Clear();

			this._members.AddRange(members);
		}

		public IEnumerable<Member> GetAllMemebers()
		{
			return this._members.Select(m => m.Clone()).OfType<Member>();
		}
	}
}
