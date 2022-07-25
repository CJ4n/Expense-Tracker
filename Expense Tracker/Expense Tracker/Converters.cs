using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace Expense_Tracker
{
    public class CategorieConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cat = CategoryManager.GetCategories();
            var ret = new List<string>();
            foreach (var c in cat)
            {
                ret.Add(c.Name);
            }
            return ret;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class AccountConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var cat = AccountManager.GetAccounts();
            var ret = new List<string>();
            foreach (var c in cat)
            {
                ret.Add(c.AccountId);
            }
            return ret;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class PersonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //PeopleManager.CreatePeopleList();
            //List<string>
            //return Person.GetPerson();
            throw new NotImplementedException();

            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class BuyerIDConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = UserManager.GetUserById((int)value);
            return user.Name + " " + user.Surname;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
