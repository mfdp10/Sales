namespace Sales.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.Collections.ObjectModel;
    using System;
    using Sales.Helpers;
    using Sales.Common.Models;

    public class MainViewModel
    {
        #region Properties
        public RegisterViewModel Register { get; set; }
        public LoginViewModel Login { get; set; }
        public EditProductViewModel EditProduct { get; set; }
        public ProductsViewModel Products { get; set; }
        public AddProductViewModel AddProduct { get; set; }
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        public MyUserASP UserASP { get; set; }
        public string UserFullName
        {
            get
            {
                if (this.UserASP != null && this.UserASP.Claims != null && this.UserASP.Claims.Count > 1)
                {
                    return $"{this.UserASP.Claims[0].ClaimValue} {this.UserASP.Claims[1].ClaimValue}";
                }
                return null;
            }
        }
        public string UserImageFullPath
        {
            get
            {
                //si escribio direccion hay 4 claims
                if (this.UserASP != null && this.UserASP.Claims != null && this.UserASP.Claims.Count > 3)
                {
                    return $"http://www.negrisl.es/sales.api{this.UserASP.Claims[3].ClaimValue.Substring(1)}";
                }

                //si no escribio direccion hay 3 claims
                if (this.UserASP != null && this.UserASP.Claims != null && this.UserASP.Claims.Count > 2)
                {
                    return $"http://www.negrisl.es/sales.api{this.UserASP.Claims[2].ClaimValue.Substring(1)}";
                }
                return null;
            }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.LoadMenu();
            // this.Products = new ProductsViewModel();
        }

        #endregion

        #region Commands
        public ICommand AddProductCommand
        {
            get
            {
                return new RelayCommand(GoToAddProduct);
            }
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion


        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_info",
                PageName = "AboutPage",
                Title = Languages.About,
            });

            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_phonelink_setup",
                PageName = "SetupPage",
                Title = Languages.Setup,
            });

            this.Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.Exit,
            });
        }

        private async void GoToAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        }
        #endregion
    }
}
