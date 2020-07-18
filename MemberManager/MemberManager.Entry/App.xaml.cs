using MemberManager.Common.Utils.IoC;
using MemberManager.Defines.Interfaces;
using MemberManager.Models;
using MemberManager.ViewModels;
using System.Windows;

namespace MemberManager.Entry
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			Bootstrapper.Init();
		}

		protected override void OnStartup(StartupEventArgs e)
		{
			var login = new LoginViewModel();
			var appViewModel = new AppViewModel();
			appViewModel.CurrentContext = login;

			var mainWindow = new MainWindow();
			mainWindow.DataContext = appViewModel;
			mainWindow.Show();			
		}
	}
}
