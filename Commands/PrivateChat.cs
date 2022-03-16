using CommandSystem;
using Qurre.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR.Commands
{
    internal class PrivateChat : ICommand
    {
        public string Command => "PrivateChat";

        public string[] Aliases => new string[] { "prec"};

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = Plugin.CustomConfig.tips_4;
            return false;
        }
    }
}
