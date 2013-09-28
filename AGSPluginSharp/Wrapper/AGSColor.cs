/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct AGSColor
    {
        #region Fixed Fields

        private readonly byte r;
        private readonly byte g;
        private readonly byte b;
        private readonly byte padding;

        #endregion Fixed Fields

        #region Constructors

        public AGSColor(byte r, byte g, byte b)
            : this()
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public byte B
        {
            get
            {
                return this.b;
            }
        }

        public byte G
        {
            get
            {
                return this.g;
            }
        }

        public byte Padding
        {
            get
            {
                return this.padding;
            }
        }

        public byte R
        {
            get
            {
                return this.r;
            }
        }

        #endregion Public Properties

        #endregion Properties
    }
}