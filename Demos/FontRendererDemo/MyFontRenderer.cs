namespace AGSPluginSharp
{
    using System;

    using AGSPluginSharp.Wrapper;

    public class MyFontRenderer : AGSFontRenderer
    {
        #region Fields

        private readonly AGSEngine engine;

        private readonly Font font = new Font();

        #endregion Fields

        #region Constructors

        public MyFontRenderer(AGSEngine engine)
        {
            this.engine = engine;
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public override void AdjustYCoordinateForFont(ref int ycoord, int fontNumber)
        {
        }

        public override void EnsureTextValidForFont(IntPtr text, int fontNumber)
        {
            unsafe
            {
                var b = (byte*)text;
                while (*b != 0)
                {
                    var c = (char)*b;

                    // replace lower case with upper
                    if (c >= 'a' && c <= 'z')
                    {
                        *b = (byte)char.ToUpper(c);
                    }

                    b++;
                }
            }
        }

        public override void FreeMemory(int fontNumber)
        {
        }

        public override int GetTextHeight(string text, int fontNumber)
        {
            return 5;
        }

        public override int GetTextWidth(string text, int fontNumber)
        {
            return text.Length * 6;
        }

        public override bool LoadFromDisk(int fontNumber, int fontSize)
        {
            return false;
        }

        public override void RenderText(string text, int fontNumber, IntPtr destination, int x, int y, int colour)
        {
            int width, height, coldep;
            this.engine.GetBitmapDimensions(destination, out width, out height, out coldep);
            if (coldep == 32)
            {
                var a = new AGSBitmapArgb888(destination);
                a.Lock(this.engine);
                foreach (var c in text)
                {
                    byte[] ar;
                    if (this.font.TryGetValue(c, out ar))
                    {
                        for (int i = 0; i < ar.Length; i++)
                        {
                            if (ar[i] == 1)
                            {
                                int xx = x + (i % 5);
                                int yy = y + (i / 5);
                                a.SetPixel(xx, yy, colour);
                            }
                        }
                    }
                    x += 6;
                }
                a.Unlock();
            }
        }

        public override bool SupportsExtendedCharacters(int fontNumber)
        {
            return false;
        }

        #endregion Public Methods

        #endregion Methods
    }
}