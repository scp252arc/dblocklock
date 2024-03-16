using Exiled.API.Interfaces;
using System.ComponentModel;

namespace DBlockLockV2.Configs
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        [Description("Should debug messages be shown?")]
        public bool Debug { get; set; } = false;
        [Description("Should door auto lock on round start?")]
        public bool lockDoorsOnStart { get; set; } = false;
        [Description("How long doors should be locked on round start in seconds?")]
        public float lockDoorsOnStartTime { get; set; } = 0f;
        [Description("Does door also need to open after unlocking?")]
        public bool shouldOpen { get; set; } = false;
    }
}
