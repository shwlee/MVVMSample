using GalaSoft.MvvmLight.Messaging;
using MemberManager.Common.Utils;
using MemberManager.Defines.Classes;
using MemberManager.Models;

namespace MemberManager.ViewModels
{
	public class MemberDetailViewModel : PropertyChangedNotifier
	{
		private string _name;
		
		private string _realName;
		
		private string _nationality;
		
		private string _birthday;
		
		private string _birthPlace;
		
		private string _agency;
		
		private string _team;
		
		private string _image;

		public string Name { get => _name; set => this.Set(ref this._name, value); }

		public string RealName { get => _realName; set => this.Set(ref this._realName, value); }

		public string Nationality { get => _nationality; set => this.Set(ref this._nationality, value); }

		public string Birthday { get => _birthday; set => this.Set(ref this._birthday, value); }

		public string BirthPlace { get => _birthPlace; set => this.Set(ref this._birthPlace, value); }

		public string Agency { get => _agency; set => this.Set(ref this._agency, value); }

		public string Team { get => _team; set => this.Set(ref this._team, value); }

		public string Image { get => _image; set => this.Set(ref this._image, value); }

		public MemberDetailViewModel()
		{
			this.InitMessages();
		}

		private void InitMessages()
		{
			Messenger.Default.Register<SelectedMember<Member>>(this, this.SetMember);
		}

		private void SetMember(SelectedMember<Member> member)
		{
			if (member.Member == null)
			{
				this.Clear();
				return;
			}

			var to = member.Member;
			this.Name = to.Name;
			this.RealName = to.RealName;
			this.Nationality = to.Nationality;
			this.Birthday = to.Birthday;
			this.BirthPlace = to.BirthPlace;
			this.Agency = to.Agency;
			this.Team = to.Team;
			this.Image = to.Image;
		}

		private void Clear()
		{
			this.Name = string.Empty;
			this.RealName = string.Empty;
			this.Nationality = string.Empty;
			this.Birthday = string.Empty;
			this.BirthPlace = string.Empty;
			this.Agency = string.Empty;
			this.Team = string.Empty;
			this.Image = string.Empty;
		}
	}
}
