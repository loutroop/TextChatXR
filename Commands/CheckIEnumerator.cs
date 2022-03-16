using CommandSystem;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class CheckIEnumerator : ICommand
    {
        public string Command => "CheckIEnumerator";

        public string[] Aliases => new string[] { "cie" };

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"Running Statu: {Timing.IsRunning(EventHandlers.BroadcastMessages().RunCoroutine())}";
            return true;
        }
    }
}
