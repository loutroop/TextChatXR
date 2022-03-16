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
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    internal class PublicChat : ICommand
    {
        public string Command => "PublicChat";

        public string[] Aliases => new string[] { "pc"};

        public string Description => "";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get((CommandSender)sender);
            if (arguments.Count == 0)
            {
                response = Plugin.CustomConfig.tips_0;
                return false;
            }

            if (player.Role == RoleType.Spectator)
            {
                response = Plugin.CustomConfig.tips_1;
                return false;
            }

            if (!Round.Started)
            {
                response = Plugin.CustomConfig.tips_2;
                return false;
            }

           foreach (var str in Plugin.CustomConfig.BlockWords)
            {
                if (arguments.Contains(str))
                {
                    response = Plugin.CustomConfig.tips_3;
                    return false;
                }
            }
            Extensions.Add(MessageType.Public, player, arguments);
            response = "You sent the message{Public Chat} successfully!";
            return true;
        }
    }
}
