using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Expeditions.Items
{
    public class StockBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now set via localization or DisplayName property
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 30;
            Item.rare = ItemRarityID.Blue;
        }

        public override LocalizedText DisplayName => base.DisplayName.WithFormatArgs("Rusted Box");
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs("Right click to open\n'Its contents, a mystery...'");

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            int rare = ItemRewardPool.GetRewardRare(player);
            if (rare > 3) rare = 3;
            try
            {
                foreach (ItemRewardData i in ItemRewardPool.GenerateFullRewards(rare))
                {
                    player.QuickSpawnItem(player.GetSource_OpenItem(Type), i.itemID, i.stack);
                }
            }
            catch (System.Exception e)
            {
                //Main.NewTextMultiline(e.ToString());
                player.QuickSpawnItem(player.GetSource_OpenItem(Type), ItemID.IronCrate);
            }
        }
    }
}
