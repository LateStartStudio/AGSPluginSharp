/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp
{
    using System;

    using AGSPluginSharp.Wrapper;

    public sealed class AGSPlugin
    {
        #region Fields

        private AGSEngine engine;

        #endregion Fields

        #region Properties

        #region Public Properties

        public string Name
        {
            get
            {
                return "C# AGS Plugin";
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
        }

        #endregion Public Methods

        #endregion Methods
    }
}