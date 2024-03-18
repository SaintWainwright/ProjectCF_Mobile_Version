using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class MainPage_VM : MainViewModel
    {
        private void GoToLoginPage()
        {
            Shell.Current.GoToAsync(nameof(LoginPage), false);
        }
        public ICommand GoToLoginPageCommand => new Command(GoToLoginPage);
    }
}
