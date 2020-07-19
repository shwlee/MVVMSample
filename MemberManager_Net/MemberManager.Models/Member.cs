using MemberManager.Defines.Interfaces;

namespace MemberManager.Models
{
	public class Member
	{
		public string Name { get; set; }

		public string RealName { get; set; }

		public string Nationality { get; set; }

		public string Birthday { get; set; }
		
		public string BirthPlace { get; set; }

		public string Agency { get; set; }

		public string Team { get; set; }

		public string Image { get; set; }

		public object Clone()
		{
			var clone = new Member
			{
				Name = this.Name,
				RealName = this.RealName,
				Nationality = this.Nationality,
				Birthday = this.Birthday,
				BirthPlace = this.BirthPlace,
				Agency = this.Agency,
				Team = this.Team,
				Image = this.Image,
			};
			return clone;
		}
	}
}
