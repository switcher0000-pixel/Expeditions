using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace Expeditions
{
    public class ExpeditionsConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("Players start with BountyBook in inventory.")]
        [DefaultValue(false)]
        public bool StartWithBountyBook;
    }
}
