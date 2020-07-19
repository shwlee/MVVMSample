using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MemberManager.Defines.Classes.Messaging;
using MemberManager.Models;

namespace MemberManager.ViewModels
{
	public class DetailPaneViewModel : ObservableObject
	{
		private string _name;
		
		private string _realName;
		
		private string _nationality;
		
		private string _birthday;
		
		private string _birthPlace;
		
		private string _agency;
		
		private string _team;
		
		private string _image = string.Empty;

		public string Name { get => _name; set => this.Set(ref this._name, value); }

		public string RealName { get => _realName; set => this.Set(ref this._realName, value); }

		public string Nationality { get => _nationality; set => this.Set(ref this._nationality, value); }

		public string Birthday { get => _birthday; set => this.Set(ref this._birthday, value); }

		public string BirthPlace { get => _birthPlace; set => this.Set(ref this._birthPlace, value); }

		public string Agency { get => _agency; set => this.Set(ref this._agency, value); }

		public string Team { get => _team; set => this.Set(ref this._team, value); }

		public string Image { get => _image; set => this.Set(ref this._image, value); }

		public DetailPaneViewModel()
		{
			this.Init();
		}

		private void Init()
		{
			Messenger.Default.Register<Selected<Member>>(this, this.SetDetail);
		}

		private void SetDetail(Selected<Member> selected)
		{
			var member = selected.Item;

			this.Name = member.Name;
			this.RealName = member.RealName;
			this.Nationality = member.Nationality;
			this.Birthday = member.Birthday;
			this.BirthPlace = member.BirthPlace;
			this.Agency = member.Agency;
			this.Team = member.Team;
			this.Image = member.Image;
		}
	}
}
