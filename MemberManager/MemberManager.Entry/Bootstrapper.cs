using GalaSoft.MvvmLight.Messaging;
using MemberManager.Common.Utils.IoC;
using MemberManager.Defines.Interfaces;
using MemberManager.Services;
using MemberManager.Services.Utils;

namespace MemberManager.Entry
{
	public static class Bootstrapper
	{
		public static void Init()
		{
			InitServices();
		}

		private static void InitServices()
		{
			ServiceBag.Register<ICsvService>(() =>
			{
				return new CsvService();
			});
			ServiceBag.Register<IMemberStoreService>(() =>
			{
				return new MemberStoreService();
			});
		}
	}
}
