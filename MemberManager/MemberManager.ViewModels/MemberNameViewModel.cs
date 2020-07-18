using GalaSoft.MvvmLight.Messaging;
using MemberManager.Common.Utils;
using MemberManager.Defines.Classes;
using MemberManager.Models;
using System.Collections.ObjectModel;

namespace MemberManager.ViewModels
{
	public class MemberNameViewModel : PropertyChangedNotifier
	{
		private Member _selectedMemeber;

		public ObservableCollection<Member> Members { get; } = new ObservableCollection<Member>();

		public Member SelectedMemeber
		{
			get => _selectedMemeber;
			set
			{
				this.Set(ref this._selectedMemeber, value);
				
				var arg = new SelectedMember<Member>
				{
					Member = this._selectedMemeber
				};
				Messenger.Default.Send(arg);
			}
		}
	}
}
