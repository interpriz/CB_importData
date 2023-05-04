using CB_importData.Models;
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
using System.Windows.Shapes;

namespace CB_importData.Views
{
    /// <summary>
    /// Логика взаимодействия для AccountsWindow.xaml
    /// </summary>
    public partial class AccountsWindow : Window
    {
        public List<Accounts> Accounts { get; private set; }
        public AccountsWindow(List<Accounts> accounts)
        {
            InitializeComponent();
            Accounts = accounts;
            DataContext = Accounts;
        }
    }
}
