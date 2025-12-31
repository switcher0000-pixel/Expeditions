using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Expeditions.Items
{
    /// <summary>
    /// Used in shops that require this as a special currency.
    /// Expeditions should only reward up to 3 of these.
	/// Remember also the exclusivity comes from the quests,
	/// Not just the coupons
    /// </summary>
    public class BountyVoucher : ModItem
    {
        public static string itemName = "Expedition Coupon";
        public override void SetStaticDefaults()
        {
            // DisplayName and Tooltip are now set via localization or DisplayName property
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.value = 0;
            Item.rare = ItemRarityID.Quest;
        }

        public override LocalizedText DisplayName => base.DisplayName.WithFormatArgs(itemName);
        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs("Trade in for exclusive items at certain stores\n'Proof of achievement'");
    }
}
