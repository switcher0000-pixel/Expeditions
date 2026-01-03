using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.UI;

namespace Expeditions.UI
{
    /// <summary>
    /// A fixed version of UIToggleImage that includes manual click detection
    /// to work around tModLoader 1.4 UserInterface bug #1930
    /// </summary>
    public class UIToggleImageFixed : UIToggleImage
    {
        private bool _wasMouseDown = false;

        public UIToggleImageFixed(Asset<Texture2D> texture, int width, int height, Point onFrame, Point offFrame)
            : base(texture, width, height, onFrame, offFrame)
        {
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            // Intentionally empty - handled manually in Update() due to tModLoader bug
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Manual click detection workaround for tModLoader 1.4 UserInterface bug
            if (IsMouseHovering)
            {
                Main.LocalPlayer.mouseInterface = true;

                // Detect click on release
                if (_wasMouseDown && !Main.mouseLeft)
                {
                    // Toggle state and fire the click event
                    base.LeftClick(new UIMouseEvent(this, Main.MouseScreen));
                    SoundEngine.PlaySound(SoundID.MenuTick);
                }
                _wasMouseDown = Main.mouseLeft;
            }
            else
            {
                _wasMouseDown = false;
            }
        }
    }
}
