using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MemberManager.Defines.Classes.Messaging;
using MemberManager.Defines.Interfaces;
using MemberManager.Models;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MemberManager.ViewModels
{
	public class LoginViewModel : ObservableObject
	{
		private string _id;
		
		private string _password;
		
		private bool _isGoingLogin;

		public string Id { get => _id; set => this.Set(ref this._id, value); }

		public string Password { get => _password; set => this.Set(ref this._password, value); }

		public bool IsGoingLogin { get => _isGoingLogin; set => this.Set(ref this._isGoingLogin, value); }

		#region Commands

		private RelayCommand _loginCommand;		

		public ICommand LoginCommand => this._loginCommand ?? (this._loginCommand = new RelayCommand(this.Login));

		private async void Login()
		{
			this.IsGoingLogin = true;

			await Task.Delay(1000);

			// TODO : login 처리.
			// login completed.
			var csvService = SimpleIoc.Default.GetInstance<ICsvService>();
			var records = csvService.Read<Member>("IOI.csv");

			var memberStore = SimpleIoc.Default.GetInstance<IMemberStoreService<Member>>();
			memberStore.Load(records);

			var arg = new LoginCompleted();
			Messenger.Default.Send(arg);

			this.IsGoingLogin = false;
		}

		#endregion
	}
}
