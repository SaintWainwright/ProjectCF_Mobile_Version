using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.View;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class MainPage_VM : ObservableObject
    {
        [RelayCommand]
        private void GoToLoginPage() =>  Shell.Current.GoToAsync(nameof(LoginPage), false);
    }
}
