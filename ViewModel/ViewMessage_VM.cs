using ProjectCF_Mobile_Version.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.ViewModel
{
    [QueryProperty(nameof(SelectedMessage), "selectedmessage")]
    public partial class ViewMessage_VM : LandingPage_VM
    {
        private Message selectedMessage;
        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set
            {
                selectedMessage = value; OnPropertyChanged(); OnPropertyChanged(nameof(selectedMessage));
            }
        }
    }
}
