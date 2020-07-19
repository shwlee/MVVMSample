using MemberManager.ViewModels;
using System.Windows;

namespace MemberManager
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
			//var csvService = new CsvService();
			//var records = csvService.Read<Member>("IOI.csv");

			var appViewModel = new AppViewModel();
			appViewModel.CurrentContext = new LoginViewModel();

			var mainWindow = new MainWindow();
			mainWindow.DataContext = appViewModel;
			
			mainWindow.Show();
		}
	}
}
