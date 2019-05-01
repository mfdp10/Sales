﻿namespace Sales.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string ConnectionError1
        {
            get { return Resource.ConnectionError1; }
        }

        public static string ConnectionError2
        {
            get { return Resource.ConnectionError2; }
        }

        public static string Products
        {
            get { return Resource.Products; }
        }

        public static string Description
        {
            get { return Resource.Description; }
        }

        public static string DescriptionPH
        {
            get { return Resource.DescriptionPH; }
        }

        public static string Price
        {
            get { return Resource.Price; }
        }

        public static string PricePH
        {
            get { return Resource.PricePH; }
        }

        public static string Remarks
        {
            get { return Resource.Remarks; }
        }

        public static string RemarksPH
        {
            get { return Resource.RemarksPH; }
        }

        public static string Save
        {
            get { return Resource.Save; }
        }

        public static string ChangeImage
        {
            get { return Resource.ChangeImage; }
        }

        public static string DescriptionError
        {
            get { return Resource.DescriptionError; }
        }

        public static string PriceError
        {
            get { return Resource.PriceError; }
        }

        public static string ImageSource
        {
            get { return Resource.ImageSource; }
        }

        public static string FromGallery
        {
            get { return Resource.FromGallery; }
        }

        public static string NewPicture
        {
            get { return Resource.NewPicture; }
        }

        public static string Cancel
        {
            get { return Resource.Cancel; }
        }

        public static string Delete
        {
            get { return Resource.Delete; }
        }

        public static string Edit
        {
            get { return Resource.Edit; }
        }

        public static string DeleteConfirmation
        {
            get { return Resource.DeleteConfirmation; }
        }

        public static string Yes
        {
            get { return Resource.Yes; }
        }

        public static string No
        {
            get { return Resource.No; }
        }

        public static string Confirm
        {
            get { return Resource.Confirm; }
        }

        public static string EditProduct
        {
            get { return Resource.EditProduct; }
        }

        public static string IsAvailable
        {
            get { return Resource.IsAvailable; }
        }

        public static string Search
        {
            get { return Resource.Search; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string Email
        {
            get { return Resource.Email; }
        }

        public static string EmailPH
        {
            get { return Resource.EmailPH; }
        }

        public static string Password
        {
            get { return Resource.Password; }
        }

        public static string PasswordPH
        {
            get { return Resource.PasswordPH; }
        }

        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

        public static string Forgot
        {
            get { return Resource.Forgot; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string SomethingWrong
        {
            get { return Resource.SomethingWrong; }
        }

        public static string Menu
        {
            get { return Resource.Menu; }
        }

        public static string About
        {
            get { return Resource.About; }
        }

        public static string Setup
        {
            get { return Resource.Setup; }
        }

        public static string Exit
        {
            get { return Resource.Exit; }
        }
        
        public static string NoProductsMessage
        {
            get { return Resource.NoProductsMessage; }
        }

        public static string FirstName
        {
            get { return Resource.FirstName; }
        }

        public static string LastName
        {
            get { return Resource.LastName; }
        }

        public static string Phone
        {
            get { return Resource.Phone; }
        }

        public static string Address
        {
            get { return Resource.Address; }
        }

        public static string FirstNamePH
        {
            get { return Resource.FirstNamePH; }
        }

        public static string LastNamePH
        {
            get { return Resource.LastNamePH; }
        }

        public static string PhonePH
        {
            get { return Resource.PhonePH; }
        }

        public static string AddressPH
        {
            get { return Resource.AddressPH; }
        }

        public static string PasswordConfirm
        {
            get { return Resource.PasswordConfirm; }
        }

        public static string PasswordConfirmPH
        {
            get { return Resource.PasswordConfirmPH; }
        }

        public static string FirstNameError
        {
            get { return Resource.FirstNameError; }
        }

        public static string LastNameError
        {
            get { return Resource.LastNameError; }
        }

        public static string EmailError
        {
            get { return Resource.EmailError; }
        }

        public static string PhoneError
        {
            get { return Resource.PhoneError; }
        }

        public static string PasswordError
        {
            get { return Resource.PasswordError; }
        }

        public static string PasswordConfirmError
        {
            get { return Resource.PasswordConfirmError; }
        }

        public static string PasswordNoMatch
        {
            get { return Resource.PasswordNoMatch; }
        }

        public static string RegisterConfirmation
        {
            get { return Resource.RegisterConfirmation; }
        }

        public static string Categories
        {
            get { return Resource.Categories; }
        }

        public static string Category
        {
            get { return Resource.Category; }
        }

        public static string CategoryError
        {
            get { return Resource.CategoryError; }
        }

        public static string CategoryPH
        {
            get { return Resource.CategoryPH; }
        }
    }
}
