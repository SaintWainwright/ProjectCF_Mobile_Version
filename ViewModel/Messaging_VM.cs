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
    [QueryProperty(nameof(EmployeeID), "id")]
    public partial class Messaging_VM : MainViewModel
    {
        public Messaging_VM() 
        {
            message_Services = new Message_Services();
            employee_Services = new Employee_Services();
            MessageList = new ObservableCollection<Message>();
        }
        private readonly Message_Services message_Services;
        private readonly Employee_Services employee_Services;
        private ObservableCollection<Message> messageList;
        public ObservableCollection<Message> MessageList
        {
            get { return messageList; }
            set { messageList = value; OnPropertyChanged(); OnPropertyChanged(nameof(messageList)); }
        }
        private string _EmployeeID;
        public string EmployeeID
        {
            get { return _EmployeeID; }
            set
            {
                _EmployeeID = value; OnPropertyChanged(); OnPropertyChanged(nameof(_EmployeeID)); InitializeMessageList();
            }
        }
        public void InitializeMessageList()
        {
            MessageList = new ObservableCollection<Message>();
            foreach (var message in message_Services.GetMessages().Reverse()) 
            {
                if(message.Sender.EmployeeID ==  EmployeeID || message.Receiver.EmployeeID == EmployeeID) 
                {
                    MessageList.Add(message);
                }
            }
        }
        private void GoToWriteMessage()
        {
            Shell.Current.GoToAsync($"{nameof(WriteMessage)}?id={EmployeeID}");
        }
        public ICommand GoToWriteMessageCommand => new Command(GoToWriteMessage);
    }
}
