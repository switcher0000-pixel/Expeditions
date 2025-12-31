using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace Expeditions
{
    public class ExpeditionsSystem : ModSystem
    {
        public override void PostUpdateWorld()
        {
            // Call the Expeditions PostUpdateEverything logic
            ModContent.GetInstance<Expeditions>().PostUpdateEverything();
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            bool OtherInterfaceActive =
                Main.playerInventory ||
                Main.LocalPlayer.chest != -1 ||
                Main.npcShop != 0 ||
                (
                    Main.LocalPlayer.talkNPC > 0 &&
                    ExpeditionUI.viewMode != ExpeditionUI.viewMode_NPC
                ) ||
                Main.InReforgeMenu ||
                Main.InGuideCraftMenu ||
                Main.gameMenu;

            int HotBar = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Hotbar"));
            if (HotBar != -1)
            {
                layers.Insert(HotBar, new LegacyGameInterfaceLayer(
                    "Expeditions: UITracker",
                    delegate
                    {
                        if (TrackerUI.VisibleWithAlpha)
                        {
                            if (!OtherInterfaceActive)
                            {
                                Expeditions.trackerInterface.Update(Main._drawInterfaceGameTime);
                                Expeditions.trackerUI.Draw(Main.spriteBatch);
                            }
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }

            //All this stuff is jankyily adapted from ExampleMod
            //This is getting the mouse layer, and adding the UI just underneath it
            int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (MouseTextIndex != -1)
            {
                layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
                    "Expeditions: UIPanel",
                    delegate
                    {
                        if (ExpeditionUI.visible)
                        {
                            if (OtherInterfaceActive)
                            {
                                //close this if other things are opened
                                Expeditions.CloseExpeditionMenu(true);
                                if (Expeditions.DEBUG) Main.NewText("Closing via obstruction");
                            }
                            else
                            {
                                //No idea what this does but the other one draws the UI
                                Expeditions.expeditionUserInterface.Update(Main._drawInterfaceGameTime);
                                Expeditions.expeditionUI.Draw(Main.spriteBatch);
                            }
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }
    }
}
