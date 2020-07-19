using GalaSoft.MvvmLight.Messaging;
using MemberManager.Common.Utils;
using MemberManager.Common.Utils.IoC;
using MemberManager.Defines.Classes;
using MemberManager.Defines.Interfaces;

namespace MemberManager.ViewModels
{
	public class AppViewModel : PropertyChangedNotifier
	{
		private object _currentContext;

		public object CurrentContext
		{
			get => _currentContext;
			set => this.Set(ref this._currentContext, value);
		}

		public AppViewModel()
		{
			this.InitMessages();
		}

		private void InitMessages()
		{
			Messenger.Default.Register<LoginCompleted>(this, this.SetMembers);
			Messenger.Default.Register<Logout>(this, this.BackToInitialize);
		}

		private void BackToInitialize(Logout obj)
		{
			// TODO : viewModelLocator 사용.
			var login = new LoginViewModel();
			this.CurrentContext = login;

			var memberStore = ServiceBag.Resolve<IMemberStoreService>();
			memberStore.ClearMembers();
		}

		private void SetMembers(LoginCompleted obj)
		{
			// TODO : viewModelLocator 사용.
			var memberList = new MemberListViewModel();
			memberList.Load();

			this.CurrentContext = memberList;
		}
	}
}
