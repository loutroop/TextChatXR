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
        public static List<string> MTF_Contents = new List<string>();
        public static List<string> CDP_And_CIContents = new List<string>();
        public static List<string> SCP_Contents = new List<string>();
        public static List<string> TUT_Contents = new List<string>();
        #endregion
        public void WaitingForPlayers()
        {
            Log.Debug("Work Verifed");
            MTF_Contents.Clear();
            CDP_And_CIContents.Clear();
            SCP_Contents.Clear();
            TUT_Contents.Clear();
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
                foreach (Player player in Player.List.Where(x => x.Team != Team.RIP))
                {
                    player.Send(1);
                }

                yield return Timing.WaitForSeconds(1f);
            }
            yield return Timing.WaitForSeconds(0.1f);
        }
        public IEnumerator<float> RemoveText()
        {
            while (Round.Started)
            {
                Extensions.Remove();

                yield return Timing.WaitForSeconds(4f);
            }
            yield return Timing.WaitForSeconds(1f);
        }
       
    }
}
