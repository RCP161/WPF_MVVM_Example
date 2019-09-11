using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using Catel.MVVM.Converters;
using Company.App.Core.Models;

namespace Company.Project.UI.Converters
{
    public class SaveableVisibilityConverter : IValueConverter
    {

        private static SaveableVisibilityConverter _instance;
        public static SaveableVisibilityConverter Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new SaveableVisibilityConverter();

                return _instance;
            }
        }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is IEditable)
                return Visibility.Visible;

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
