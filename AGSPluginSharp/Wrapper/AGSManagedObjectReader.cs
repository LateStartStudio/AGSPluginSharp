/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    public abstract class AGSManagedObjectReader : IDisposable
    {
        #region Fields

        private readonly UnserializeCallback unserializeCallback;

        #endregion Fields

        #region Constructors

        protected AGSManagedObjectReader()
        {
            this.unserializeCallback = this.Unserialize;
            this.Handle = NativeMethods.ManagedObjectReader_Create(Marshal.GetFunctionPointerForDelegate(this.unserializeCallback));
        }

        ~AGSManagedObjectReader()
        {
            this.DisposeImpl(false);
        }

        #endregion Constructors

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate void UnserializeCallback(int key, IntPtr serializedData, int dataSize);

        #endregion Delegates

        #region Properties

        #region Public Properties

        public IntPtr Handle
        {
            get;
            private set;
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public void Dispose()
        {
            this.DisposeImpl(true);
            GC.SuppressFinalize(this);
        }

        //typedef void (*UnserializeCallback)(int key, const char *serializedData, int dataSize);
        public abstract void Unserialize(int key, IntPtr serializedData, int dataSize);

        #endregion Public Methods

        #region Protected Methods

        protected virtual void DisposeImpl(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                NativeMethods.ManagedObjectReader_Delete(this.Handle);
                this.Handle = IntPtr.Zero;
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}