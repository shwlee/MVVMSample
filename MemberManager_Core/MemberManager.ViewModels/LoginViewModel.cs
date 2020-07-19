using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MemberManager.Common.Utils;
using MemberManager.Common.Utils.IoC;
using MemberManager.Defines.Classes;
using MemberManager.Defines.Interfaces;
using MemberManager.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModels
{
	public class LoginViewModel : PropertyChangedNotifier
	{
		private string _id;
		
		private string _password;
		
		private bool _isGoingLoging;

		public string Id 
		{
			get => _id;
			set => this.Set(ref this._id, value);
		}

		public string Password 
		{
			get => _password;
			set => this.Set(ref this._password, value);
		}

		public bool IsGoingLoging 
		{
			get => _isGoingLoging;
			set => this.Set(ref this._isGoingLoging, value);
		}
		
		#region Commands

		private RelayCommand _loginCommand;		

		public ICommand LoginCommand => this._loginCommand ?? (this._loginCommand = new RelayCommand(this.Login));

		private async void Login()
		{
			this.IsGoingLoging = true;

			// login implementation
			await Task.Delay(2000);

			
			var memberStore = ServiceBag.Resolve<IMemberStoreService>();
			memberStore.Load<Member>(@"IOI.csv");

			Messenger.Default.Send<LoginCompleted>(null);

			this.IsGoingLoging = false;
		}

		#endregion
	}
}
