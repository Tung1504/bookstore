using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace bookstore.ViewModels.Auth
{
    public class LoginSignUpViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }

        public SignupViewModel SignupViewModel { get; set; }

        public LoginSignUpViewModel()
        {

        }

        public LoginSignUpViewModel(LoginViewModel loginViewModel, SignupViewModel signupViewModel)
        {
            LoginViewModel = loginViewModel;
            SignupViewModel = signupViewModel;
        }
    }
}