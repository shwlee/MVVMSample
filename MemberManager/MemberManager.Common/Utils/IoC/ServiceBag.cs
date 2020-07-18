using GalaSoft.MvvmLight.Ioc;
using System;

namespace MemberManager.Common.Utils.IoC
{
	public static class ServiceBag
	{
		public static void Register<T>(Func<T> factory) where T : class
		{
			SimpleIoc.Default.Register(factory);
		}

		public static T Resolve<T>()
		{
			return SimpleIoc.Default.GetInstance<T>();
		}

		public static void Release<T>(T instance) where T : class
		{
			SimpleIoc.Default.Unregister(instance);
		}
	}
}
