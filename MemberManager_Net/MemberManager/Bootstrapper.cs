using GalaSoft.MvvmLight.Ioc;
using MemberManage.Services;
using MemberManager.Defines.Interfaces;
using MemberManager.Models;

namespace MemberManager
{
	public static class Bootstrapper
	{
		public static void Init()
		{
			SimpleIoc.Default.Register<IMemberStoreService<Member>>(() => new MemberStoreService());
			SimpleIoc.Default.Register<ICsvService>(() => new CsvService());
		}
	}
}
