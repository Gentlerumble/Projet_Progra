using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;


namespace Projet_Progra
{
    class TaskToTextDecorationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isDone = (bool)value;
            string mode = parameter as string;

            if(mode == "Decoration")
                return isDone ? TextDecorations.Strikethrough : null;

            if(mode == "Color")
                return isDone ? Brushes.Gray : Brushes.Black;
            
            return Brushes.Black;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
