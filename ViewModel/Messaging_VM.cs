﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System.Collections.ObjectModel;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class Messaging_VM : ObservableObject
    {
        [ObservableProperty]
        private Employee currentEmployee;
        [ObservableProperty]
        private ObservableCollection<Message> messageList;
        [ObservableProperty]
        private Message selectedMessage;
        partial void OnSelectedMessageChanged(Message value)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "selectedmessage", value } 
            };
            if(value.Receiver.EmployeeID == CurrentEmployee.EmployeeID)
            {
                value.Tag = 1; //Changes tag to READ
                Message_Services.UpdateMessageCollection(value);
            }
            Shell.Current.GoToAsync($"{nameof(ViewMessage)}", navigationParameter);
        }
        
        [RelayCommand]
        private void GoToWriteMessage() => Shell.Current.GoToAsync(nameof(WriteMessage), false);
        public void OnAppearing()
        {
            CurrentEmployee = Employee_Services.InitializeCurrentEmployee();
            MessageList = Message_Services.EmployeeMessageList(CurrentEmployee);
        }
        public void OnDisappearing()
        {
            SelectedMessage = null;
        }
    }
}
