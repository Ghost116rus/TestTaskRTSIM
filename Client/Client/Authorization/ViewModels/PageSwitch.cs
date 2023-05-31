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
        private static MainPage _mainPage;
        private static AdditionalPage _additionalPage;

        public PageSwitch(Window wnd, Frame frame, MainPage mainPage, AdditionalPage additionalPage)
        {
            _wnd = wnd;
            _frame = frame;
            _mainPage = mainPage;
            _additionalPage = additionalPage;
        }

        public static void SwitchToMainPage()
        {
            _frame.Content = _mainPage;
        }
        public static void SwitchToAdditionalPage()
        {
            _frame.Content = _additionalPage;
        }
        public static void OpenMainWindow()
        {
            Window window = new MainAppWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            _wnd.Close();
        }
    }
}
