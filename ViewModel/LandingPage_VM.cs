﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class LandingPage_VM : ObservableObject
    {
        public LandingPage_VM()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
        }
        [ObservableProperty]
        private Employee currentEmployee;

        [RelayCommand]
        private async Task GoToViewSalary() => await Shell.Current.GoToAsync(nameof(ViewSalary), false);
        [RelayCommand]
        private async Task GoToViewProfile() => await Shell.Current.GoToAsync(nameof(ViewProfile), false);
        [RelayCommand]
        private async Task GoToWorktime() => await Shell.Current.GoToAsync(nameof(Worktime), false);
        [RelayCommand]
        private async Task GoToMessaging() => await Shell.Current.GoToAsync(nameof(Messaging), false);
        [RelayCommand]
        private async Task Logout()
        {
            if(await Shell.Current.DisplayAlert("Logout", "Are you sure you want to logout?", "Yes", "No"))
            {
                Preferences.Clear();
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}", false);
            }
        }

        public void OnAppearing() => CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
    }
}
