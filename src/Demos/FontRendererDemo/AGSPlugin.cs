namespace AGSPluginSharp
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;

    public sealed class AGSPlugin
    {
        #region Fields

        private AGSEngine engine;
        private MyFontRenderer fontRenderer;

        #endregion Fields

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void TestDel();

        #endregion Delegates

        #region Properties

        #region Public Properties

        public string Name
        {
            get
            {
                return "FontRenderer Plugin";
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

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
            editor.RegisterScriptHeader("import void Test();\r\n");
            return 0;
        }

        public int EngineDebugHook(string scriptName, int lineNum, int reserved)
        {
            return 0;
        }

        public void EngineInitGfx(string driverID, System.IntPtr data)
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
            this.engine.RegisterScriptFunction("Test", (TestDel)this.Test);
        }

        #endregion Public Methods

        #region Private Methods

        private void Test()
        {
            if (this.fontRenderer == null)
            {
                this.fontRenderer = new MyFontRenderer(this.engine);
            }
            
            this.engine.ReplaceFontRenderer(0, fontRenderer);
        }

        #endregion Private Methods

        #endregion Methods
    }
}