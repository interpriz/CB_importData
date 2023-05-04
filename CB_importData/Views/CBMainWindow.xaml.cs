using CB_importData.Services;
using CB_importData.ViewModels;
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
    /// Логика взаимодействия для CBMainWindow.xaml
    /// </summary>
    public partial class CBMainWindow : Window
    {
        public CBMainWindow()
        {
            InitializeComponent();
            DataContext = new CBViewmodel(new DefaultDialogService(), new XMLED807FileService());
        }
    }
}
