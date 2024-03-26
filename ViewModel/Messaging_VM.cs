using ProjectCF_Mobile_Version.Model;
using ProjectCF_Mobile_Version.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.ViewModel
{
    public partial class Messaging_VM : LandingPage_VM
    {
        public Messaging_VM() 
        {
            message_Services = new Message_Services();
            InitializeMessageList();
        }
        private readonly Message_Services message_Services;
        private ObservableCollection<Message> messageList;
        public ObservableCollection<Message> MessageList
        {
            get { return messageList; }
            set { messageList = value; OnPropertyChanged(); OnPropertyChanged(nameof(messageList)); }
        }
        private void InitializeMessageList()
        {
            foreach (var message in message_Services.GetMessages()) 
            {
                if(CurrentEmployee.EmployeeID == message.Sender.EmployeeID || CurrentEmployee.EmployeeID == message.Receiver.EmployeeID) 
                {
                    MessageList.Add(message);
                }
            }
        }
    }
}
