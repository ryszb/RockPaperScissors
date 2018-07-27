using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using RockPaperScissors.Logic.Core;

namespace RockPaperScissors.UI.Common
{
    public class GestureToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var gesture = value as Gesture;

            return gesture == null ? null : Application.Current.Resources[$"{gesture.Name}Icon"] as ImageSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
