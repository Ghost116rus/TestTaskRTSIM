using Client.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.MainAplication.ViewModels
{
    public class MainAppVm : INotifyPropertyChanged
    {
        private RelayCommand? _exit;
        public RelayCommand Exit
        {
            get
            {
                return _exit ?? new RelayCommand(obj =>
                {
                    StartWindow authorizationWindow = new StartWindow();
                    authorizationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    authorizationWindow.Show();
                    _wnd.Close();
                });
            }
        }
        private Window _wnd;
        public MainAppVm(Window wnd)
        {
            _wnd = wnd;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
