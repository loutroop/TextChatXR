using CommandSystem;
using Qurre.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Clear : ICommand
    {
        public string Command { get; } = "clear";

        public string[] Aliases { get; } = new string[] { "clr" };

        public string Description { get; } = "Text Chat for public";


        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            EventHandlers.CDP_And_CIContents.Clear();
            EventHandlers.MTF_Contents.Clear();
            EventHandlers.TUT_Contents.Clear();
            EventHandlers.SCP_Contents.Clear();
            response = "OK";
            return true;
        }

    }
}
