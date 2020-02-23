using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FirstFloor.ModernUI.Windows.Converters
{
	/// <summary>
	/// Converts a null or empty enumerable/collection value to Visibility.Visible and any other value to Visibility.Collapsed
	/// </summary>
	public class NullOrEmptyToVisibilityConverter : IValueConverter
	{
		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			bool flag = false;

			if (value == null) flag = true;
			else if (value.GetType().GetProperty("Count") != null) flag = ((dynamic)value).Count == 0;
			else if (value.GetType().GetProperty("Length") != null) flag = ((dynamic)value).Length == 0;

			var inverse = (parameter as string) == "inverse";

			if (inverse)
			{
				return (flag ? Visibility.Collapsed : Visibility.Visible);
			}
			else
			{
				return (flag ? Visibility.Visible : Visibility.Collapsed);
			}
		}

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}
