/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class AGSMouseCursor : IDisposable
    {
        #region Fields

        private HandleRef handle;
        private bool ownsHandle;

        #endregion Fields

        #region Constructors

        internal AGSMouseCursor(IntPtr cPtr, bool cMemoryOwn)
        {
            this.ownsHandle = cMemoryOwn;
            this.handle = new HandleRef(this, cPtr);
        }

        ~AGSMouseCursor()
        {
            this.Dispose();
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public MouseCursorFlags Flags
        {
            set
            {
                NativeMethods.AGSMouseCursor_flags_set(this.handle, (char)value);
            }
            get
            {
                char ret = NativeMethods.AGSMouseCursor_flags_get(this.handle);
                return (MouseCursorFlags)ret;
            }
        }

        public short HotspotX
        {
            set
            {
                NativeMethods.AGSMouseCursor_hotx_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSMouseCursor_hotx_get(this.handle);
                return ret;
            }
        }

        public short HotspotY
        {
            set
            {
                NativeMethods.AGSMouseCursor_hoty_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSMouseCursor_hoty_get(this.handle);
                return ret;
            }
        }

        public string Name
        {
            set
            {
                NativeMethods.AGSMouseCursor_name_set(this.handle, value);
            }
            get
            {
                string ret = NativeMethods.AGSMouseCursor_name_get(this.handle);
                return ret;
            }
        }

        public int Pic
        {
            set
            {
                NativeMethods.AGSMouseCursor_pic_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSMouseCursor_pic_get(this.handle);
                return ret;
            }
        }

        public short View
        {
            set
            {
                NativeMethods.AGSMouseCursor_view_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSMouseCursor_view_get(this.handle);
                return ret;
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
                    if (this.ownsHandle)
                    {
                        this.ownsHandle = false;
                        NativeMethods.delete_AGSMouseCursor(this.handle);
                    }
                    this.handle = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        #endregion Public Methods

        #region Internal Static Methods

        internal static HandleRef GetCPtr(AGSMouseCursor obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.handle;
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}