﻿using System;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Permissions.Extensions;

namespace DBlockLockV2.Commands
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class Unlock : ICommand
    {
        public string Command { get; } = "dunlock";
        public string[] Aliases { get; } = new[] { "duk" };
        public string Description { get; } = "Command that unlocks D-Cells";

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
                    d.ChangeLock(DoorLockType.None);
            Log.Debug("Unlocked D!");
            response = "Unlocked D";
            return true;
        }
    }
}
