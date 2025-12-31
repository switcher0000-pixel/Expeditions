using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Expeditions.Items
{
    public class BountyBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now set via localization or DisplayName property
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 36;
            Item.maxStack = 1;

            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 15;

            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 20, 0);
        }

        public override LocalizedText DisplayName => base.DisplayName.WithFormatArgs("Expedition Log");
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs("Manage and track expeditions\n'The joys of discovery!'");

        public override bool CanUseItem(Player player)
        {
            return !ExpeditionUI.visible;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Expeditions.OpenExpeditionMenu(ExpeditionUI.viewMode_Menu);
            }
            return true;
        }
    }
}
