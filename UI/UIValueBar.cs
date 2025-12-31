using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.UI;

namespace Expeditions.UI
{
    public class UIValueBar : UIElement
    {
        private static Color barColour = new Color(43, 56, 101, 200);

        Texture2D bar = TextureAssets.MagicPixel.Value;
        Texture2D blip = TextureAssets.MagicPixel.Value;
        Texture2D slider = TextureAssets.MagicPixel.Value; //80 range with offset 3

        private List<Color> _blipColourList;

        private int _minValue = 0;
        private int _maxValue = 4;
        private int _lastIndex = 0;
        private int _index = 0;
        private int _dragVal = 0;
        private float _widthRange = 160f;
        private bool _dragging = false;
        private int _dailyColour = -1;
        public int Value
        {
            get { return _index; }
            set
            {
                if (value > _maxValue) value = _maxValue;
                if (value < _minValue) value = _minValue;
                _index = value;
                //Main.NewText("Scroll Value: " + _minValue + " < " + value + " > " + _maxValue);
            }
        }
        public int MinValue
        {
            get { return _minValue; }
            set { _minValue = value; }
        }
        public int MaxValue
        {
            get { return _maxValue; }
            set
            {
                if (value < _minValue) value = _minValue;
                _maxValue = value;
            }
        }
        public UIValueBar(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            _widthRange = 160f;
            Width.Set(178f, 0f);
            Height.Set(25f, 0f);

            _blipColourList = new List<Color>();
        }

        public override void LeftMouseDown(UIMouseEvent evt)
        {
            base.LeftMouseDown(evt);
            _dragging = true;
        }
        public override void LeftMouseUp(UIMouseEvent evt)
        {
            base.LeftMouseUp(evt);
            _dragging = false;
        }

        public void SetBlipColours(Color[] colours, int daily)
        {
            _blipColourList.Clear();
            foreach (Color c in colours)
            {
                _blipColourList.Add(c);
            }
            _dailyColour = daily;
        }

        public override void Update(GameTime gameTime)
        {
            if (_dragging && ContainsPoint(Main.MouseScreen))
            {
                _dragVal = (int)Main.MouseScreen.X - (int)GetDimensions().X;
            }
            base.Update(gameTime);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            base.DrawSelf(spriteBatch);
            CalculatedStyle dimensions = base.GetDimensions();
            Vector2 pos = dimensions.Position();
            Vector2 size = new Vector2(dimensions.Width, dimensions.Height);
            int range = _maxValue - _minValue;

            //draw track
            float relativeWidth = size.X / (_widthRange + 18f);
            int roundWidth = (int)(_widthRange * relativeWidth);
            Rectangle trackRectangle = new Rectangle((int)pos.X, (int)pos.Y, roundWidth + 18, (int)size.Y);
            spriteBatch.Draw(bar, trackRectangle, barColour);

            //Draw blips
            if (range <= 0)
            {
                Rectangle sliderRectangle = new Rectangle((int)pos.X, (int)(pos.Y - 2), 18, (int)size.Y + 4);
                spriteBatch.Draw(slider, sliderRectangle, Color.White);
                return;
            }

            for (int i = 0; i <= range; i++)
            {
                float spacing = (_widthRange / range);
                float xPos = (spacing * i);
                xPos = xPos * relativeWidth;

                Color blipColour = Color.White;
                if (_blipColourList.Count > i) { blipColour = _blipColourList[i]; }

                if (i == _dailyColour) blipColour = new Color(150, 80, 200);

                Rectangle blipRectangle = new Rectangle((int)(pos.X + xPos + 3), (int)pos.Y, 12, (int)size.Y);
                spriteBatch.Draw(blip, blipRectangle, blipColour);
            }

            //draw slider
            if (_dragging)
            {
                float spacing = (_widthRange / range);
                float val = (float)_dragVal - 9f;
                float xVal = val / spacing;
                _index = _minValue + (int)Math.Round(xVal, 0, MidpointRounding.AwayFromZero);
                if (_index < _minValue) _index = _minValue;
                if (_index > _maxValue) _index = _maxValue;
            }

            float spacing2 = (_widthRange / range);
            float xPos2 = (spacing2 * (_index - _minValue));
            xPos2 = xPos2 * relativeWidth;

            Rectangle sliderRectangle = new Rectangle((int)(pos.X + xPos2), (int)(pos.Y - 2), 18, (int)size.Y + 4);
            spriteBatch.Draw(slider, sliderRectangle, Color.White);
        }

        public event MouseEvent OnMouseUp;
    }
}
