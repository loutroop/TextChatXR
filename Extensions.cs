using Qurre.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR
{
    public static  class Extensions
    {
        public static void Add(MessageType messageType, Player Sender,ArraySegment<string> Args)
        {
            string newtext = "";
            string[] mark = Args.ToArray();
            for (int i = 0; i < Args.Count; i++)
            {
                newtext += mark[i];
            }
            if (messageType == MessageType.Public)
            {
                EventHandlers.MessagePairs[CampType.Total.ToString()].Add(new Message(newtext, Sender, messageType, Sender.Role));
                EventHandlers.MessagePairs[CampType.Hostile.ToString()].Add(new Message(newtext, Sender, messageType, Sender.Role));
                EventHandlers.MessagePairs[CampType.Containment.ToString()].Add(new Message(newtext, Sender, messageType, Sender.Role));
                EventHandlers.MessagePairs[CampType.SideWorker.ToString()].Add(new Message(newtext, Sender, messageType, Sender.Role));
            }
            else
            {
                return;
            }
        }
        public static void Add(CampType camp, Player Sender,ArraySegment<string> Args)
        {
            string newtext = "";
            string[] mark = Args.ToArray();
            for (int i = 0;i < Args.Count; i++)
            {
                newtext += mark[i];
            }
            EventHandlers.MessagePairs[camp.ToString()].Add(new Message(newtext, Sender, MessageType.Team));
        }
        public static void BroadcastMessages(Player player, bool isHint)
        {
            if (player != null)
            {
                if (isHint) return;
                else player.Broadcast(Build(GetMessages(player)).ToString(), 1);
            }
        }
        public static List<Message> GetMessages(Player player)
        {
            if (player.Team == Team.CDP || player.Team == Team.CHI)
            {
                return EventHandlers.MessagePairs[CampType.Hostile.ToString()];
            }
            else if (player.Team == Team.SCP)
            {
                return EventHandlers.MessagePairs[CampType.Containment.ToString()];
            }
            else if (player.Team == Team.MTF || player.Team == Team.RSC)
            {
                return EventHandlers.MessagePairs[CampType.SideWorker.ToString()];
            }
            else if (player.Team == Team.TUT)
            {
                return EventHandlers.MessagePairs[CampType.Total.ToString()];
            }
            return null;
        }
        public static CampType GetCamp(Player player)
        {
            if (player.Team == Team.CDP || player.Team == Team.CHI)
            {
                return CampType.Hostile;
            }
            else if (player.Team == Team.SCP)
            {
                return CampType.Containment;
            }
            else if (player.Team == Team.MTF || player.Team == Team.RSC)
            {
                return CampType.SideWorker;
            }
            else if (player.Team == Team.TUT)
            {
                return CampType.Total;
            }
            return CampType.None;
        }
        public static string GetColor(RoleType role)
        {
            string color = "";
            if (role.GetTeam() == Team.CDP) color = "#ff9900";
            else if (role.GetTeam() == Team.SCP) color = "#ff0000";
            else if (role.GetTeam() == Team.RSC) color = "#e2e26d";
            else if (role.GetTeam() == Team.TUT) color = "#00ff00";
            else if (role == RoleType.ChaosConscript) color = "#58be58";
            else if (role == RoleType.ChaosMarauder) color = "#23be23";
            else if (role == RoleType.ChaosRepressor) color = "#38ac38";
            else if (role == RoleType.ChaosRifleman) color = "#1cac1c";
            else if (role == RoleType.FacilityGuard) color = "#afafa1";
            else if (role == RoleType.NtfPrivate) color = "#00a5ff";
            else if (role == RoleType.NtfCaptain) color = "#0200ff";
            else if (role == RoleType.NtfSergeant) color = "#0074ff";
            else if (role == RoleType.NtfSpecialist) color = "#1f7fff";
            return color;
        }
        public static string GetText(Message message)
        {
            string str;
            str = string.Concat($"[{message.Type}]<color={GetColor(message.Author.Role)}>{message.Author}</color>: {message.Text}({(message.Date - DateTime.UtcNow).TotalSeconds < 10})");
            return str;
        }
        public static string Build(List<Message> messages)
        {
            string str = "";
            for (int i = 0; i < messages.Count; i++)
            {
                if ((messages[i].Date - DateTime.UtcNow).TotalSeconds < 10) continue;
                str += string.Concat($"{GetText(messages[i])}");
                str += "\n";
            }
            return str;
        }
    }
}
