using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DBlockLock.Configs
{
    public class Config : IConfig
    {
        [Description("Is enabled?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Is debugging?")]
        public bool Debug { get; set; } = false;
    }
}
