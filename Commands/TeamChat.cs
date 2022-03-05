using CommandSystem;
using Hints;
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
    public class TeamChat : ParentCommand
    {
        public TeamChat() => LoadGeneratedCommands();
        public override string Command { get; } = "teamchat";

        public override string[] Aliases { get; } = new string[] { "tc" };

        public override string Description { get; } = "Text Chat for team";

        public EventHandlers ev;


        public override void LoadGeneratedCommands()
        {

        }

      
        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player CommandSender = Player.Get((CommandSender)sender);


            string content = "";
            
            if (arguments.Count == 0)
            {
                response  = Plugin.CustomConfig.tips_0;
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

            if (!Round.Started)
            {
                response = Plugin.CustomConfig.tips_2;
                return false;
            }

           if(CommandSender.Team == Team.CDP || CommandSender.Team == Team.CHI)
            {
                if (EventHandlers.CDP_And_CIContents.Count >= Plugin.CustomConfig.MaxCount)
                {
                    EventHandlers.CDP_And_CIContents.Clear();
                }
                if (EventHandlers.CDP_And_CIContents.Count <= Plugin.CustomConfig.MaxCount)
                {
                    content = "<align=left>[<color=blue>Team Chat</color>]" + Extensions.GetMessage(CommandSender, arguments.GetMessage(), ShowType.Team) + "</align>\n";
                    Extensions.Add(content, CommandSender.Team);
                }
                response = "done";
                return true;
            }
           else if (CommandSender.Team == Team.MTF || CommandSender.Team == Team.RSC)
            {

                if (EventHandlers.MTF_Contents.Count >= Plugin.CustomConfig.MaxCount)
                {
                    EventHandlers.MTF_Contents.Clear();
                }
                if (EventHandlers.MTF_Contents.Count <= Plugin.CustomConfig.MaxCount)
                {
                    content = "<align=left>[<color=blue>Team Chat</color>]" + Extensions.GetMessage(CommandSender, arguments.GetMessage(), ShowType.Team) + "</align>\n";
                    Extensions.Add(content, CommandSender.Team);
                }
                response = "done";
                return true;
            }
           else if (CommandSender.Team == Team.SCP)
            {
                if (EventHandlers.SCP_Contents.Count >= Plugin.CustomConfig.MaxCount)
                {
                    EventHandlers.SCP_Contents.Clear();
                }
                if (EventHandlers.SCP_Contents.Count <= 10)
                {
                    content = "<align=left>[<color=blue>Team Chat</color>]" + Extensions.GetMessage(CommandSender, arguments.GetMessage(), ShowType.Team) + "</align>\n";
                    Extensions.Add(content, CommandSender.Team);
                }
                response = "done";
                return true;
            }
           else if (CommandSender.Team == Team.TUT)
            {
                if (EventHandlers.TUT_Contents.Count >= Plugin.CustomConfig.MaxCount)
                {
                    EventHandlers.TUT_Contents.Clear();
                }
                if (EventHandlers.TUT_Contents.Count <= Plugin.CustomConfig.MaxCount)
                {
                    content = "<align=left>[<color=blue>Team Chat</color>]" + Extensions.GetMessage(CommandSender, arguments.GetMessage(), ShowType.Team) + "</align>\n";
                    Extensions.Add(content, CommandSender.Team);
                }
                response = "done";
                return true;
            }

          

            Log.Info($"[Team Chat]{CommandSender.Nickname}: {content}");
            response = "OK";
            return true;
        }
    }
}

