/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;

    using RGiesecke.DllExport;

    public static class Exports
    {
        #region Fields

        private const CallingConvention Convention = CallingConvention.Cdecl;

        private static AGSPlugin Plugin;

        #endregion Fields

        #region Constructors

        static Exports()
        {
            Plugin = new AGSPlugin();
        }

        #endregion Constructors

        #region Methods

        #region Public Static Methods

        [DllExport("AGS_EditorLoadGame", Convention)]
        public static void AGS_EditorLoadGame(IntPtr buffer, int bufsize)
        {
            var buf = new byte[bufsize];
            Marshal.Copy(buffer, buf, 0, bufsize);
            Plugin.EditorLoadGame(buf);
        }

        [DllExport("AGS_EditorProperties", Convention)]
        public static void AGS_EditorProperties(IntPtr parent)
        {
            Plugin.EditorProperties(parent);
        }

        [DllExport("AGS_EditorSaveGame", Convention)]
        public static int AGS_EditorSaveGame(IntPtr buffer, int bufsize)
        {
            var temp = Plugin.EditorSaveGame(bufsize);
            Marshal.Copy(temp, 0, buffer, temp.Length);
            return temp.Length;
        }

        [DllExport("AGS_EditorShutdown", Convention)]
        public static void AGS_EditorShutdown()
        {
            Plugin.EditorShutdown();
        }

        [DllExport("AGS_EditorStartup", Convention)]
        public static int AGS_EditorStartup(IntPtr lpEditor)
        {
            return Plugin.EditorStartup(new AGSEditor(lpEditor, false));
        }

        [DllExport("AGS_EngineDebugHook", Convention)]
        public static int AGS_EngineDebugHook(
            [In] [MarshalAs(UnmanagedType.LPStr)] string scriptName,
            int lineNum, int reserved)
        {
            return Plugin.EngineDebugHook(scriptName, lineNum, reserved);
        }

        [DllExport("AGS_EngineInitGfx", Convention)]
        public static void AGS_EngineInitGfx(
            [In] [MarshalAs(UnmanagedType.LPStr)] string driverID,
            IntPtr data)
        {
            Plugin.EngineInitGfx(driverID, data);
        }

        [DllExport("AGS_EngineOnEvent", Convention)]
        public static int AGS_EngineOnEvent(int evnt, int data)
        {
            return Plugin.EngineOnEvent((EventType)evnt, data);
        }

        [DllExport("AGS_EngineShutdown", Convention)]
        public static void AGS_EngineShutdown()
        {
            Plugin.EngineShutdown();
        }

        [DllExport("AGS_EngineStartup", Convention)]
        public static void AGS_EngineStartup(IntPtr lpEngine)
        {
            var engine = new AGSEngine(lpEngine);
            Plugin.EngineStartup(engine);
        }

        [DllExport("AGS_GetPluginName", Convention)]
        [return: MarshalAs(UnmanagedType.LPStr)]
        public static string AGS_GetPluginName()
        {
            return Plugin.Name;
        }

        [DllExport("AGS_PluginV2", Convention)]
        public static int AGS_PluginV2()
        {
            return 0;
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}