/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class AGSObject : IDisposable
    {
        #region Fields

        private HandleRef handle;
        private bool ownsHandle;

        #endregion Fields

        #region Constructors

        internal AGSObject(IntPtr cPtr, bool cMemoryOwn)
        {
            this.ownsHandle = cMemoryOwn;
            this.handle = new HandleRef(this, cPtr);
        }

        ~AGSObject()
        {
            this.Dispose();
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public short Baseline
        {
            set
            {
                NativeMethods.AGSObject_baseline_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSObject_baseline_get(this.handle);
                return ret;
            }
        }

        public byte Cycling
        {
            set
            {
                NativeMethods.AGSObject_cycling_set(this.handle, value);
            }
            get
            {
                byte ret = NativeMethods.AGSObject_cycling_get(this.handle);
                return ret;
            }
        }

        public ObjectFlags Flags
        {
            set
            {
                NativeMethods.AGSObject_flags_set(this.handle, (byte)value);
            }
            get
            {
                byte ret = NativeMethods.AGSObject_flags_get(this.handle);
                return (ObjectFlags)ret;
            }
        }

        public short Frame
        {
            set
            {
                NativeMethods.AGSObject_frame_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSObject_frame_get(this.handle);
                return ret;
            }
        }

        public short Loop
        {
            set
            {
                NativeMethods.AGSObject_loop_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSObject_loop_get(this.handle);
                return ret;
            }
        }

        public short Moving
        {
            set
            {
                NativeMethods.AGSObject_moving_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSObject_moving_get(this.handle);
                return ret;
            }
        }

        public short Num
        {
            set
            {
                NativeMethods.AGSObject_num_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSObject_num_get(this.handle);
                return ret;
            }
        }

        public byte On
        {
            set
            {
                NativeMethods.AGSObject_on_set(this.handle, value);
            }
            get
            {
                byte ret = NativeMethods.AGSObject_on_get(this.handle);
                return ret;
            }
        }

        public byte OverallSpeed
        {
            set
            {
                NativeMethods.AGSObject_overall_speed_set(this.handle, value);
            }
            get
            {
                byte ret = NativeMethods.AGSObject_overall_speed_get(this.handle);
                return ret;
            }
        }

        public int Transparent
        {
            set
            {
                NativeMethods.AGSObject_transparent_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSObject_transparent_get(this.handle);
                return ret;
            }
        }

        public short View
        {
            set
            {
                NativeMethods.AGSObject_view_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSObject_view_get(this.handle);
                return ret;
            }
        }

        public short Wait
        {
            set
            {
                NativeMethods.AGSObject_wait_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSObject_wait_get(this.handle);
                return ret;
            }
        }

        public int X
        {
            set
            {
                NativeMethods.AGSObject_x_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSObject_x_get(this.handle);
                return ret;
            }
        }

        public int Y
        {
            set
            {
                NativeMethods.AGSObject_y_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSObject_y_get(this.handle);
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
                        NativeMethods.delete_AGSObject(this.handle);
                    }
                    this.handle = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        #endregion Public Methods

        #region Internal Static Methods

        internal static HandleRef getCPtr(AGSObject obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.handle;
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}