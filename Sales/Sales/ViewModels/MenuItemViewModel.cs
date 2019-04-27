﻿namespace Sales.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;
    using Helpers;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand GotoCommand
        {
            get
            {
                return new RelayCommand(Goto);
            }
        }

        private void Goto()
        {
            //App.Master.IsPresented = false;

            if (this.PageName == "LoginPage")
            {
                Settings.AccessToken = string.Empty;
                Settings.TokenType = string.Empty;
                Settings.IsRemembered = false;

                MainViewModel.GetInstance().Login = new LoginViewModel(); ;
                Application.Current.MainPage = new NavigationPage(
                    new LoginPage());
            }
            //else if (this.PageName == "MyProfilePage")
            //{
            //    MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
            //    App.Navigator.PushAsync(new MyProfilePage());
            //}
        }
        #endregion
    }
}