using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MemberManager.Defines.Classes.Messaging;
using System.Windows.Input;

namespace MemberManager.ViewModels
{
	public class MainViewModel
	{
		public NamePaneViewModel NamePane { get; set; } = new NamePaneViewModel();

		public DetailPaneViewModel DetailPane { get; set; } = new DetailPaneViewModel();

		#region Commands

		private RelayCommand _logoutCommand;

		public ICommand LogoutCommand => this._logoutCommand ?? (this._logoutCommand = new RelayCommand(this.Logout));

		private void Logout()
		{
			var arg = new LogoutCompleted();
			Messenger.Default.Send(arg);
		}

		#endregion
	}
}
