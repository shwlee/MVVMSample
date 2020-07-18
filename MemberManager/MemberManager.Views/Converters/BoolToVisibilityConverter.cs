using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MemberManager.Views.Converters
{
	public class BoolToVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var boolean = (bool)value;

			return boolean ? Visibility.Visible : Visibility.Collapsed;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var visible = (Visibility)value;

			return visible == Visibility.Visible;
		}
	}
}
