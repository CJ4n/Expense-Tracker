using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

// TODO:
// jakis mądry spsob na wyświetalnie listy kategori itd i potem łatwy spsoób na sprawdzene co jest wybranie (jakiś binding do czegoś, ale do czego i żeby ładnie było)
namespace Expense_Tracker
{


    public static class tmp
    {
        public static MainWindow win;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Account> accountsList;
        private List<Category> categoriesList;
        private List<Transaction> transactionsList;
        private List<User> usersList;

        public List<Account> AccountList { get { return accountsList; } }
        public List<Category> CategoriesList { get { return categoriesList; } }
        public List<Transaction> TransactionsList { get { return transactionsList; } }
        public List<User> UsersList { get { return usersList; } }
        private void InitializeData()
        {
            usersList = UserManager.GetUsers();
            accountsList = AccountManager.GetAccounts();
            categoriesList = CategoryManager.GetCategories();
            transactionsList = TransactionManager.GetTransactions();
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            //var a = Category.GetCategories();
            //var b = SQL.GetPerson();
            int xx;
            tmp.win = this;
            this.DataContext = this;
            //test();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var ret = tmp.win.accountBox.SelectedValue;

        }
    }

}
