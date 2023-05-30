using Client.Common;
using System.ComponentModel;


namespace Client.Authorization.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        #region Свойства

        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; NotifyPropertyChanged("Login"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; NotifyPropertyChanged("Password"); }
        }

        private string errorlog;
        public string Errorlog
        {
            get { return errorlog; }
            set { errorlog = value; NotifyPropertyChanged("Errorlog"); }
        }

        #endregion


        #region Команды

        private RelayCommand? _authorize;
        public RelayCommand Authorize
        {
            get
            {
                return _authorize ?? new RelayCommand(obj =>
                {
                    Errorlog = "Работает однако!";
                }, e => Password != "" && Login != "");
            }
        }

        private RelayCommand? _toAdditinalPage;
        public RelayCommand ToAdditionalPage
        {
            get
            {
                return _toAdditinalPage ?? new RelayCommand(obj =>
                {
                    PageSwitch.SwitchToAdditionalPage();
                });
            }
        }

        #endregion

        public MainPageVM()
        {
            login = "";
            password = "";
            errorlog = "";
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
