using MEC;
using Qurre;
using Qurre.API;
using Qurre.API.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChatXR
{
    public class EventHandlers
    {
        #region Values
        public Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        /*
       public string all = $"<size=25><pos=-30>";
      public string MTF_all = $"<size=25><pos=-30>";
       public string CDP_And_CI_all = $"<size=25><pos=-30>";
       public string SCPs_all = $"<size=25><pos=-30>";
       public string TUT_all = $"<size=25><pos=-30>";
        public string end = "</size></pos>";
           */
        public static List<Message> MTF_Contents = new List<Message>();
        public static List<Message> CDP_And_CIContents = new List<Message>();
        public static List<Message> SCP_Contents = new List<Message>();
        public static List<Message> TUT_Contents = new List<Message>();
        public static int Deletetg = 0;
        #endregion
        public void WaitingForPlayers()
        {
            Log.Debug("Work Verifed");
            MTF_Contents.Clear();
            CDP_And_CIContents.Clear();
            SCP_Contents.Clear();
            TUT_Contents.Clear();
            Deletetg = 0;
        }
        public void OnRoundStarted()
        {
            Timing.RunCoroutine(Show(), "Show");
            Timing.RunCoroutine(RemoveText(), "Remove");
        }
        public void OnRoundEnded(RoundEndEvent ev)
        {
            Timing.KillCoroutines("Show");
            Timing.KillCoroutines("Remove");
        }
        public IEnumerator<float> Show()
        {
            while (Round.Started)
            {
               if (MTF_Contents.Count > 0)
                {
                    foreach (Player player in Player.List.Where(x => x.Team == Team.MTF || x.Team == Team.RSC))
                    {
                        player.Send(1);
                    }
                }
               
                if (SCP_Contents.Count > 0)
                {
                    foreach (Player player in Player.List.Where(x => x.Team == Team.SCP))
                    {
                        player.Send(1);
                    }
                }
               
                if (CDP_And_CIContents.Count > 0)
                {
                    foreach (Player player in Player.List.Where(x => x.Team == Team.CDP || x.Team == Team.CHI))
                    {
                        player.Send(1);
                    }
                }
                
                if (TUT_Contents.Count > 0)
                {
                    foreach (Player player in Player.List.Where(x => x.Team == Team.TUT))
                    {
                        player.Send(1);
                    }
                }

                yield return Timing.WaitForSeconds(1f);
            }
            yield return Timing.WaitForSeconds(0.1f);
        }
        public IEnumerator<float> RemoveText()
        {
            for (; Round.Started;)
            {
                Extensions.Remove();

                yield return Timing.WaitForSeconds(1f);
            }
            yield return Timing.WaitForSeconds(0.5f);
        }

        public static Message Message(string content, Player sender, string color, ShowType showType)
        {
            return new Message()
            {
                content = content,
                sender = sender,
                color = color,
                showType = showType
            };
        }
       
    }
}
