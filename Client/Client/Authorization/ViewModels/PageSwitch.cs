using Client.Authorization.Views.Pages;
using Client.MainAplication;
using Client.Views.Authorization.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client.Authorization.ViewModels
{
    public class PageSwitch
    {
        private static Window _wnd;
        private static Frame _frame;

        private static StartPage _startPage;
        private static MainPage _mainPage;
        private static AdditionalPage _additionalPage;
        private static RegistrationPage _registrationPage;

        public PageSwitch(Window wnd, Frame frame, StartPage startPage, MainPage mainPage, AdditionalPage additionalPage, RegistrationPage registrationPage)
        {
            _wnd = wnd;
            _frame = frame;

            _startPage = startPage;

            _mainPage = mainPage;
            _additionalPage = additionalPage;
            _registrationPage = registrationPage;
        }

        public static void SwitchToStartPage()
        {
            _frame.Content = _startPage;
        }

        public static void SwitchToMainPage()
        {
            _frame.Content = _mainPage;
        }
        public static void SwitchToAdditionalPage()
        {
            _frame.Content = _additionalPage;
        }

        public static void SwitchToRegistrationPage()
        {
            _frame.Content = _registrationPage;
        }

        public static void OpenMainWindow(int userId)
        {
            Window window = new MainAppWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            _wnd.Close();
        }
    }
}
