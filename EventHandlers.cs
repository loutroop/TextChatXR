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
        public static List<Message> Messages = new List<Message>();
       public void Waiting()
        {
            Messages.Clear();
        }
        public void OnRoundStarted()
        {
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
