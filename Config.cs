using Qurre.API.Addons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public string Name { get; set; } = nameof(TextChatXR);
        public string tips_0 { get; set; } = "You didn't enter anything";
        public string tips_1 { get; set; } = "You can't send message as a Spectator";
        public string tips_2 { get; set; } = "The round is not start,sending message is not allowed now";
        public string tips_3 { get; set; } = "Please do not use uncivil language";
        public int MaxCount { get; set; } = 8;
        public bool Use_Hint { get; set; } = false;
        public string[] BlockWords { get; set; } = new string[] { "fuck" };
    }
}
