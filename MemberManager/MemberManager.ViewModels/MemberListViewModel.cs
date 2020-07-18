using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MemberManager.Common.Utils;
using MemberManager.Common.Utils.IoC;
using MemberManager.Defines.Classes;
using MemberManager.Defines.Interfaces;
using MemberManager.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MemberManager.ViewModels
{
	public class MemberListViewModel : PropertyChangedNotifier
	{
		private MemberNameViewModel _names;

		private MemberDetailViewModel _detail = new MemberDetailViewModel();

		public ObservableCollection<Member> Members { get; } = new ObservableCollection<Member>();

		public MemberNameViewModel Names
		{
			get => _names;
			set => this.Set(ref this._names, value);
		}

		public MemberDetailViewModel Detail
		{
			get => _detail;
			set => this.Set(ref this._detail, value);
		}

		public void Load()
		{
			this.Members.Clear();
			var names = new MemberNameViewModel();
			var allMembers = ServiceBag.Resolve<IMemberStoreService>().GetAllMembers();
			foreach (Member member in allMembers)
			{
				this.Members.Add(member);
				names.Members.Add(member);
			}

			this.Names = names;			
		}

		#region Commands

		private RelayCommand _logoutCommand;

		public ICommand LogoutCommand => this._logoutCommand ?? (this._logoutCommand = new RelayCommand(this.Logout));

		private void Logout()
		{
			Messenger.Default.Send<Logout>(null);
		}

		#endregion
	}
}
