using Exiled.API.Features;
using System;
using DBlockLockV2.Configs;
using DBlockLockV2.Handlers;

namespace DBlockLockV2
{
    public class DBlockLockV2 : Plugin<Config>
    {
        public override string Author => "scp252arc";

        public override string Name => "DBlockLockV2";

        public override string Prefix => "DBlockLockV2";

        public override Version Version => new Version(0, 1, 0);

        public override Version RequiredExiledVersion => new Version(8, 8, 0);

        public static DBlockLockV2 Instance;
        SrvHandler _handler = new SrvHandler();
        public override void OnEnabled()
        {
            Instance = this;

            Exiled.Events.Handlers.Server.RoundStarted += _handler.OnRoundStarted;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Instance = null;

            Exiled.Events.Handlers.Server.RoundStarted -= _handler.OnRoundStarted;

            base.OnDisabled();
        }
    }
}
