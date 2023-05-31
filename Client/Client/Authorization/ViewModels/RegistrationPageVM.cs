using Client.Authorization.Http;
using Client.Authorization.Models;
using Client.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Authorization.ViewModels
{
    public class RegistrationPageVM : INotifyPropertyChanged
    {
        #region Свойства

        private string errorlog;
        public string Errorlog
        {
            get { return errorlog; }
            set { errorlog = value; NotifyPropertyChanged("Errorlog"); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; Errorlog = ""; NotifyPropertyChanged("Name"); }
        }

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


        private List<Organization> _organizations;
        public List<Organization> Organizations { get { return _organizations; } }


        private Organization? _selectedOrganization;
        public Organization? SelectedOrganization
        {
            get { return _selectedOrganization; }
            set
            {
                _selectedOrganization = value;
                Errorlog = "";
            }
        }
        
        #endregion

        #region Команды

        private RelayCommand _registre;
        public RelayCommand Registre
        {
            get
            {
                return _registre ?? new RelayCommand(obj =>
                {
                    var result = MyHttpClient.Registre(_selectedOrganization.Id, name, login, password);

                    if (result.Success)
                    {
                        PageSwitch.OpenMainWindow(result.UserId);
                    }

                    if (!result.Success)
                    {
                        Errorlog = result.Message;
                    }
                }, e => _selectedOrganization != null && name != "" && login != "" && password != "" 
                );
            }
        }

        private RelayCommand? _back;
        public RelayCommand BackToStartPage
        {
            get
            {
                return _back ?? new RelayCommand(obj =>
                {
                    PageSwitch.SwitchToStartPage();
                });
            }
        }



        #endregion

        public RegistrationPageVM(List<Organization> OrganizationsList)
        {
            _organizations = OrganizationsList;

            name = "";
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
