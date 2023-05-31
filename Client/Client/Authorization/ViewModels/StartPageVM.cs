using Client.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Authorization.ViewModels
{
    public class StartPageVM : INotifyPropertyChanged
    {
        private RelayCommand _logIn;
        public RelayCommand LogIn
        {
            get
            {
                return _logIn ?? new RelayCommand(obj =>
                {
                    PageSwitch.SwitchToMainPage();
                });
            }
        }

        private RelayCommand _registration;
        public RelayCommand Registration
        {
            get
            {
                return _registration ?? new RelayCommand(obj =>
                {
                    PageSwitch.SwitchToRegistrationPage();
                });
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
