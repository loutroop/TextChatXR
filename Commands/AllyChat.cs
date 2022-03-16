using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR.Commands
{
    public class AllyChat : ICommand
    {
        public string Command => "AllyChat";

        public string[] Aliases =>new string[] { "alc"};

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "";
            return true;
        }
    }
}
