using MEC;
using Qurre.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR
{
    public class EventHandlers
    {
        public readonly Plugin plugin;
        public EventHandlers(Plugin plugin) =>this.plugin = plugin;
        public static Dictionary<string, List<Message>>MessagePairs = new Dictionary<string, List<Message>>();
       public void Waiting()
        {
            MessagePairs.Clear();
        }
        public void OnRoundStarted()
        {
            MessagePairs.Add(CampType.Containment.ToString(), new List<Message>());
            MessagePairs.Add(CampType.SideWorker.ToString(), new List<Message>());
            MessagePairs.Add(CampType.Hostile.ToString(), new List<Message>());
            MessagePairs.Add(CampType.Total.ToString(), new List<Message>());
            Timing.RunCoroutine(BroadcastMessages(), "BroadcastMessage");
        }
        public void Restart()
        {
            Timing.KillCoroutines("BroadcastMessage");
        }
        public static IEnumerator<float> BroadcastMessages()
        {
            while (Round.Started)
            {
                yield return Timing.WaitForSeconds(0.95f);

                try
                {
                    foreach (Player player in Player.List)
                    {
                        Extensions.BroadcastMessages(player, Plugin.CustomConfig.Use_Hint);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
