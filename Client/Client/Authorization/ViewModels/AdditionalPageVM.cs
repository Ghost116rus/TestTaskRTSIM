using Client.Authorization.Http;
using Client.Authorization.Models;
using Client.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Net.WebRequestMethods;

namespace Client.Authorization.ViewModels
{
    public class AdditionalPageVM : INotifyPropertyChanged
    {
        #region Свойства

        private string errorlog;
        public string Errorlog
        {
            get { return errorlog; }
            set { errorlog = value; NotifyPropertyChanged("Errorlog"); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; Errorlog = ""; NotifyPropertyChanged("Password"); }
        }


        private List<Organization> _organizations;
        public List<Organization> Organizations { get { return _organizations; } }


        private List<string>? _logins;
        public List<string>? Logins { get { return _logins; } set { _logins = value; } }



        private Organization? _selectedOrganization;
        public Organization? SelectedOrganization 
        { 
            get { return _selectedOrganization; }
            set 
            { 
                _selectedOrganization = value;
                SelectedLogin = null;

                Logins = _selectedOrganization != null ? MyHttpClient.GetLoginsByOrganizationId(_selectedOrganization.Id) : null;

                if (Logins is null)
                {
                    Errorlog = "У данной организации нет логинов!";
                    _loginsCombobox.IsEnabled = false;
                } else
                {                    
                    _loginsCombobox.IsEnabled = true;
                }

                NotifyPropertyChanged(nameof(Logins));
            }
        }

        private string? _selectedLogin;
        public string? SelectedLogin
        {
            get { return _selectedLogin; }
            set 
            { 
                _selectedLogin = value;
                Password = ""; 
                NotifyPropertyChanged(nameof(SelectedLogin));
                _passwordField.IsEnabled = _selectedLogin != null ?  true :  false;
            }
        }



        #endregion

        #region Команды

        private RelayCommand? _toMainPage;
        public RelayCommand ToMainPage
        {
            get
            {
                return _toMainPage ?? new RelayCommand(obj =>
                {
                    SelectedOrganization = null;
                    _organizationsCombobox.SelectedIndex = -1;
                    Errorlog = "";
                    PageSwitch.SwitchToMainPage();
                });
            }
        }

        private RelayCommand _authorize;
        public RelayCommand Authorize
        {
            get
            {
                return _authorize ?? new RelayCommand(obj =>
                {
                    var result = MyHttpClient.Authorize(SelectedLogin, Password);

                    if (result)
                    {
                        PageSwitch.OpenMainWindow();
                    }

                    if (!result)
                    {
                        Errorlog = "Неверный логин или пароль";
                    }
                }, e => Password != ""
                );
            }
        }

        #endregion

        private ComboBox _organizationsCombobox;
        private ComboBox _loginsCombobox;
        private TextBox _passwordField;

        public AdditionalPageVM(ComboBox organizations, ComboBox loginsComboBox, TextBox passwordField)
        {
            errorlog = "";
            password = "";
            _organizations = MyHttpClient.GetOrganizations();

            _organizationsCombobox = organizations;
            _loginsCombobox = loginsComboBox;
            _passwordField = passwordField;

        }



        public event PropertyChangedEventHandler? PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
