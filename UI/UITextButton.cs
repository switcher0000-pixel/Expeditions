using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.UI;

namespace Expeditions.UI
{
    public class UITextButton : UIElement
    {
        private string _text = "";
        private float _textScale = 1f;
        private Vector2 _textSize = Vector2.Zero;
        private bool _isLarge;
        private bool _isOn;
        public bool IsOn
        {
            get
            {
                return this._isOn;
            }
        }

        public UITextButton(string text, float textScale = 1f, bool large = false)
        {
            this.SetText(text, textScale, large);
        }
        public override void Recalculate()
        {
            this.SetText(this._text, this._textScale, this._isLarge);
            base.Recalculate();
        }

        public void SetText(string text)
        {
            this.SetText(text, this._textScale, this._isLarge);
        }
        public void SetText(string text, float textScale, bool large)
        {
            DynamicSpriteFont spriteFont = large ? FontAssets.DeathText.Value : FontAssets.MouseText.Value;
            Vector2 vector = new Vector2(spriteFont.MeasureString(text).X, large ? 32f : 16f) * textScale;
            this._text = text;
            this._textScale = textScale;
            this._textSize = vector;
            this._isLarge = large;

            // Set both Min and actual dimensions for proper hit testing
            float width = vector.X + this.PaddingLeft + this.PaddingRight;
            float height = vector.Y + this.PaddingTop + this.PaddingBottom;
            this.MinWidth.Set(width, 0f);
            this.MinHeight.Set(height, 0f);
            this.Width.Set(width, 0f);
            this.Height.Set(height, 0f);
        }

        public override void MouseOver(UIMouseEvent evt)
        {
            base.MouseOver(evt);
            SoundEngine.PlaySound(SoundID.MenuTick);
            _isOn = true;
        }
        public override void MouseOut(UIMouseEvent evt)
        {
            base.MouseOut(evt);
            _isOn = false;
        }

        public override void LeftMouseDown(UIMouseEvent evt)
        {
            base.LeftMouseDown(evt);
        }

        public override void LeftClick(UIMouseEvent evt)
        {
            base.LeftClick(evt);
        }

        private bool _wasMouseDown = false;

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Manual click detection workaround for tModLoader 1.4 UserInterface bug
            // See: https://github.com/tModLoader/tModLoader/issues/1930
            if (IsMouseHovering)
            {
                // Prevent player from using items when hovering button
                Main.LocalPlayer.mouseInterface = true;

                // Detect click on release (like standard button behavior)
                if (_wasMouseDown && !Main.mouseLeft)
                {
                    // Manually trigger the click event
                    LeftClick(new UIMouseEvent(this, Main.MouseScreen));
                    SoundEngine.PlaySound(SoundID.MenuTick);
                }
                _wasMouseDown = Main.mouseLeft;
            }
            else
            {
                _wasMouseDown = false;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            CalculatedStyle dimensions = base.GetDimensions();
            Vector2 pos = dimensions.Position();
            Vector2 size = FontAssets.MouseText.Value.MeasureString(_text);

            if (this._isLarge)
            {
                pos.Y -= 10f * this._textScale;
            }
            else
            {
                pos.Y -= 2f * this._textScale;
            }
            pos.X += (dimensions.Width - this._textSize.X) * 0.5f;
            float textScale = _textScale * (_isOn ? 1.1f : 1f);
            Vector2 scaleCentre = size * 0.5f;
            Color textColor = new Color(Main.mouseTextColor, (int)((double)Main.mouseTextColor / 1.1), Main.mouseTextColor / 2, Main.mouseTextColor);
            if (this._isLarge)
            {
                Utils.DrawBorderStringBig(spriteBatch, this._text, pos + scaleCentre, textColor, textScale, scaleCentre.X, scaleCentre.Y, -1);
                return;
            }
            Utils.DrawBorderStringFourWay(spriteBatch, FontAssets.MouseText.Value, this._text, pos.X + scaleCentre.X, pos.Y + scaleCentre.Y,
                textColor, Color.Black, scaleCentre, textScale);
        }
    }
}
