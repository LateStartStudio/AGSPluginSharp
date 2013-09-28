/*
// Author: Steven Poulton
// C# Port: Tobias Bohnen
AGSBlend License

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to
deal in the Software without restriction, including without limitation the
rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
sell copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

-The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

-Credit is given to the original author.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
DEALINGS IN THE SOFTWARE.*/
namespace AGSPluginSharp
{
    using System;
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;

    public unsafe class AGSPlugin
    {
        #region Fields

        private const int DefaultRGBAShift32 = 24;
        private const int DefaultRGBBShift32 = 0;
        private const int DefaultRGBGShift32 = 8;
        private const int DefaultRGBRShift32 = 16;
        private const string OurScriptHeader = 
          "import int DrawAlpha(int destination, int sprite, int x, int y, int transparency);\r\n"
          + "import int GetAlpha(int sprite, int x, int y);\r\n"
          + "import int PutAlpha(int sprite, int x, int y, int alpha);\r\n"
          + "import int Blur(int sprite, int radius);\r\n"
          + "import int HighPass(int sprite, int threshold);\r\n"
          + "import int DrawAdd(int destination, int sprite, int x, int y, float scale);\r\n"
          + "import int DrawSprite(int destination, int sprite, int x, int y, int DrawMode, int trans);\r\n";

        private AGSEngine engine;

        #endregion Fields

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int BlurDel(int a, int b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DrawAddDel(int a, int b, int c, int d, float e);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DrawAlphaDel(int a, int b, int c, int d, int e);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int DrawSpriteDel(int a, int b, int c, int d, int e, int f);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int GetAlphaDel(int a, int b, int c);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int HighPassDel(int a, int b);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int PutAlphaDel(int a, int b, int c, int d);

        #endregion Delegates

        #region Properties

        #region Public Properties

        public string Name
        {
            get
            {
                return "AGSBlend Sharp";
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public int Blur(int sprite, int radius)
        {
            IntPtr src = this.engine.GetSpriteGraphic(sprite);

            int srcWidth, srcHeight;
            int coldepth;
            this.engine.GetBitmapDimensions(src, out srcWidth, out srcHeight, out coldepth);

            IntPtr srccharbuffer = this.engine.GetRawBitmapSurface(src);
            var srcintbuffer = (int**)srccharbuffer;
            int negrad = -1 * radius;

            //use a 1Dimensional array since the array is on the free store, not the stack
            var pixels = new Pixel32[(srcWidth + (radius * 2)) * (srcHeight + (radius * 2))]; // this defines a copy of the individual channels in class form.
            var dest = new Pixel32[(srcWidth + (radius * 2)) * (srcHeight + (radius * 2))]; // this is the destination sprite. both have a border all the way round equal to the radius for the blurring.
            var temp = new Pixel32[(srcWidth + (radius * 2)) * (srcHeight + (radius * 2))];

            int arraywidth = srcWidth + (radius * 2); //define the array width since its used many times in the algorithm

            for (int y = 0; y < srcHeight; y++)
            {
                //copy the sprite to the Pixels class array

                for (int x = 0; x < srcWidth; x++)
                {
                    int locale = XYToLocale(x + radius, y + radius, arraywidth);
                    pixels[locale] = new Pixel32
                                     {
                                         Red = GetR32(srcintbuffer[y][x]),
                                         Green = GetG32(srcintbuffer[y][x]),
                                         Blue = GetB32(srcintbuffer[y][x]),
                                         Alpha = GetA32(srcintbuffer[y][x])
                                     };
                }
            }

            int numofpixels = (radius * 2 + 1);
            for (int y = 0; y < srcHeight; y++)
            {
                int totalr = 0;
                int totalg = 0;
                int totalb = 0;
                int totala = 0;

                // Process entire window for first pixel
                for (int kx = negrad; kx <= radius; kx++)
                {
                    int locale = XYToLocale(kx + radius, y + radius, arraywidth);
                    totala += pixels[locale].Alpha;
                    totalr += (pixels[locale].Red * pixels[locale].Alpha) / 255;
                    totalg += (pixels[locale].Green * pixels[locale].Alpha) / 255;
                    totalb += (pixels[locale].Blue * pixels[locale].Alpha) / 255;
                }

                {
                    int locale = XYToLocale(radius, y + radius, arraywidth);
                    temp[locale] = new Pixel32
                                   {
                                       Red = totalr / numofpixels,
                                       Green = totalg / numofpixels,
                                       Blue = totalb / numofpixels,
                                       Alpha = totala / numofpixels
                                   };
                }

                // Subsequent pixels just update window total
                for (int x = 1; x < srcWidth; x++)
                {
                    // Subtract pixel leaving window
                    int locale = XYToLocale(x - 1, y + radius, arraywidth);
                    totala -= pixels[locale].Alpha;
                    totalr -= (pixels[locale].Red * pixels[locale].Alpha) / 255;
                    totalg -= (pixels[locale].Green * pixels[locale].Alpha) / 255;
                    totalb -= (pixels[locale].Blue * pixels[locale].Alpha) / 255;

                    // Add pixel entering window

                    locale = XYToLocale(x + radius + radius, y + radius, arraywidth);
                    totala += pixels[locale].Alpha;
                    totalr += (pixels[locale].Red * pixels[locale].Alpha) / 255;
                    totalg += (pixels[locale].Green * pixels[locale].Alpha) / 255;
                    totalb += (pixels[locale].Blue * pixels[locale].Alpha) / 255;

                    locale = XYToLocale(x + radius, y + radius, arraywidth);
                    temp[locale] = new Pixel32
                                   {
                                       Red = totalr / numofpixels,
                                       Green = totalg / numofpixels,
                                       Blue = totalb / numofpixels,
                                       Alpha = totala / numofpixels
                                   };
                }
            }

            for (int x = 0; x < srcWidth; x++)
            {
                int totalr = 0;
                int totalg = 0;
                int totalb = 0;
                int totala = 0;

                // Process entire window for first pixel
                for (int ky = negrad; ky <= radius; ky++)
                {
                    int locale = XYToLocale(x + radius, ky + radius, arraywidth);
                    totala += temp[locale].Alpha;
                    totalr += (temp[locale].Red * temp[locale].Alpha) / 255;
                    totalg += (temp[locale].Green * temp[locale].Alpha) / 255;
                    totalb += (temp[locale].Blue * temp[locale].Alpha) / 255;
                }
                {
                    int locale = XYToLocale(x + radius, radius, arraywidth);
                    dest[locale] = new Pixel32
                                   {
                                       Red = totalr / numofpixels,
                                       Green = totalg / numofpixels,
                                       Blue = totalb / numofpixels,
                                       Alpha = totala / numofpixels
                                   };
                }

                // Subsequent pixels just update window total
                for (int y = 1; y < srcHeight; y++)
                {
                    // Subtract pixel leaving window
                    int locale = XYToLocale(x + radius, y - 1, arraywidth);
                    totala -= temp[locale].Alpha;
                    totalr -= (temp[locale].Red * temp[locale].Alpha) / 255;
                    totalg -= (temp[locale].Green * temp[locale].Alpha) / 255;
                    totalb -= (temp[locale].Blue * temp[locale].Alpha) / 255;

                    // Add pixel entering window

                    locale = XYToLocale(x + radius, y + radius + radius, arraywidth);
                    totala += temp[locale].Alpha;
                    totalr += (temp[locale].Red * temp[locale].Alpha) / 255;
                    totalg += (temp[locale].Green * temp[locale].Alpha) / 255;
                    totalb += (temp[locale].Blue * temp[locale].Alpha) / 255;

                    locale = XYToLocale(x + radius, y + radius, arraywidth);
                    dest[locale] = new Pixel32
                                   {
                                       Red = totalr / numofpixels,
                                       Green = totalg / numofpixels,
                                       Blue = totalb / numofpixels,
                                       Alpha = totala / numofpixels
                                   };
                }
            }

            for (int y = 0; y < srcHeight; y++)
            {
                for (int x = 0; x < srcWidth; x++)
                {
                    int locale = XYToLocale(x + radius, y + radius, arraywidth);
                    srcintbuffer[y][x] = dest[locale].GetColorAsInt(); //write the destination array to the main buffer
                }
            }

            this.engine.ReleaseBitmapSurface(src);
            return 0;
        }

        public void EditorLoadGame(byte[] buffer)
        {
        }

        public void EditorProperties(IntPtr parentHandle)
        {
        }

        public byte[] EditorSaveGame(int maxBufferSize)
        {
            return new byte[0];
        }

        public void EditorShutdown()
        {
        }

        public int EditorStartup(AGSEditor editor)
        {
            editor.RegisterScriptHeader(OurScriptHeader);
            return 0;
        }

        public int EngineDebugHook(string scriptName, int lineNum, int reserved)
        {
            return 0;
        }

        public void EngineInitGfx(string driverID, IntPtr data)
        {
        }

        public int EngineOnEvent(EventType evnt, int data)
        {
            return 0;
        }

        public void EngineShutdown()
        {
        }

        public void EngineStartup(AGSEngine engine)
        {
            this.engine = engine;

            //register functions
            this.engine.RegisterScriptFunction("GetAlpha", (GetAlphaDel)this.GetAlpha);
            this.engine.RegisterScriptFunction("PutAlpha", (PutAlphaDel)this.PutAlpha);
            this.engine.RegisterScriptFunction("DrawAlpha", (DrawAlphaDel)this.DrawAlpha);
            this.engine.RegisterScriptFunction("Blur", (BlurDel)this.Blur);
            this.engine.RegisterScriptFunction("HighPass", (HighPassDel)this.HighPass);
            this.engine.RegisterScriptFunction("DrawAdd", (DrawAddDel)this.DrawAdd);
            this.engine.RegisterScriptFunction("DrawSprite", (DrawSpriteDel)this.DrawSprite);
        }

        #endregion Public Methods

        #region Private Static Methods

        private static byte ChannelBlendAdd(int b, int l)
        {
            return ((byte)(Math.Min(255, (b + l))));
        }

        private static byte ChannelBlendColorBurn(int b, int l)
        {
            return ((byte)((l == 0) ? l : Math.Max(0, (255 - ((255 - b) << 8) / l))));
        }

        private static byte ChannelBlendColorDodge(int b, int l)
        {
            return ((byte)((l == 255) ? l : Math.Min(255, ((b << 8) / (255 - l)))));
        }

        private static byte ChannelBlendDarken(int b, int l)
        {
            return ((byte)((l > b) ? b : l));
        }

        private static byte ChannelBlendDifference(int b, int l)
        {
            return ((byte)(Math.Abs(b - l)));
        }

        private static byte ChannelBlendExclusion(int b, int l)
        {
            return ((byte)(b + l - 2 * b * l / 255));
        }

        private static byte ChannelBlendGlow(int b, int l)
        {
            return (ChannelBlendReflect(l, b));
        }

        private static byte ChannelBlendHardLight(int b, int l)
        {
            return (ChannelBlendOverlay(l, b));
        }

        private static byte ChannelBlendHardMix(int b, int l)
        {
            return (byte)(((ChannelBlendVividLight(b, l) < 128) ? 0 : 255));
        }

        private static byte ChannelBlendLighten(int b, int l)
        {
            return ((byte)((l > b) ? l : b));
        }

        private static byte ChannelBlendLinearBurn(int b, int l)
        {
            return (ChannelBlendSubtract(b, l));
        }

        private static byte ChannelBlendLinearDodge(int b, int l)
        {
            return (ChannelBlendAdd(b, l));
        }

        private static byte ChannelBlendLinearLight(int b, int l)
        {
            return ((l < 128) ? ChannelBlendLinearBurn(b, (2 * l)) : ChannelBlendLinearDodge(b, (2 * (l - 128))));
        }

        private static byte ChannelBlendMultiply(int b, int l)
        {
            return ((byte)((b * l) / 255));
        }

        private static byte ChannelBlendNegation(int b, int l)
        {
            return ((byte)(255 - Math.Abs(255 - b - l)));
        }

        private static byte ChannelBlendOverlay(int b, int l)
        {
            return ((byte)((l < 128) ? (2 * b * l / 255) : (255 - 2 * (255 - b) * (255 - l) / 255)));
        }

        private static byte ChannelBlendPhoenix(int b, int l)
        {
            return (byte)((Math.Min(b, l) - Math.Max(b, l) + 255));
        }

        private static byte ChannelBlendPinLight(int b, int l)
        {
            return ((l < 128) ? ChannelBlendDarken(b, (2 * l)) : ChannelBlendLighten(b, (2 * (l - 128))));
        }

        private static byte ChannelBlendReflect(int b, int l)
        {
            return (byte)(l == 255 ? l : Math.Min(255, (b * b / (255 - l))));
        }

        private static byte ChannelBlendScreen(int b, int l)
        {
            return ((byte)(255 - (((255 - b) * (255 - l)) >> 8)));
        }

        private static byte ChannelBlendSoftLight(int b, int l)
        {
            return ((byte)((l < 128) ? (2 * ((b >> 1) + 64)) * ((float)l / 255) : (255 - (2 * (255 - ((b >> 1) + 64)) * (float)(255 - l) / 255))));
        }

        private static byte ChannelBlendSubtract(int b, int l)
        {
            return ((byte)((b + l < 255) ? 0 : (b + l - 255)));
        }

        private static byte ChannelBlendVividLight(int b, int l)
        {
            return ((l < 128) ? ChannelBlendColorBurn(b, (2 * l)) : ChannelBlendColorDodge(b, (2 * (l - 128))));
        }

        private static int Clamp(int val, int min, int max)
        {
            return val < min ? min : (val > max ? max : val);
        }

        private static int GetA32(int c)
        {
            return ((c >> DefaultRGBAShift32) & 0xFF);
        }

        private static int GetB32(int c)
        {
            return ((c >> DefaultRGBBShift32) & 0xFF);
        }

        private static int GetG32(int c)
        {
            return ((c >> DefaultRGBGShift32) & 0xFF);
        }

        private static int GetR32(int c)
        {
            return ((c >> DefaultRGBRShift32) & 0xFF);
        }

        private static int Makeacol32(int r, int g, int b, int a)
        {
            return ((r << DefaultRGBRShift32) |
                    (g << DefaultRGBGShift32) |
                    (b << DefaultRGBBShift32) |
                    (a << DefaultRGBAShift32));
        }

        /// <summary>
        ///  Translates index from a 2D array to a 1D array
        /// </summary>
        private static int XYToLocale(int x, int y, int width)
        {
            return (y * width + x);
        }

        #endregion Private Static Methods

        #region Private Methods

        private int DrawAdd(int destination, int sprite, int x, int y, float scale)
        {
            int srcWidth, srcHeight, destWidth, destHeight;

            IntPtr src = this.engine.GetSpriteGraphic(sprite);
            IntPtr dest = this.engine.GetSpriteGraphic(destination);
            int coldepth;
            this.engine.GetBitmapDimensions(src, out srcWidth, out srcHeight, out coldepth);
            this.engine.GetBitmapDimensions(dest, out destWidth, out destHeight, out coldepth);

            if (x > destWidth || y > destHeight)
                return 1; // offscreen

            IntPtr srccharbuffer = this.engine.GetRawBitmapSurface(src);
            var srcintbuffer = (int**)srccharbuffer;

            IntPtr destcharbuffer = this.engine.GetRawBitmapSurface(dest);
            var destintbuffer = (int**)destcharbuffer;

            if (srcWidth + x > destWidth)
                srcWidth = destWidth - x - 1;
            if (srcHeight + y > destHeight)
                srcHeight = destHeight - y - 1;

            int ycount;

            int starty = 0;
            int startx = 0;

            if (x < 0)
                startx = -1 * x;
            if (y < 0)
                starty = -1 * y;

            for (ycount = starty; ycount < srcHeight; ycount++)
            {
                int xcount;
                for (xcount = startx; xcount < srcWidth; xcount++)
                {
                    int destx = xcount + x;
                    int desty = ycount + y;

                    int srca = (GetA32(srcintbuffer[ycount][xcount]));

                    if (srca != 0)
                    {
                        int srcr = (int)(GetR32(srcintbuffer[ycount][xcount]) * srca / 255f * scale);
                        int srcg = (int)(GetG32(srcintbuffer[ycount][xcount]) * srca / 255f * scale);
                        int srcb = (int)(GetB32(srcintbuffer[ycount][xcount]) * srca / 255f * scale);
                        int desta = GetA32(destintbuffer[desty][destx]);

                        int destb;
                        int destg;
                        int destr;
                        if (desta == 0)
                        {
                            destr = 0;
                            destg = 0;
                            destb = 0;
                        }
                        else
                        {
                            destr = GetR32(destintbuffer[desty][destx]);
                            destg = GetG32(destintbuffer[desty][destx]);
                            destb = GetB32(destintbuffer[desty][destx]);
                        }

                        int finala = 255 - (255 - srca) * (255 - desta) / 255;
                        int finalr = Clamp(srcr + destr, 0, 255);
                        int finalg = Clamp(srcg + destg, 0, 255);
                        int finalb = Clamp(srcb + destb, 0, 255);
                        int col = Makeacol32(finalr, finalg, finalb, finala);
                        destintbuffer[desty][destx] = col;
                    }
                }
            }

            this.engine.ReleaseBitmapSurface(src);
            this.engine.ReleaseBitmapSurface(dest);
            this.engine.NotifySpriteUpdated(destination);
            return 0;
        }

        private int DrawAlpha(int destination, int sprite, int x, int y, int trans)
        {
            trans = 100 - trans;

            int srcWidth, srcHeight, destWidth, destHeight;
            int coldepth;
            IntPtr src = this.engine.GetSpriteGraphic(sprite);
            IntPtr dest = this.engine.GetSpriteGraphic(destination);

            this.engine.GetBitmapDimensions(src, out srcWidth, out srcHeight, out coldepth);
            this.engine.GetBitmapDimensions(dest, out destWidth, out destHeight, out coldepth);

            if (x > destWidth || y > destHeight)
                return 1; // offscreen

            IntPtr srccharbuffer = this.engine.GetRawBitmapSurface(src);
            var srcintbuffer = (int**)srccharbuffer;

            IntPtr destcharbuffer = this.engine.GetRawBitmapSurface(dest);
            var destintbuffer = (int**)destcharbuffer;

            if (srcWidth + x > destWidth)
                srcWidth = destWidth - x - 1;
            if (srcHeight + y > destHeight)
                srcHeight = destHeight - y - 1;

            int ycount;

            int starty = 0;
            int startx = 0;

            if (x < 0)
                startx = -1 * x;
            if (y < 0)
                starty = -1 * y;

            for (ycount = starty; ycount < srcHeight; ycount++)
            {
                int xcount;
                for (xcount = startx; xcount < srcWidth; xcount++)
                {
                    int destx = xcount + x;
                    int desty = ycount + y;

                    int srca = (GetA32(srcintbuffer[ycount][xcount])) * trans / 100;

                    if (srca != 0)
                    {
                        int srcr = GetR32(srcintbuffer[ycount][xcount]);
                        int srcg = GetG32(srcintbuffer[ycount][xcount]);
                        int srcb = GetB32(srcintbuffer[ycount][xcount]);

                        int destr = GetR32(destintbuffer[desty][destx]);
                        int destg = GetG32(destintbuffer[desty][destx]);
                        int destb = GetB32(destintbuffer[desty][destx]);
                        int desta = GetA32(destintbuffer[desty][destx]);

                        int finala = 255 - (255 - srca) * (255 - desta) / 255;
                        int finalr = srca * srcr / finala + desta * destr * (255 - srca) / finala / 255;
                        int finalg = srca * srcg / finala + desta * destg * (255 - srca) / finala / 255;
                        int finalb = srca * srcb / finala + desta * destb * (255 - srca) / finala / 255;

                        destintbuffer[desty][destx] = Makeacol32(finalr, finalg, finalb, finala);
                    }
                }
            }

            this.engine.ReleaseBitmapSurface(src);
            this.engine.ReleaseBitmapSurface(dest);
            this.engine.NotifySpriteUpdated(destination);

            return 0;
        }

        private int DrawSprite(int destination, int sprite, int x, int y, int drawMode, int trans)
        {
            trans = 100 - trans;
            int srcWidth, srcHeight, destWidth, destHeight;
            int cold;
            IntPtr src = this.engine.GetSpriteGraphic(sprite);
            IntPtr dest = this.engine.GetSpriteGraphic(destination);

            this.engine.GetBitmapDimensions(src, out srcWidth, out srcHeight, out cold);
            this.engine.GetBitmapDimensions(dest, out destWidth, out destHeight, out cold);

            if (x > destWidth || y > destHeight || x + srcWidth < 0 || y + srcHeight < 0)
                return 1; // offscreen

            IntPtr srccharbuffer = this.engine.GetRawBitmapSurface(src);
            var srcintbuffer = (int**)srccharbuffer;

            IntPtr destcharbuffer = this.engine.GetRawBitmapSurface(dest);
            var destintbuffer = (int**)destcharbuffer;

            if (srcWidth + x > destWidth)
                srcWidth = destWidth - x - 1;
            if (srcHeight + y > destHeight)
                srcHeight = destHeight - y - 1;

            int finalr = 0, finalg = 0, finalb = 0;
            int starty = 0;
            int startx = 0;

            if (x < 0)
                startx = -1 * x;
            if (y < 0)
                starty = -1 * y;

            int ycount = 0;
            for (ycount = starty; ycount < srcHeight; ycount++)
            {
                int xcount = 0;
                for (xcount = startx; xcount < srcWidth; xcount++)
                {
                    int destx = xcount + x;
                    int desty = ycount + y;

                    int srca = (GetA32(srcintbuffer[ycount][xcount]));

                    if (srca != 0)
                    {
                        srca = srca * trans / 100;
                        int srcr = GetR32(srcintbuffer[ycount][xcount]);
                        int srcg = GetG32(srcintbuffer[ycount][xcount]);
                        int srcb = GetB32(srcintbuffer[ycount][xcount]);

                        int destr = GetR32(destintbuffer[desty][destx]);
                        int destg = GetG32(destintbuffer[desty][destx]);
                        int destb = GetB32(destintbuffer[desty][destx]);
                        int desta = GetA32(destintbuffer[desty][destx]);

                        switch (drawMode)
                        {
                            case 0:

                                finalr = srcr;
                                finalg = srcg;
                                finalb = srcb;
                                break;

                            case 1:

                                finalr = ChannelBlendLighten(srcr, destr);
                                finalg = ChannelBlendLighten(srcg, destg);
                                finalb = ChannelBlendLighten(srcb, destb);
                                break;

                            case 2:

                                finalr = ChannelBlendDarken(srcr, destr);
                                finalg = ChannelBlendDarken(srcg, destg);
                                finalb = ChannelBlendDarken(srcb, destb);
                                break;

                            case 3:

                                finalr = ChannelBlendMultiply(srcr, destr);
                                finalg = ChannelBlendMultiply(srcg, destg);
                                finalb = ChannelBlendMultiply(srcb, destb);
                                break;

                            case 4:

                                finalr = ChannelBlendAdd(srcr, destr);
                                finalg = ChannelBlendAdd(srcg, destg);
                                finalb = ChannelBlendAdd(srcb, destb);
                                break;

                            case 5:

                                finalr = ChannelBlendSubtract(srcr, destr);
                                finalg = ChannelBlendSubtract(srcg, destg);
                                finalb = ChannelBlendSubtract(srcb, destb);
                                break;

                            case 6:

                                finalr = ChannelBlendDifference(srcr, destr);
                                finalg = ChannelBlendDifference(srcg, destg);
                                finalb = ChannelBlendDifference(srcb, destb);
                                break;

                            case 7:

                                finalr = ChannelBlendNegation(srcr, destr);
                                finalg = ChannelBlendNegation(srcg, destg);
                                finalb = ChannelBlendNegation(srcb, destb);
                                break;

                            case 8:

                                finalr = ChannelBlendScreen(srcr, destr);
                                finalg = ChannelBlendScreen(srcg, destg);
                                finalb = ChannelBlendScreen(srcb, destb);
                                break;

                            case 9:

                                finalr = ChannelBlendExclusion(srcr, destr);
                                finalg = ChannelBlendExclusion(srcg, destg);
                                finalb = ChannelBlendExclusion(srcb, destb);
                                break;

                            case 10:

                                finalr = ChannelBlendOverlay(srcr, destr);
                                finalg = ChannelBlendOverlay(srcg, destg);
                                finalb = ChannelBlendOverlay(srcb, destb);
                                break;

                            case 11:

                                finalr = ChannelBlendSoftLight(srcr, destr);
                                finalg = ChannelBlendSoftLight(srcg, destg);
                                finalb = ChannelBlendSoftLight(srcb, destb);
                                break;

                            case 12:

                                finalr = ChannelBlendHardLight(srcr, destr);
                                finalg = ChannelBlendHardLight(srcg, destg);
                                finalb = ChannelBlendHardLight(srcb, destb);
                                break;

                            case 13:

                                finalr = ChannelBlendColorDodge(srcr, destr);
                                finalg = ChannelBlendColorDodge(srcg, destg);
                                finalb = ChannelBlendColorDodge(srcb, destb);
                                break;

                            case 14:

                                finalr = ChannelBlendColorBurn(srcr, destr);
                                finalg = ChannelBlendColorBurn(srcg, destg);
                                finalb = ChannelBlendColorBurn(srcb, destb);
                                break;

                            case 15:

                                finalr = ChannelBlendLinearDodge(srcr, destr);
                                finalg = ChannelBlendLinearDodge(srcg, destg);
                                finalb = ChannelBlendLinearDodge(srcb, destb);
                                break;

                            case 16:

                                finalr = ChannelBlendLinearBurn(srcr, destr);
                                finalg = ChannelBlendLinearBurn(srcg, destg);
                                finalb = ChannelBlendLinearBurn(srcb, destb);
                                break;

                            case 17:

                                finalr = ChannelBlendLinearLight(srcr, destr);
                                finalg = ChannelBlendLinearLight(srcg, destg);
                                finalb = ChannelBlendLinearLight(srcb, destb);
                                break;

                            case 18:

                                finalr = ChannelBlendVividLight(srcr, destr);
                                finalg = ChannelBlendVividLight(srcg, destg);
                                finalb = ChannelBlendVividLight(srcb, destb);
                                break;

                            case 19:

                                finalr = ChannelBlendPinLight(srcr, destr);
                                finalg = ChannelBlendPinLight(srcg, destg);
                                finalb = ChannelBlendPinLight(srcb, destb);
                                break;

                            case 20:

                                finalr = ChannelBlendHardMix(srcr, destr);
                                finalg = ChannelBlendHardMix(srcg, destg);
                                finalb = ChannelBlendHardMix(srcb, destb);
                                break;

                            case 21:

                                finalr = ChannelBlendReflect(srcr, destr);
                                finalg = ChannelBlendReflect(srcg, destg);
                                finalb = ChannelBlendReflect(srcb, destb);
                                break;

                            case 22:

                                finalr = ChannelBlendGlow(srcr, destr);
                                finalg = ChannelBlendGlow(srcg, destg);
                                finalb = ChannelBlendGlow(srcb, destb);
                                break;

                            case 23:

                                finalr = ChannelBlendPhoenix(srcr, destr);
                                finalg = ChannelBlendPhoenix(srcg, destg);
                                finalb = ChannelBlendPhoenix(srcb, destb);
                                break;
                        }

                        int finala = 255 - (255 - srca) * (255 - desta) / 255;
                        finalr = srca * finalr / finala + desta * destr * (255 - srca) / finala / 255;
                        finalg = srca * finalg / finala + desta * destg * (255 - srca) / finala / 255;
                        finalb = srca * finalb / finala + desta * destb * (255 - srca) / finala / 255;
                        int col = Makeacol32(finalr, finalg, finalb, finala);
                        destintbuffer[desty][destx] = col;
                    }
                }
            }

            this.engine.ReleaseBitmapSurface(src);
            this.engine.ReleaseBitmapSurface(dest);
            this.engine.NotifySpriteUpdated(destination);
            return 0;
        }

        /// <summary>
        /// Gets the alpha value at coords x,y
        /// </summary>
        private int GetAlpha(int sprite, int x, int y)
        {
            IntPtr engineSprite = this.engine.GetSpriteGraphic(sprite);
            IntPtr charbuffer = this.engine.GetRawBitmapSurface(engineSprite);
            var intbuffer = (int**)charbuffer;

            int alpha = GetA32(intbuffer[y][x]);

            this.engine.ReleaseBitmapSurface(engineSprite);

            return alpha;
        }

        private int HighPass(int sprite, int threshold)
        {
            IntPtr src = this.engine.GetSpriteGraphic(sprite);
            int srcWidth, srcHeight;
            int coldepth;
            this.engine.GetBitmapDimensions(src, out srcWidth, out srcHeight, out coldepth);
            IntPtr srccharbuffer = this.engine.GetRawBitmapSurface(src);
            var srcintbuffer = (int**)srccharbuffer;

            for (int y = 0; y < srcHeight; y++)
            {
                for (int x = 0; x < srcWidth; x++)
                {
                    int srcr = GetB32(srcintbuffer[y][x]);
                    int srcg = GetG32(srcintbuffer[y][x]);
                    int srcb = GetR32(srcintbuffer[y][x]);
                    int tempmaxim = Math.Max(srcr, srcg);
                    int maxim = Math.Max(tempmaxim, srcb);
                    int tempmin = Math.Min(srcr, srcg);
                    int minim = Math.Min(srcb, tempmin);
                    int light = (maxim + minim) / 2;
                    if (light < threshold)
                        srcintbuffer[y][x] = Makeacol32(0, 0, 0, 0);
                }
            }
            return 0;
        }

        /// <summary>
        /// Sets the alpha value at coords x,y
        /// </summary>
        private int PutAlpha(int sprite, int x, int y, int alpha)
        {
            IntPtr engineSprite = this.engine.GetSpriteGraphic(sprite);

            IntPtr charbuffer = this.engine.GetRawBitmapSurface(engineSprite);
            var intbuffer = (int**)charbuffer;

            int r = GetR32(intbuffer[y][x]);
            int g = GetG32(intbuffer[y][x]);
            int b = GetB32(intbuffer[y][x]);
            intbuffer[y][x] = Makeacol32(r, g, b, alpha);

            this.engine.ReleaseBitmapSurface(engineSprite);

            return alpha;
        }

        #endregion Private Methods

        #endregion Methods

        #region Nested Types

        private struct Pixel32
        {
            #region Fields

            public int Alpha;
            public int Blue;
            public int Green;
            public int Red;

            #endregion Fields

            #region Methods

            #region Public Methods

            public int GetColorAsInt()
            {
                return Makeacol32(this.Red, this.Green, this.Blue, this.Alpha);
            }

            #endregion Public Methods

            #endregion Methods
        }

        #endregion Nested Types
    }
}