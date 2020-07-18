using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MemberManager.Common.Utils
{
	public class PropertyChangedNotifier : INotifyPropertyChanged
	{
		/// <summary>
		/// 변경통보 수동 호출을 위한 구문.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		protected bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
		{
			if (EqualityComparer<T>.Default.Equals(field, value))
			{
				return false;
			}

			field = value;

			this.OnPropertyChanged(propertyName);

			return true;
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
