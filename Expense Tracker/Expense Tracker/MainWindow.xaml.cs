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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
   
        public MainWindow()
        {
       
            InitializeComponent();
            var a = Category.GetCategories();
            var b = SQL.GetPerson();
            int xx;
        }
    }
   
}
