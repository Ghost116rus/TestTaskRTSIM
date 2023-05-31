using Client.Authorization.Http;
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
            set { login = value; Errorlog = ""; NotifyPropertyChanged("Login"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; Errorlog = ""; NotifyPropertyChanged("Password"); }
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
                    var result = MyHttpClient.Authorize(Login, Password);

                    if (result)
                    {
                        PageSwitch.OpenMainWindow();
                    }

                    if (!result)
                    {
                        Errorlog = "Неверный логин или пароль";
                    }

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
