using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Expeditions.Items
{
    public class BountyBoard : ModItem
	{
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now set via localization or DisplayName property
        }

        public override void SetDefaults()
		{
            Item.width = 30;
            Item.height = 36;
            Item.maxStack = 99;

            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.BountyBoard>();

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.value = Item.sellPrice(0, 0, 0, 20);
        }

        public override LocalizedText DisplayName => base.DisplayName.WithFormatArgs("Expeditions Board");
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs("View, track and complete expeditions");

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 20);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}
