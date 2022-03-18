using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapEvents = Qurre.Events.Map;
using PlayerEvents = Qurre.Events.Player;
using Scp049Events = Qurre.Events.Scp049;
using Scp079Events = Qurre.Events.Scp079;
using Scp106Events = Qurre.Events.Scp106;
using Scp173Events = Qurre.Events.Scp173;
using Scp914Events = Qurre.Events.Scp914;
using Scp096Events = Qurre.Events.Scp096;
using ServerEvents = Qurre.Events.Server;
using WarheadEvents = Qurre.Events.Alpha;
using RoundEvents = Qurre.Events.Round;
using ItemEvents = Qurre.Events;
using Qurre;

namespace TextChatXR
{
    public class Plugin : Qurre.Plugin
    {
        public EventHandlers Handlers;
        public override string Developer => "Loutroop2107";
        public override string Name => nameof(TextChatXR);
        public override Version NeededQurreVersion => new Version(1, 12, 1);
        public override Version Version => new Version(0, 5);
        public static Config CustomConfig { get; private set; }

        public override void Enable()
        {
            Log.Debug("Registering Events...");
            CustomConfig = new Config();
            CustomConfigs.Add(CustomConfig);
            Handlers = new EventHandlers(this);
            try
            {
                RoundEvents.Restart += Handlers.Restart;
                RoundEvents.Waiting += Handlers.Waiting;
                RoundEvents.Start += Handlers.OnRoundStarted;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
           
        }
        public override void Disable()
        {
            try
            {
                RoundEvents.Restart -= Handlers.Restart;
                RoundEvents.Waiting -= Handlers.Waiting;
                RoundEvents.Start -= Handlers.OnRoundStarted;
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
            Handlers = null;
        }


    }
}
