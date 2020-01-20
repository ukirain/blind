using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.IO;
using System;
using System.Collections.Generic;
// using Microsoft.Extensions.Logging.LoggerExtensions;

namespace Quests 
{
    public class QuestDialog
    {
        public int id;
        public string character;
        public string text;
        public string good;
        public string bad;
        public string bubble_type;
    }

    public class QuestAction
    {
        public string name;
        public string text;
    }

    public class QuestParams
    {
        public string[] characters;
        public string background;
        public QuestDialog[] dialogs;
        public QuestAction[] actions;

        // public string GetCurrentCharacter()
        // {
        //     return characters[character_counter++];
        // }
        public QuestDialog GetNextDialog()
        {
            return dialogs[dialog_counter++];
        }
        // private int character_counter = 0;
        private int dialog_counter = 0;
    }

    public class Quest
    {
        public string name;
        public QuestParams properties;
    } 

    public class Quests
    {
        public Quest[] quests;
    }

    public class QuestsReader
    {
        public QuestsReader(string name)
        {
            try {
                StreamReader sr = new StreamReader(name);
                string str = sr.ReadToEnd();
                str = str.Replace("\r\n", "");
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str));
                var ser = new DataContractJsonSerializer(typeof(Quests));
                quests_table = (Quests)ser.ReadObject(ms);
            } catch (Exception e) {
                Console.WriteLine($"{e}");
            }
        }
        public Quests quests_table;
    }

    class Program {
        static void Main()
        {
            QuestsReader qr = new QuestsReader("quests_def.json");

        }
    }
}