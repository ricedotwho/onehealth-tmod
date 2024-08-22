using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using System.Runtime.InteropServices;
using Terraria.DataStructures;

namespace onehealth
{
    internal class onehealthPlayer : ModPlayer
    {
        // Declare
        bool needHeal = false;

        public override void PostUpdate() {
            // Get the config Variables
            var conf = ModContent.GetInstance<ItemConfig>();
            if (Player.statLifeMax2 != conf.lifeMax && conf.enableOneHealth == true)
            {
                needHeal = true;

                // Set Max Life
                Player.statLifeMax2 = conf.lifeMax;

                // Stop Overheal
                if (Player.statLife > conf.lifeMax) Player.statLife = conf.lifeMax;
            }
            // Heal the player when the mod is disabled via config
            if (needHeal && !conf.enableOneHealth)
            {
                needHeal = false;
                Player.Heal(Player.statLifeMax);
            }
        }
        // Onehit 
        public override bool ImmuneTo (PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable)	 {
            var conf = ModContent.GetInstance<ItemConfig>();
            if(conf.nohit) {
                dodgeable = false;
                Player.KillMe(damageSource, Player.statLife, 0, false);
            }
            return false;
        }
    }
}
