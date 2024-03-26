using ProjectCF_Mobile_Version.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProjectCF_Mobile_Version.Services
{
    class Message_Services
    {
        public void AddMessage(Message message)
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
#endif
#if WINDOWS
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
                return new ObservableCollection<Message>();
            }
            string FileUsers = File.ReadAllText($"{docsDirectory.AbsoluteFile.Path}/Message.json");
            var MessageList = JsonSerializer.Deserialize<ObservableCollection<Message>>(FileUsers);
            return MessageList;
#endif
#if WINDOWS
            string filePath = Path.Combine(FileSystem.Current.AppDataDirectory, "Message.json");
            if (!File.Exists(filePath))
            {
                return new ObservableCollection<Message>();
            }
            string FileUsers = File.ReadAllText(filePath);
            var MessageList = JsonSerializer.Deserialize<ObservableCollection<Message>>(FileUsers);
            return MessageList;
#endif
        }
    }
}
