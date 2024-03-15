using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DBlockLock.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Should debug messages be shown?")]
        public bool Debug { get; set; } = false;
    }
}
