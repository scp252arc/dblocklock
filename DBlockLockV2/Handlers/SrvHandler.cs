using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using MEC;

namespace DBlockLockV2.Handlers
{
    public class SrvHandler
    {
        public void OnRoundStarted()
        {
            if(DBlockLockV2.Instance.Config.lockDoorsOnStart)
            {
                Log.Debug("Locking doors!");
                foreach (Door d in Door.List)
                    if (d.Type == DoorType.PrisonDoor)
                        d.ChangeLock(DoorLockType.Isolation);

                Timing.CallDelayed(DBlockLockV2.Instance.Config.lockDoorsOnStartTime, () =>
                {
                    Log.Debug("Unlocking doors!");
                    if (DBlockLockV2.Instance.Config.shouldOpen)
                    {
                        Log.Debug("Opening doors!");
                        foreach (Door d in Door.List)
                            if (d.Type == DoorType.PrisonDoor)
                            {
                                d.ChangeLock(DoorLockType.None);
                                d.IsOpen = true;
                            }
                    }
                    else
                    {
                        foreach (Door d in Door.List)
                            if (d.Type == DoorType.PrisonDoor)
                                d.ChangeLock(DoorLockType.None);
                    }
                });
            }
        }
    }
}
