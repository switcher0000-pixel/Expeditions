using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Expeditions
{
    public class ItemExplore : GlobalItem
    {
        public override void OnCreated(Item item, ItemCreationContext context)
        {
            // Only process recipe crafting
            if (context is RecipeItemCreationContext recipeContext)
            {
                foreach (ModExpedition me in Expeditions.GetExpeditionsList())
                {
                    me.OnCraftItem(item, recipeContext.Recipe, Main.LocalPlayer,
                                  ref me.expedition.condition1Met,
                                  ref me.expedition.condition2Met,
                                  ref me.expedition.condition3Met,
                                  me.expedition.conditionCounted >= me.expedition.conditionCountedMax
                                  );
                }
            }
        }
        public override bool OnPickup(Item item, Player player)
        {
            if (player.ItemSpace(item).CanTakeItemToPersonalInventory)
            {
                foreach (ModExpedition me in Expeditions.GetExpeditionsList())
                {
                    me.OnPickupItem(item, Main.LocalPlayer,
                              ref me.expedition.condition1Met,
                              ref me.expedition.condition2Met,
                              ref me.expedition.condition3Met,
                              me.expedition.conditionCounted >= me.expedition.conditionCountedMax
                              );
                }
            }
            return base.OnPickup(item, player);
        }
    }
}
