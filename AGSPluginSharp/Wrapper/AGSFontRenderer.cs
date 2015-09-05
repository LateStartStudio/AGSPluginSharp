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

    public abstract class AGSFontRenderer : IDisposable
    {
        #region Fields

        private readonly AdjustYCoordinateForFontCallback adjustYCoordinateForFontCallback;
        private readonly EnsureTextValidForFontCallback ensureTextValidForFontCallback;
        private readonly FreeMemoryCallback freeMemoryCallback;
        private readonly GetTextHeightCallback getTextHeightCallback;
        private readonly GetTextWidthCallback getTextWidthCallback;
        private readonly LoadFromDiskCallback loadFromDiskCallback;
        private readonly RenderTextCallback renderTextCallback;
        private readonly SupportsExtendedCharactersCallback supportsExtendedCharactersCallback;

        #endregion Fields

        #region Constructors

        protected AGSFontRenderer()
        {
            this.loadFromDiskCallback = this.LoadFromDisk;
            this.freeMemoryCallback = this.FreeMemory;
            this.supportsExtendedCharactersCallback = this.SupportsExtendedCharacters;
            this.getTextWidthCallback = this.GetTextWidth;
            this.getTextHeightCallback = this.GetTextHeight;
            this.renderTextCallback = this.RenderText;
            this.adjustYCoordinateForFontCallback = this.AdjustYCoordinateForFont;
            this.ensureTextValidForFontCallback = this.EnsureTextValidForFont;

            this.Handle = NativeMethods.FontRenderer_Create(
                Marshal.GetFunctionPointerForDelegate(this.loadFromDiskCallback),
                Marshal.GetFunctionPointerForDelegate(this.freeMemoryCallback),
                Marshal.GetFunctionPointerForDelegate(this.supportsExtendedCharactersCallback),
                Marshal.GetFunctionPointerForDelegate(this.getTextWidthCallback),
                Marshal.GetFunctionPointerForDelegate(this.getTextHeightCallback),
                Marshal.GetFunctionPointerForDelegate(this.renderTextCallback),
                Marshal.GetFunctionPointerForDelegate(this.adjustYCoordinateForFontCallback),
                Marshal.GetFunctionPointerForDelegate(this.ensureTextValidForFontCallback));
        }

        ~AGSFontRenderer()
        {
            this.DisposeImpl(false);
        }

        #endregion Constructors

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate void AdjustYCoordinateForFontCallback(ref int ycoord, int fontNumber);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate void EnsureTextValidForFontCallback(IntPtr text, int fontNumber);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate void FreeMemoryCallback(int fontNumber);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate int GetTextHeightCallback(string text, int fontNumber);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate int GetTextWidthCallback(string text, int fontNumber);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate bool LoadFromDiskCallback(int fontNumber, int fontSize);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate void RenderTextCallback(string text, int fontNumber, IntPtr destination, int x, int y, int colour);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        private delegate bool SupportsExtendedCharactersCallback(int fontNumber);

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

        public abstract void AdjustYCoordinateForFont(ref int ycoord, int fontNumber);

        public void Dispose()
        {
            this.DisposeImpl(true);
            GC.SuppressFinalize(this);
        }

        public abstract void EnsureTextValidForFont(IntPtr text, int fontNumber);

        public abstract void FreeMemory(int fontNumber);

        public abstract int GetTextHeight(string text, int fontNumber);

        public abstract int GetTextWidth(string text, int fontNumber);

        public abstract bool LoadFromDisk(int fontNumber, int fontSize);

        public abstract void RenderText(string text, int fontNumber, IntPtr destination, int x, int y, int colour);

        public abstract bool SupportsExtendedCharacters(int fontNumber);

        #endregion Public Methods

        #region Protected Methods

        protected virtual void DisposeImpl(bool disposing)
        {
            if (this.Handle != IntPtr.Zero)
            {
                NativeMethods.FontRenderer_Delete(this.Handle);
                this.Handle = IntPtr.Zero;
            }
        }

        #endregion Protected Methods

        #endregion Methods
    }
}