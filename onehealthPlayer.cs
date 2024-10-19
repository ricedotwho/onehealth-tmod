using Terraria.ModLoader;
using Terraria;
using Terraria.DataStructures;

namespace onehealth
{
    internal class onehealthPlayer : ModPlayer {
        bool needHeal = false;

        public override void PostUpdate() {
            // Get the config Variables
            var conf = ModContent.GetInstance<ItemConfig>();
            if (Player.statLifeMax2 != conf.lifeMax && conf.enableOneHealth == true) {
                needHeal = true;

                // Set Max Life
                Player.statLifeMax2 = conf.lifeMax;

                // Stop Overheal
                if (Player.statLife > conf.lifeMax) Player.statLife = conf.lifeMax;
            }
            // Heal the player when the mod is disabled via config
            if (needHeal && !conf.enableOneHealth) {
                needHeal = false;
                Player.Heal(Player.statLifeMax);
            }
        }
        // Onehit 
        public override bool ImmuneTo (PlayerDeathReason damageSource, int cooldownCounter, bool dodgeable)	 {
            var conf = ModContent.GetInstance<ItemConfig>();
            // problem: the player explodes into particles when they die if they have a dodge item rn, like it triggers the on dodge effect. should try fix that
            if(conf.nohit) { Player.KillMe(damageSource, Player.statLife, Player.direction); }
            return false;
        }
    }
}
