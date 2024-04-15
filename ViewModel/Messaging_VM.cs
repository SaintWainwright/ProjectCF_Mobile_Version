using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using ProjectCF_Mobile_Version.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class Messaging_VM : LandingPage_VM
    {
        public Messaging_VM() 
        {
            message_Services = new Message_Services();
            employee_Services = new Employee_Services();
            MessageList = new ObservableCollection<Message>();
            InitializeCurrentEmployee();
            InitializeMessageList();
        }
        private readonly Message_Services message_Services;
        private readonly Employee_Services employee_Services;
        private ObservableCollection<Message> messageList;
        public ObservableCollection<Message> MessageList
        {
            get { return messageList; }
            set { messageList = value; OnPropertyChanged(); OnPropertyChanged(nameof(messageList)); }
        }
        private Message selectedMessage;
        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set
            {
                selectedMessage = value; OnPropertyChanged(); OnPropertyChanged(nameof(selectedMessage)); GoToViewMessage();
            }
        }
        private void GoToViewMessage()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "selectedmessage", SelectedMessage }
            };
            Shell.Current.GoToAsync($"{nameof(ViewMessage)}", navigationParameter);
        }
        private void InitializeMessageList()
        {
            MessageList = new ObservableCollection<Message>();
            foreach (var message in message_Services.GetMessages().Reverse()) 
            {
                if(message.Sender.EmployeeID ==  CurrentEmployee.EmployeeID || message.Receiver.EmployeeID == CurrentEmployee.EmployeeID) 
                {
                    MessageList.Add(message);
                }
            }
        }
        private void GoToWriteMessage()
        {
            Shell.Current.GoToAsync(nameof(WriteMessage), false);
        }
        public ICommand GoToWriteMessageCommand => new Command(GoToWriteMessage);
    }
}
