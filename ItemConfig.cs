using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace onehealth
{
    internal class ItemConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        // Enable Bool
        [DefaultValue(true)] public bool enableOneHealth;

        // Life to Set to
        [Range(1, 1000000)]
        [DefaultValue(1)]
        [Increment(10)]
        public int lifeMax;

        // Dont Let People Change Config On a Server
        [DefaultValue(false)] public bool cannotChangeConfigOnServer;

        public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
        {
            if (Main.netMode == NetmodeID.Server && cannotChangeConfigOnServer == true)
            {
                message = "Clients cannot change config on Server! (You can disable this in the Config!)";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
