using ProjectCF_Mobile_Version.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.Model
{
    public class Message : MainViewModel
    {
        private Employee sender = new();
        private Employee receiver = new();
        private string subject;
        private string messageText;
        private int tag;
        private DateTime timeSent;

        public Employee Sender 
        { 
            get { return sender; }
            set { sender = value; OnPropertyChanged(); OnPropertyChanged(nameof(sender)); }
        }
        public Employee Receiver
        {
            get { return receiver; }
            set { receiver = value; OnPropertyChanged(); OnPropertyChanged(nameof(receiver)); }
        }
        public string Subject
        {
            get { return subject; }
            set { subject = value; OnPropertyChanged(); OnPropertyChanged(); }
        }
        public string MessageText 
        { 
            get { return messageText; }
            set {  messageText = value; OnPropertyChanged(); OnPropertyChanged(nameof(messageText));  }
        }
        public int Tag
        {
            get { return tag; }
            set { tag = value; OnPropertyChanged(); OnPropertyChanged(nameof(tag)); }
        }
        public DateTime TimeSent
        {
            get { return timeSent; }
            set { timeSent = value; OnPropertyChanged(); OnPropertyChanged(nameof(timeSent)); }
        }
    }
}
