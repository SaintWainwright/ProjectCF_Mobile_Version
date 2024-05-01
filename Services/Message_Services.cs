using ProjectCF_Mobile_Version.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace ProjectCF_Mobile_Version.Services
{
    class Message_Services
    {
        public void SendMessage(Message message)
        {
#if ANDROID
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            ObservableCollection<Message> MessageCollection = GetMessages();
            if (message != null)
            {
                MessageCollection.Add(message);
                var MessageList = JsonSerializer.Serialize<ObservableCollection<Message>>(MessageCollection);
                File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/Message.json", MessageList);
            }
#else
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Message.txt");
            ObservableCollection<Message> MessageCollection = GetMessages();
            if (message != null)
            {
                MessageCollection.Add(message);
                var MessageList = JsonSerializer.Serialize<ObservableCollection<Message>>(MessageCollection);
                File.WriteAllText(filePath, MessageList);
            }
#endif
        }
        public ObservableCollection<Message> GetMessages()
        {
#if ANDROID
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/Initialization.json", "Initialize File path");
            if (!File.Exists($"{docsDirectory.AbsoluteFile.Path}/Message.json"))
            {
                return [];
            }
            string FileUsers = File.ReadAllText($"{docsDirectory.AbsoluteFile.Path}/Message.json");
            var MessageList = JsonSerializer.Deserialize<ObservableCollection<Message>>(FileUsers);
            return MessageList;
#else
string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Message.json");
            if (!File.Exists(filePath))
            {
                return [];
            }
            string FileUsers = File.ReadAllText(filePath);
            var MessageList = JsonSerializer.Deserialize<ObservableCollection<Message>>(FileUsers);
            return MessageList;
#endif
        }
        public void UpdateMessageCollection(Message message)
        {
#if ANDROID
            var docsDirectory = Android.App.Application.Context.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments);
            ObservableCollection<Message> MessageCollection = GetMessages();
            for (int loop = 0; loop < MessageCollection.Count; loop++)
            {
                if (message.MessageText == MessageCollection[loop].MessageText && message.Sender == MessageCollection[loop].Sender && message.Receiver == MessageCollection[loop].Receiver)
                {
                    MessageCollection[loop] = message;
                    var MessageList = JsonSerializer.Serialize<ObservableCollection<Message>>(MessageCollection);
                    File.WriteAllText($"{docsDirectory.AbsoluteFile.Path}/Message.json", MessageList);
                    return;
                }
            }
#else
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Message.json");
            ObservableCollection<Message> MessageCollection = GetMessages();
            for (int loop = 0; loop < MessageCollection.Count; loop++)
            {
                if (message.MessageText == MessageCollection[loop].MessageText && message.Sender == MessageCollection[loop].Sender && message.Receiver == MessageCollection[loop].Receiver)
                {
                    MessageCollection[loop] = message;
                    var MessageList = JsonSerializer.Serialize<ObservableCollection<Message>>(MessageCollection);
                    File.WriteAllText(filePath, MessageList);
                    return;
                }
            }
#endif
        }

        public ObservableCollection<Message> EmployeeMessageList(Employee employee) 
        {
            ObservableCollection<Message> MessageList = [];
            foreach (var message in GetMessages().Reverse())
            {
                if (message.Sender.EmployeeID ==  employee.EmployeeID || message.Receiver.EmployeeID == employee.EmployeeID)
                {
                    MessageList.Add(message);
                }
            }
            return MessageList;
        }
    }
}
