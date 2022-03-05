﻿using CommandSystem;
using Qurre;
using Qurre.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR.Commands.SubCommands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    [CommandHandler(typeof(ClientCommandHandler))]
    public class PublicChat : ICommand
    {
        public  string Command { get; } = "publicchat";

        public string[] Aliases { get; } = new string[] { "pc" };

        public string Description { get; } = "Text Chat for public";

        public EventHandlers ev;
      

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player CommandSender = Player.Get((CommandSender)sender);
          
       
            string content = "";
            if (arguments.Count == 0)
            {
                response = Plugin.CustomConfig.tips_0;
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

            if (CommandSender.Team == Team.RIP)
            {
                response = Plugin.CustomConfig.tips_1;
                return false;
            }
            if (!Round.Started)
            {
                response = Plugin.CustomConfig.tips_2;
                return false;
            }


          
            content = "[Public Chat]" + Extensions.GetMessage(CommandSender, arguments.GetMessage(), ShowType.Public);

            Extensions.Add(content);

            Log.Info($"[Public Chat]{CommandSender.Nickname}: {content}");
          
            foreach(var player in Player.List)
            {
                player.SendConsoleMessage("<size=25><pos=-30>" +"</size></pos>", "default");
            }
            response = "OK";
            return true;
        }

    }
}
