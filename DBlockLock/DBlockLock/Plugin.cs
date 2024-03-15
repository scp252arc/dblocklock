using Exiled.API.Features;
using Exiled;
using Exiled.CustomRoles.Events;
using Exiled.Events.Handlers;
using System;
using DBlockLock.Configs;
using CommandSystem;

namespace DBlockLock
{
    public class DBlockLock : Plugin<Config>
    {
        public override string Author => "scp252arc";

        public override string Name => "DBlockLock";

        public override string Prefix => "DBlockLock";

        public override Version Version => new Version(0, 0, 2);

        public static DBlockLock Instance;

        public override void OnEnabled()
        {
            Instance = this;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;

            base.OnDisabled();
        }
    }
}
