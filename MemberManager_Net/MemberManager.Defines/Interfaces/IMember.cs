using System;

namespace MemberManager.Defines.Interfaces
{
	public interface IMember : ICloneable
	{
		string Name { get; set; }

		string RealName { get; set; }

		string Nationality { get; set; }

		string Birthday { get; set; }

		string BirthPlace { get; set; }

		string Agency { get; set; }

		string Team { get; set; }

		string Image { get; set; }
	}
}
