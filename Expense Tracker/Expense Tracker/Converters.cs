using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Expense_Tracker
{
    public  class MethodToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,CultureInfo culture)
        {
            
            return Category.GetCategories();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("MethodToValueConverter can only be used for one way conversion.");
        }
    }
}
