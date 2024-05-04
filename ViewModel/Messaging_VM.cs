using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System.Collections.ObjectModel;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class Messaging_VM : LandingPage_VM
    {
        private readonly Message_Services message_Services;
        private readonly Employee_Services employee_Services;
        public Messaging_VM()
        {
            message_Services = new Message_Services();
            employee_Services = new Employee_Services();
            CurrentEmployee = employee_Services.InitializeCurrentEmployee();
            MessageList = [];
        }
        [ObservableProperty]
        private ObservableCollection<Message> messageList;
        partial void OnMessageListChanged(ObservableCollection<Message> value)
        {
            if(!MessageList.Any())
            {
                MessageList = message_Services.EmployeeMessageList(CurrentEmployee);
            }
        }
        [ObservableProperty]
        private Message selectedMessage;
        partial void OnSelectedMessageChanged(Message value)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "selectedmessage", value }
            };
            value.Tag = 1; //Changes tag to READ
            message_Services.UpdateMessageCollection(value);
            Shell.Current.GoToAsync($"{nameof(ViewMessage)}", navigationParameter);
        }
        [RelayCommand]
        private void GoToWriteMessage()
        {
            Shell.Current.GoToAsync(nameof(WriteMessage), false);
        }
    }
}
