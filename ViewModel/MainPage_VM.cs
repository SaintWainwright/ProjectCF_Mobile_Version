using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.View;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class MainPage_VM : ObservableObject
    {
        public MainPage_VM() 
        {
            Preferences.Default.Remove("employeeID");
        }
        [RelayCommand]
        private void GoToLoginPage() =>  Shell.Current.GoToAsync(nameof(LoginPage), false);
    }
}
