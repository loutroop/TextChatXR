using MEC;
using Qurre.API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextChatXR
{
    public static class Extensions
    {

        public static EventHandlers ev;


        public static void Send(this Player player, float time, string color = "green")
        {
            if (EventHandlers.CDP_And_CIContents.Count > 0)
            {
                if (player.Team == Team.CDP || player.Team == Team.CHI)
                {
                    if (Plugin.CustomConfig.Use_Hint) player.ShowHint($"{"<size=25><voffset=70><pos=-30>"}{BuildNewChatList(EventHandlers.CDP_And_CIContents)}{"</size></voffset></pos>"}", time);
                    else player.Broadcast($"<size=25>{BuildNewChatList(EventHandlers.CDP_And_CIContents)}</size>", ((ushort)time));
                    //    player.SendConsoleMessage("<size=25><pos=-30>" +"</size></pos>", color);
                }
            }

            if (EventHandlers.MTF_Contents.Count > 0)
            {
                if (player.Team == Team.MTF || player.Team == Team.RSC)
                {
                    if (Plugin.CustomConfig.Use_Hint) player.ShowHint($"{"<size=25><voffset=70><pos=-30>"}{BuildNewChatList(EventHandlers.MTF_Contents)}{"</size></voffset></pos>"}", time);
                    else player.Broadcast($"<size=25>{BuildNewChatList(EventHandlers.MTF_Contents)}</size>", ((ushort)time));
                    //     player.SendConsoleMessage("<size=25><pos=-30>" +"</size></pos>", color);
                }
            }

            if (EventHandlers.SCP_Contents.Count > 0)
            {
                if (player.Team == Team.SCP)
                {
                    if (Plugin.CustomConfig.Use_Hint) player.ShowHint($"{"<size=25><voffset=70><pos=-30>"}{BuildNewChatList(EventHandlers.SCP_Contents)}{"</size></voffset></pos>"}", time);
                    else player.Broadcast($"<size=25>{BuildNewChatList(EventHandlers.SCP_Contents)}</size>", ((ushort)time));
                    //     player.SendConsoleMessage("<size=25><pos=-30>" +"</size></pos>", color);
                }
            }

            if (EventHandlers.TUT_Contents.Count > 0)
            {
                if (player.Team == Team.TUT)
                {
                    if (Plugin.CustomConfig.Use_Hint) player.ShowHint($"{"<size=25><voffset=70><pos=-30>"}{BuildNewChatList(EventHandlers.TUT_Contents)}{"</size></voffset></pos>"}", time);
                    else player.Broadcast($"<size=25>{BuildNewChatList(EventHandlers.TUT_Contents)}</size>", ((ushort)time));
                    //   player.SendConsoleMessage("<size=25><pos=-30>" +"</size></pos>", color);
                }
            }
        }

        public static string BuildNewChatList(List<Message> messages)
        {
            List<string> strs = new List<string>();
            string[] mark = strs.ToArray();
            string result = "";
            string list = "";
            for (int i = 0; i < strs.Count; i++)
            {
                result += $"{messages[i].showType}<color=>{messages[i].sender.Nickname}: {messages[i].content}".Replace("PublicChat", "[Public Chat]").Replace("TeamChat", "[TeamChat]");
                strs.Add(result);
                list += string.Concat(
                    $"{mark[i]}\n"
           );
            }
            return list;
        }


        public static void Add(Message message, Team team)
        {
            if (team == Team.CDP || team == Team.CHI)
            {
                //"<size=25><pos=-30>"l += message;
                EventHandlers.CDP_And_CIContents.Add(message);
            }
            else if (team == Team.MTF || team == Team.RSC)
            {
                //  "<size=25><pos=-30>" += message;
                EventHandlers.MTF_Contents.Add(message);
            }
            else if (team == Team.SCP)
            {
                //  "<size=25><pos=-30>" += message;
                EventHandlers.SCP_Contents.Add(message);
            }
            else if (team == Team.TUT)
            {
                //  "<size=25><pos=-30>" += message;
                EventHandlers.TUT_Contents.Add(message);
            }
        }
        public static void Add(Message message)
        {
            EventHandlers.SCP_Contents.Add(message);
            EventHandlers.CDP_And_CIContents.Add(message);
            EventHandlers.MTF_Contents.Add(message);
            EventHandlers.TUT_Contents.Add(message);
        }
        public static void Remove()
        {
            EventHandlers.SCP_Contents.Remove(EventHandlers.SCP_Contents[EventHandlers.Deletetg]);
            EventHandlers.MTF_Contents.Remove(EventHandlers.MTF_Contents[EventHandlers.Deletetg]);
            EventHandlers.TUT_Contents.Remove(EventHandlers.TUT_Contents[EventHandlers.Deletetg]);
            EventHandlers.CDP_And_CIContents.Remove(EventHandlers.CDP_And_CIContents[EventHandlers.Deletetg]);
            EventHandlers.Deletetg += 1;
        }
        public static string GetMessage(this ArraySegment<string> arg)
        {
            string result = "";
            for (int i = 0; i < arg.Count; i++)
            {
                result += arg.ToArray()[i];
            }
            return result;
        }
        public static Message GetMessage(Player Sender, string message, ShowType ShowType = ShowType.Public)
        {
            string Target = "";
            string Color = null;
            if (ShowType == ShowType.Public)
            {
                switch (Sender.Team)
                {
                    case Team.CDP:
                        Color = "orange";
                        break;
                    case Team.CHI:
                        Color = "dark_green";
                        break;
                    case Team.MTF:
                        Color = "blue";
                        break;
                    case Team.RIP:
                        Color = "default";
                        break;
                    case Team.RSC:
                        Color = "yellow";
                        break;
                    case Team.SCP:
                        Color = "red";
                        break;
                    case Team.TUT:
                        Color = "green";
                        break;

                }
                Target += string.Concat(
               message);
            }
            else
            {
                Target += string.Concat(
               message);
            }
            return EventHandlers.Message(Target, Sender, Color, ShowType);
        }

    }
    [Serializable]
    public class Message
    {
        public string content { get; set; }
        public Player sender { get; set; }
        public string color { get; set; }
        public ShowType showType { get; set; }
       
    }
}
