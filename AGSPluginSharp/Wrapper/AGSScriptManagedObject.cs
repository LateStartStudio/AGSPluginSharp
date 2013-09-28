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

    public abstract class AGSScriptManagedObject : IDisposable
    {
        #region Fields

        private readonly DisposeCallback disposeCallback;
        private readonly GetTypeCallback getTypeCallback;
        private readonly SerializeCallback serializeCallback;
        private readonly IntPtr typeName;

        #endregion Fields

        #region Constructors

        protected AGSScriptManagedObject(string type)
        {
            this.typeName = Marshal.StringToHGlobalAnsi(type);
            this.disposeCallback = this.Dispose;
            this.getTypeCallback = (() => this.typeName);
            this.serializeCallback = this.Serialize;
            this.Handle = NativeMethods.ScriptManagedObject_Create(
                Marshal.GetFunctionPointerForDelegate(this.disposeCallback),
                Marshal.GetFunctionPointerForDelegate(this.getTypeCallback),
                Marshal.GetFunctionPointerForDelegate(this.serializeCallback));
        }

        ~AGSScriptManagedObject()
        {
            this.DisposeImpl(false);
        }

        #endregion Constructors

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate int DisposeCallback(IntPtr address, bool force);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate IntPtr GetTypeCallback();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate int SerializeCallback(IntPtr address, IntPtr buffer, int bufsize);

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

        #endregion Public Methods

        #region Protected Methods

        protected abstract int Dispose(IntPtr address, bool force);

        protected virtual void DisposeImpl(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                NativeMethods.ScriptManagedObject_Delete(this.Handle);
                this.Handle = IntPtr.Zero;
                Marshal.FreeHGlobal(this.typeName);
            }
        }

        protected abstract int Serialize(IntPtr address, IntPtr buffer, int bufsize);

        #endregion Protected Methods

        #endregion Methods
    }
}