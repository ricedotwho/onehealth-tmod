using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using System.Runtime.InteropServices;

namespace onehealth
{
    internal class onehealthPlayer : ModPlayer
    {
        // Declare
        int x = 0;

        public override void PostUpdate()
        {
            // Get the config Variables
            var conf = ModContent.GetInstance<ItemConfig>();

            if (Player.statLifeMax2 != conf.lifeMax && conf.enableOneHealth == true)
            {
                x = 0; // int for healing when conf is changed

                // Set Max Life
                Player.statLifeMax2 = conf.lifeMax;

                // Stop Overheal
                if (Player.statLife > conf.lifeMax) Player.statLife = conf.lifeMax;
            }
            // Heal the player when the mod is disabled via config
            if (x < 1 && !conf.enableOneHealth)
            {
                x++;
                Player.Heal(1000);
            }
        }
    }
}
