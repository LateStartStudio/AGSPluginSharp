namespace AGSPluginSharp
{
    using System;
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;

    public sealed class AGSPlugin
    {
        #region Fields

        private AGSScriptFunctions agsScriptFunctions;
        private AGSEngine engine;

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
                return "ScriptFunctions Plugin";
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

        public void EngineInitGfx(string driverID, IntPtr data)
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
            this.engine.RegisterScriptFunction("Test", (TestDel)(this.Test));
            this.agsScriptFunctions = new AGSScriptFunctions(engine);
        }

        #endregion Public Methods

        #region Private Methods

        private void Test()
        {
            this.agsScriptFunctions.SetSpeechStyle(AGSScriptFunctions.SpeechStyle.Sierra);
            this.agsScriptFunctions.Display("test");
            this.agsScriptFunctions.DisplayAt(0, 0, 100, "test");
            this.agsScriptFunctions.DisplayAtY(5, "test");
            this.agsScriptFunctions.DisplayMessage(0);
            this.agsScriptFunctions.DisplayMessageAtY(0, 2);
            this.agsScriptFunctions.DisplayTopBar(0, 0, 1, "test", "test");
        }

        #endregion Private Methods

        #endregion Methods
    }
}