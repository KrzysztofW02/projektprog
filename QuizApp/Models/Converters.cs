using System;
using Avalonia.Data;
using Avalonia.Data.Converters;
using System.Globalization;
using Avalonia.Controls;
using Avalonia;

namespace QuizApp.Models
{
    public class RadioButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedOption = value as string;
            string radioButtonContent = parameter as string;

            // Jeśli zaznaczono tę opcję, zwracamy wartość, która będzie wskazywać na zaznaczenie RadioButton
            return selectedOption == radioButtonContent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isChecked = (bool)value;
            string radioButtonContent = parameter as string;

            // Jeśli RadioButton jest zaznaczony, zwracamy wartość odpowiadającą jego treści
            if (isChecked)
                return radioButtonContent;

            return null;
        }
    }




        public class BooleanToIsVisibleConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool boolValue)
                {
                    return boolValue ? AvaloniaProperty.UnsetValue : false;
                }
                return AvaloniaProperty.UnsetValue;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

        public class InverseBooleanConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value is bool boolValue)
                {
                    return !boolValue;
                }
                return false;
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }

    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? AvaloniaProperty.UnsetValue : false;
            }
            return AvaloniaProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
