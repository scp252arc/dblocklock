using System;
using System.Windows.Input;
using CommandSystem;
using Exiled;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.API.Features.Pickups;
using Exiled.Permissions.Extensions;
using GameCore;
using RemoteAdmin;

namespace DBlockLock.Commands
{
    
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Lock : CommandSystem.ICommand
    {
        public string Command { get; } = "dlock";
        public string[] Aliases { get; } = new[] { "dlk" };
        public string Description { get; } = "Command that locks D-Cells";

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }   
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("dblock.dlock"))
            {
                response = "You dont have perms to use this command";
                return false;
            }
            foreach (Door d in Door.List)
                if (d.Type == DoorType.PrisonDoor)
                      d.ChangeLock(DoorLockType.Isolation);
            Exiled.API.Features.Log.Info("Locked D!");
            response = "Locked D";
            return true;
        }
    }
}
