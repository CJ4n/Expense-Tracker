using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Expense_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Account> accountsList;
        private ObservableCollection<Category> categoriesList;
        private ObservableCollection<Transaction> transactionsList;
        private ObservableCollection<User> usersList;

        public ObservableCollection<Account> AccountList { get { return accountsList; } }
        public ObservableCollection<Category> CategoryList { get { return categoriesList; } }
        public ObservableCollection<Transaction> TransactionsList { get { return transactionsList; } }
        public ObservableCollection<User> UsersList { get { return usersList; } }
        private void InitializeData()
        {
            usersList = UserManager.GetUsers();
            accountsList = AccountManager.GetAccounts();
            categoriesList = CategoryManager.GetCategories();
            transactionsList = TransactionManager.GetTransactions();
        }

        public MainWindow()
        {
            InitializeData();
            InitializeComponent();
            this.DataContext = this;
        }

        private void ButtonAddTransction_Click(object sender, RoutedEventArgs e)
        {
            if (this.accountComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an account");
                return;
            }
            if (this.categoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an category");
                return;
            }
            if (this.amountTextBox.Text == "")
            {
                MessageBox.Show("Please enter amount of money");
                return;
            }
            int amount;
            int.TryParse(this.descriptionTextBox.Text, out amount);
            string transactionType = "Expense";
            if (this.RadioButtonExpense.IsChecked == false)
                transactionType = "Income";

            SQL.AddTransaction(((Account)this.accountComboBox.SelectedItem).AccountId, (DateTime)this.datePicker.SelectedDate, amount,
                 (Category)this.categoryComboBox.SelectedItem, this.descriptionTextBox.Text, 1/*TODO: add option to choce person*/, transactionType);

        }
    }

}
