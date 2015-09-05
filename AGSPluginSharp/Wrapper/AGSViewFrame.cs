/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class AGSViewFrame : IDisposable
    {
        #region Fields

        private HandleRef handle;

        #endregion Fields

        #region Constructors

        internal AGSViewFrame(IntPtr cPtr)
        {
            this.handle = new HandleRef(this, cPtr);
        }

        ~AGSViewFrame()
        {
            this.Dispose();
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public bool Mirrored
        {
            set
            {
                NativeMethods.AGSViewFrame_flags_set(this.handle, value ? (int)FrameFlags.Mirrored : 0);
            }

            get
            {
                return NativeMethods.AGSViewFrame_flags_get(this.handle) == (int)FrameFlags.Mirrored;
            }
        }

        /// <summary>
        /// sprite slot number.
        /// </summary>
        public int Pic
        {
            set
            {
                NativeMethods.AGSViewFrame_pic_set(this.handle, value);
            }
            get
            {
                return NativeMethods.AGSViewFrame_pic_get(this.handle);
            }
        }

        /// <summary>
        /// play sound when this frame comes round
        /// </summary>
        public int Sound
        {
            set
            {
                NativeMethods.AGSViewFrame_sound_set(this.handle, value);
            }
            get
            {
                return NativeMethods.AGSViewFrame_sound_get(this.handle);
            }
        }

        public short Speed
        {
            set
            {
                NativeMethods.AGSViewFrame_speed_set(this.handle, value);
            }
            get
            {
                return NativeMethods.AGSViewFrame_speed_get(this.handle);
            }
        }

        public short XOffset
        {
            set
            {
                NativeMethods.AGSViewFrame_xoffs_set(this.handle, value);
            }
            get
            {
                return NativeMethods.AGSViewFrame_xoffs_get(this.handle);
            }
        }

        public short YOffset
        {
            set
            {
                NativeMethods.AGSViewFrame_yoffs_set(this.handle, value);
            }
            get
            {
                return NativeMethods.AGSViewFrame_yoffs_get(this.handle);
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public void Dispose()
        {
            lock (this)
            {
                if (this.handle.Handle != IntPtr.Zero)
                {
                    this.handle = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        #endregion Public Methods

        #region Internal Static Methods

        internal static HandleRef GetCPtr(AGSViewFrame obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.handle;
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}