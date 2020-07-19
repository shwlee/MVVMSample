using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MemberManager.Defines.Classes.Messaging;
using MemberManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MemberManager.ViewModels
{
	public class NamePaneViewModel : ObservableObject
	{
		private Member _selectedMember;

		public ObservableCollection<Member> Members { get; } = new ObservableCollection<Member>();

		public Member SelectedMember
		{
			get => _selectedMember;
			set
			{
				this.Set(ref this._selectedMember, value);
				var arg = new Selected<Member>
				{
					Item = value
				};
				Messenger.Default.Send(arg);
			}
		}

		public void Init(IEnumerable<Member> members)
		{
			this.Members.Clear();
			foreach (var member in members)
			{
				this.Members.Add(member);
			}
		}
	}
}
