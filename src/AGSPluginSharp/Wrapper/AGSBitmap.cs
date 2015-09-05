/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;

    public abstract class AGSBitmap
    {
        #region Fields

        private AGSEngine engine;

        #endregion Fields

        #region Constructors

        internal AGSBitmap(IntPtr ptr)
        {
            this.Handle = ptr;
            this.Initialize();
        }

        ~AGSBitmap()
        {
            if (this.CurrentLock != IntPtr.Zero && this.engine != null)
            {
                this.engine.ReleaseBitmapSurface(this.Handle);
            }
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public bool Clip
        {
            get;
            private set;
        }

        public int ClipRectangleBottom
        {
            get;
            private set;
        }

        public int ClipRectangleLeft
        {
            get;
            private set;
        }

        public int ClipRectangleRight
        {
            get;
            private set;
        }

        public int ClipRectangleTop
        {
            get;
            private set;
        }

        public int Height
        {
            get;
            private set;
        }

        public bool IsLocked
        {
            get
            {
                return this.CurrentLock != IntPtr.Zero;
            }
        }

        public int Width
        {
            get;
            private set;
        }

        #endregion Public Properties

        #region Protected Properties

        protected IntPtr CurrentLock
        {
            get;
            private set;
        }

        protected IntPtr Handle
        {
            get;
            private set;
        }

        protected Colour[] Pixels
        {
            get;
            set;
        }

        #endregion Protected Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public void Lock(AGSEngine engine)
        {
            this.engine = engine;

            if (this.IsLocked)
            {
                this.Unlock();
            }

            this.CurrentLock = engine.GetRawBitmapSurface(this.Handle);
        }

        public abstract void SetPixel(int x, int y, int color);

        public abstract void SetPixel(int x, int y, byte a, byte r, byte g, byte b);

        public Bitmap ToBitmap()
        {
            var retValue = new Bitmap(this.Width, this.Height);
            BitmapData data = retValue.LockBits(new Rectangle(0, 0, retValue.Width, retValue.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var colour = (Colour*)data.Scan0;
                for (int i = 0; i < this.Pixels.Length; i++)
                {
                    colour[i] = this.Pixels[i];
                }
            }
            retValue.UnlockBits(data);
            return retValue;
        }

        public void Unlock()
        {
            if (this.IsLocked && this.engine != null)
            {
                this.engine.ReleaseBitmapSurface(this.Handle);
                this.Initialize();
            }

            this.CurrentLock = IntPtr.Zero;
            this.engine = null;
        }

        #endregion Public Methods

        #region Protected Methods

        protected abstract void Initialize(InternalAGSBitmap bitmap);

        #endregion Protected Methods

        #region Private Methods

        private void Initialize()
        {
            var bitmap = (InternalAGSBitmap)Marshal.PtrToStructure(this.Handle, typeof(InternalAGSBitmap));
            this.Width = bitmap.w;
            this.Height = bitmap.h;
            this.Clip = bitmap.clip != 0;
            this.ClipRectangleRight = bitmap.cr;
            this.ClipRectangleLeft = bitmap.cl;
            this.ClipRectangleTop = bitmap.ct;
            this.ClipRectangleBottom = bitmap.cb;
            this.Pixels = new Colour[this.Width * this.Height];
            this.Initialize(bitmap);
        }

        #endregion Private Methods

        #endregion Methods

        #region Nested Types

        [StructLayout(LayoutKind.Sequential)]
        protected struct Colour
        {
            #region Fixed Fields

            private readonly byte B;
            private readonly byte G;
            private readonly byte R;
            private readonly byte A;

            #endregion Fixed Fields

            #region Constructors

            public Colour(byte a, byte r, byte g, byte b)
            {
                this.A = a;
                this.R = r;
                this.G = g;
                this.B = b;
            }

            #endregion Constructors
        }

        [StructLayout(LayoutKind.Sequential)]
        protected struct InternalAGSBitmap
        {
            #region Fixed Fields

            public readonly int w;
            public readonly int h;
            public readonly int clip;
            public readonly int cl;
            public readonly int cr;
            public readonly int ct;
            public readonly int cb;
            private readonly IntPtr vtable;
            private readonly IntPtr write_bank;
            private readonly IntPtr read_bank;
            private readonly IntPtr dat;
            private readonly uint id;
            private readonly IntPtr extra;
            private readonly int x_ofs;
            private readonly int y_ofs;
            private readonly int seg;
            public readonly IntPtr line;

            #endregion Fixed Fields
        }

        #endregion Nested Types
    }

    public sealed class AGSBitmapArgb888 : AGSBitmap
    {
        #region Constructors

        internal AGSBitmapArgb888(IntPtr ptr)
            : base(ptr)
        {
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public override void SetPixel(int x, int y, int color)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (int**)this.CurrentLock;
                    unchecked
                    {
                        ptr[y][x] = color;
                    }
                }
            }
        }

        public override void SetPixel(int x, int y, byte a, byte r, byte g, byte b)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (int**)this.CurrentLock;
                    ptr[y][x] = (a << 24) + (r << 16) + (g << 8) + b;
                }
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Initialize(InternalAGSBitmap bitmap)
        {
            unsafe
            {
                var linesPtr = (int*)bitmap.line;
                for (int y = 0; y < this.Height; y++)
                {
                    for (int x = 0; x < this.Width; x++)
                    {
                        int s = *linesPtr;

                        var alpha = (byte)((s >> 24) & 0xff);
                        var red = (byte)((s >> 16) & 0xff);
                        var green = (byte)((s >> 8) & 0xff);
                        var blue = (byte)(s & 0xff);

                        this.Pixels[x + y * this.Width] = new Colour(alpha, red, green, blue);

                        linesPtr++;
                    }
                }
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }

    public sealed class AGSBitmapRgb555 : AGSBitmap
    {
        #region Constructors

        internal AGSBitmapRgb555(IntPtr ptr)
            : base(ptr)
        {
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public override void SetPixel(int x, int y, int color)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (short**)this.CurrentLock;
                    unchecked
                    {
                        ptr[y][x] = (short)(color);
                    }
                }
            }
        }

        public override void SetPixel(int x, int y, byte a, byte r, byte g, byte b)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (short**)this.CurrentLock;
                    unchecked
                    {
                        ptr[y][x] = (short)((b & 0xf8) >> 3 | (g & 0xf8) << 3 | (r & 0xf8) << 8);
                    }
                }
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Initialize(InternalAGSBitmap bitmap)
        {
            unsafe
            {
                var linesPtr = (short*)bitmap.line;
                for (int y = 0; y < this.Height; y++)
                {
                    for (int x = 0; x < this.Width; x++)
                    {
                        short s = *linesPtr;

                        var red = (byte)((s & 0x7c00) >> 7);
                        var green = (byte)((s & 0x03e0) >> 2);
                        var blue = (byte)((s & 0x001f) << 3);

                        this.Pixels[x + y * this.Width] = new Colour(255, red, green, blue);

                        linesPtr++;
                    }
                }
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }

    public sealed class AGSBitmapRgb565 : AGSBitmap
    {
        #region Constructors

        internal AGSBitmapRgb565(IntPtr ptr)
            : base(ptr)
        {
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public override void SetPixel(int x, int y, int color)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (short**)this.CurrentLock;
                    unchecked
                    {
                        ptr[y][x] = (short)(color);
                    }
                }
            }
        }

        public override void SetPixel(int x, int y, byte a, byte r, byte g, byte b)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (short**)this.CurrentLock;
                    unchecked
                    {
                        ptr[y][x] = (short)((b & 0xf8) >> 3 | (g & 0xfc) << 3 | (r & 0xf8) << 8);
                    }
                }
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Initialize(InternalAGSBitmap bitmap)
        {
            unsafe
            {
                var linesPtr = (short*)bitmap.line;
                for (int y = 0; y < this.Height; y++)
                {
                    for (int x = 0; x < this.Width; x++)
                    {
                        short s = *linesPtr;

                        var red = (byte)((s & 0xf800) >> 8);
                        var green = (byte)((s & 0x07e0) >> 3);
                        var blue = (byte)((s & 0x001f) << 3);

                        this.Pixels[x + y * this.Width] = new Colour(255, red, green, blue);

                        linesPtr++;
                    }
                }
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }

    public sealed class AGSBitmapRgb888 : AGSBitmap
    {
        #region Constructors

        internal AGSBitmapRgb888(IntPtr ptr)
            : base(ptr)
        {
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public override void SetPixel(int x, int y, int color)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (int**)this.CurrentLock;
                    unchecked
                    {
                        ptr[y][x] = color;
                    }
                }
            }
        }

        public override void SetPixel(int x, int y, byte a, byte r, byte g, byte b)
        {
            if (this.IsLocked)
            {
                unsafe
                {
                    var ptr = (int**)this.CurrentLock;
                    ptr[y][x] = (r << 16) + (g << 8) + b;
                }
            }
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void Initialize(InternalAGSBitmap bitmap)
        {
            unsafe
            {
                var linesPtr = (int*)bitmap.line;
                for (int y = 0; y < this.Height; y++)
                {
                    for (int x = 0; x < this.Width; x++)
                    {
                        int s = *linesPtr;

                        var red = (byte)((s >> 16) & 0xff);
                        var green = (byte)((s >> 8) & 0xff);
                        var blue = (byte)(s & 0xff);

                        this.Pixels[x + y * this.Width] = new Colour(255, red, green, blue);

                        linesPtr++;
                    }
                }
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}