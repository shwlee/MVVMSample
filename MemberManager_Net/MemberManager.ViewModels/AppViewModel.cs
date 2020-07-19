using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MemberManager.Defines.Classes.Messaging;
using MemberManager.Defines.Interfaces;
using MemberManager.Models;

namespace MemberManager.ViewModels
{
	public class AppViewModel : ObservableObject
	{
		private object _currentContext;

		public object CurrentContext 
		{ 
			get => _currentContext;
			set => this.Set(ref this._currentContext, value);
		}

		public AppViewModel()
		{
			this.Init();
		}

		private void Init()
		{
			Messenger.Default.Register<LoginCompleted>(this, this.SetMain);
			Messenger.Default.Register<LogoutCompleted>(this, this.SetLogin);
		}

		private void SetLogin(LogoutCompleted obj)
		{
			var login= new LoginViewModel();
			this.CurrentContext = login;
		}

		private void SetMain(LoginCompleted obj)
		{
			var memberStore = SimpleIoc.Default.GetInstance<IMemberStoreService<Member>>();
			var members = memberStore.GetAllMemebers();
			
			var main = new MainViewModel();
			main.NamePane.Init(members);
			
			this.CurrentContext = main;
		}
	}
}
