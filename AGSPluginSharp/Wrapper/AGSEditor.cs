/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public sealed class AGSEditor : IDisposable
    {
        #region Fields

        private HandleRef handle;
        private bool ownsHandle;

        #endregion Fields

        #region Constructors

        internal AGSEditor(IntPtr cPtr, bool cMemoryOwn)
        {
            this.ownsHandle = cMemoryOwn;
            this.handle = new HandleRef(this, cPtr);
        }

        ~AGSEditor()
        {
            this.Dispose();
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public int PluginId
        {
            get
            {
                int ret = NativeMethods.IAGSEditor_pluginId_get(this.handle);
                return ret;
            }
        }

        public int Version
        {
            get
            {
                int ret = NativeMethods.IAGSEditor_version_get(this.handle);
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
                        NativeMethods.delete_IAGSEditor(this.handle);
                    }
                    this.handle = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public int GetEditorHandle()
        {
            int ret = NativeMethods.IAGSEditor_GetEditorHandle(this.handle);
            return ret;
        }

        public int GetWindowHandle()
        {
            int ret = NativeMethods.IAGSEditor_GetWindowHandle(this.handle);
            return ret;
        }

        public void RegisterScriptHeader(string header)
        {
            NativeMethods.IAGSEditor_RegisterScriptHeader(this.handle, new StringBuilder(header));
        }

        public void UnregisterScriptHeader(string header)
        {
            NativeMethods.IAGSEditor_UnregisterScriptHeader(this.handle, new StringBuilder(header));
        }

        #endregion Public Methods

        #region Internal Static Methods

        internal static HandleRef GetCPtr(AGSEditor obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.handle;
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}