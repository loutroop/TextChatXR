using CommandSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR.Commands
{
    public class PositionChat : ICommand
    {
        public string Command => "PositionChat";

        public string[] Aliases => new string[] { "posc"};

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = "";
            return true;
        }
    }
}
