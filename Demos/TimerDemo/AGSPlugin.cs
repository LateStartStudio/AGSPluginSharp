namespace AGSPluginSharp
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;
    using System.Windows.Forms;

    public sealed class AGSPlugin
    {
        #region Fields

        private AGSEngine engine;
        private Dictionary<int, Timer> timers = new Dictionary<int, Timer>();

        #endregion Fields

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int CreateTimerDel(string callback, int interval);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void TimerDel(int timerId);

        #endregion Delegates

        #region Properties

        #region Public Properties

        public string Name
        {
            get
            {
                return "Timer Plugin";
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
            editor.RegisterScriptHeader(
                "import int CreateTimer(String callback, int interval);\r\n" +
                "import void StartTimer(int timerId);\r\n" +
                "import void StopTimer(int timerId);\r\n");
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
            this.engine.RegisterScriptFunction("CreateTimer", (CreateTimerDel)this.CreateTimer);
            this.engine.RegisterScriptFunction("StartTimer", (TimerDel)this.StartTimer);
            this.engine.RegisterScriptFunction("StopTimer", (TimerDel)this.StopTimer);
        }

        #endregion Public Methods

        #region Private Methods

        private int CreateTimer(string callback, int interval)
        {
            Timer t = new Timer();
            t.Interval = interval;
            int index = t.GetHashCode();
            t.Tick += (s, e) => this.engine.QueueGameScriptFunction(callback, true, 1, index);
            timers[index] = t;
            return index;
        }

        private void StartTimer(int timerId)
        {
            timers[timerId].Start();
        }

        private void StopTimer(int timerId)
        {
            timers[timerId].Stop();
        }

        #endregion Private Methods

        #endregion Methods
    }
}