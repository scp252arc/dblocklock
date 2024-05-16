﻿using System;
using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
using Exiled.Permissions.Extensions;

namespace DBlockLockV2.Commands
{

    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class LockDoorNearYou : ICommand
    {
        public string Command { get; } = "dnl";
        public string[] Aliases { get; } = new[] { "dnl" };
        public string Description { get; } = "Command that locks door near player";

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player _player = Player.Get(sender);
            if (!sender.CheckPermission("dblock.dnl"))
            {
                response = "You dont have perms to use this command";
                return false;
            }
            float distance;
            Door d = Door.GetClosest(_player.Position, out distance);
            if (distance <= DBlockLockV2.Instance.Config.dnlDistance)
            {
                d.ChangeLock(DoorLockType.Isolation);
                Log.Debug("Locked door nearby!");
                response = "Locked door nearby!";
            }
            else
            {
                response = "No doors nearby!";
                return false;
            }
            return true;
        }
    }
}
