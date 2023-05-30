using Client.Authorization.ViewModels;
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

namespace Client.Views.Authorization.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdditionalPage.xaml
    /// </summary>
    public partial class AdditionalPage : Page
    {
        public AdditionalPage()
        {
            InitializeComponent();
            DataContext = new AdditionalPageVM(this.Logins, this.PasswordField);
        }
    }
}
