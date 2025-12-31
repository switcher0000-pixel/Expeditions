using System;

using Terraria;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Expeditions
{
    public class NPCExplore : GlobalNPC
    {
        #region Shop
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.Merchant)
            {
                shop.Add(API.ItemIDExpeditionBook);
            }
            if (shop.NpcType == NPCID.SkeletonMerchant)
            {
                if (Main.moonPhase % 2 == 0) //Alternate between selling the box and board
                {
                    // Custom currency API changed in 1.4 - using basic price for now
                    shop.Add(API.ItemIDRustedBox, Condition.InGraveyard);
                }
                else
                {
                    shop.Add(API.ItemIDExpeditionBoard);
                }
            }
        }

        internal static void AddVoucherPricedItem(NPCShop shop, int itemID, int price)
        {
            price = Math.Min(999, Math.Max(0, price));
            // Custom currency API changed in 1.4 - using basic shop entry for now
            shop.Add(itemID);
        }

        #endregion

        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            if (player.whoAmI != Main.myPlayer) return;
            foreach (ModExpedition me in Expeditions.GetExpeditionsList())
            {
                if (npc.life <= 0 || !npc.active)
                { expKillNPC(me, npc); }
                expCombatWithNPC(me, npc);
            }
        }
        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            if (projectile.owner != Main.myPlayer) return;
            foreach (ModExpedition me in Expeditions.GetExpeditionsList())
            {
                if (npc.life <= 0 || !npc.active)
                { expKillNPC(me, npc); }
                expCombatWithNPC(me, npc);
            }
        }
        public override void OnKill(NPC npc)
        {
            foreach (ModExpedition me in Expeditions.GetExpeditionsList())
            {
                expAnyNPCDeath(me, npc);
            }
        }

        private void expCombatWithNPC(ModExpedition me, NPC npc)
        {
            me.OnCombatWithNPC(npc, false, Main.LocalPlayer,
                              ref me.expedition.condition1Met,
                              ref me.expedition.condition2Met,
                              ref me.expedition.condition3Met,
                              me.expedition.conditionCounted >= me.expedition.conditionCountedMax
                              );
        }
        private void expKillNPC(ModExpedition me, NPC npc)
        {
            me.OnKillNPC(npc, Main.LocalPlayer,
                              ref me.expedition.condition1Met,
                              ref me.expedition.condition2Met,
                              ref me.expedition.condition3Met,
                              me.expedition.conditionCounted >= me.expedition.conditionCountedMax
                              );
        }
        private void expAnyNPCDeath(ModExpedition me, NPC npc)
        {
            me.OnAnyNPCDeath(npc, Main.LocalPlayer,
                              ref me.expedition.condition1Met,
                              ref me.expedition.condition2Met,
                              ref me.expedition.condition3Met,
                              me.expedition.conditionCounted >= me.expedition.conditionCountedMax
                              );
        }
    }
}
