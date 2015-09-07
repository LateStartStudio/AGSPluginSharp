/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;

    public sealed class AGSEngine
    {
        #region Fields

        private readonly List<Delegate> delList = new List<Delegate>();
        private readonly HandleRef handle;

        #endregion Fields

        #region Constructors

        internal AGSEngine(IntPtr cPtr)
        {
            this.handle = new HandleRef(this, cPtr);
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public int PluginId
        {
            get
            {
                int ret = NativeMethods.IAGSEngine_pluginId_get(this.handle);
                return ret;
            }
        }

        public int Version
        {
            get
            {
                int ret = NativeMethods.IAGSEngine_version_get(this.handle);
                return ret;
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public void AbortGame(string reason)
        {
            NativeMethods.IAGSEngine_AbortGame(this.handle, reason);
        }

        public void AddManagedObjectReader(string typeName, AGSManagedObjectReader reader)
        {
            NativeMethods.IAGSEngine_AddManagedObjectReader(this.handle, Marshal.StringToHGlobalAnsi(typeName), reader.Handle);
        }

        public void BlitBitmap(int x, int y, IntPtr arg2, bool masked)
        {
            NativeMethods.IAGSEngine_BlitBitmap(this.handle, x, y, arg2, masked);
        }

        public void BlitSpriteRotated(int x, int y, IntPtr arg2, int angle)
        {
            NativeMethods.IAGSEngine_BlitSpriteRotated(this.handle, x, y, arg2, angle);
        }

        public void BlitSpriteTranslucent(int x, int y, IntPtr arg2, int trans)
        {
            NativeMethods.IAGSEngine_BlitSpriteTranslucent(this.handle, x, y, arg2, trans);
        }

        public void BreakIntoDebugger()
        {
            NativeMethods.IAGSEngine_BreakIntoDebugger(this.handle);
        }

        public int CallGameScriptFunction(string name, bool globalScript, int numArgs, int arg1, int arg2, int arg3)
        {
            return NativeMethods.IAGSEngine_CallGameScriptFunction__SWIG_0(this.handle, name, globalScript ? 1 : 0, numArgs, arg1, arg2, arg3);
        }

        public int CallGameScriptFunction(string name, bool globalScript, int numArgs, int arg1, int arg2)
        {
            return this.CallGameScriptFunction(name, globalScript, numArgs, arg1, arg2, 0);
        }

        public int CallGameScriptFunction(string name, bool globalScript, int numArgs, int arg1)
        {
            return this.CallGameScriptFunction(name, globalScript, numArgs, arg1, 0, 0);
        }

        public int CallGameScriptFunction(string name, bool globalScript, int numArgs)
        {
            return this.CallGameScriptFunction(name, globalScript, numArgs, 0, 0, 0);
        }

        public bool CanRunScriptFunctionNow()
        {
            return NativeMethods.IAGSEngine_CanRunScriptFunctionNow(this.handle) == 1;
        }

        public IntPtr CreateBlankBitmap(int width, int height, int coldep)
        {
            return NativeMethods.IAGSEngine_CreateBlankBitmap(this.handle, width, height, coldep);
        }

        public int CreateDynamicSprite(int coldepth, int width, int height)
        {
            return NativeMethods.IAGSEngine_CreateDynamicSprite(this.handle, coldepth, width, height);
        }

        public string CreateScriptString(string fromText)
        {
            return NativeMethods.IAGSEngine_CreateScriptString(this.handle, fromText);
        }

        public int DecrementManagedObjectRefCount(string address)
        {
            return NativeMethods.IAGSEngine_DecrementManagedObjectRefCount(this.handle, address);
        }

        public void DeleteDynamicSprite(int slot)
        {
            NativeMethods.IAGSEngine_DeleteDynamicSprite(this.handle, slot);
        }

        public void DisableSound()
        {
            NativeMethods.IAGSEngine_DisableSound(this.handle);
        }

        public void DrawText(int x, int y, int font, int color, string text)
        {
            NativeMethods.IAGSEngine_DrawText(this.handle, x, y, font, color, new StringBuilder(text));
        }

        public void DrawTextWrapped(int x, int y, int width, int font, int color, string text)
        {
            NativeMethods.IAGSEngine_DrawTextWrapped(this.handle, x, y, width, font, color, new StringBuilder(text));
        }

        public int FRead(IntPtr arg0, int arg1, int arg2)
        {
            return NativeMethods.IAGSEngine_FRead(this.handle, arg0, arg1, arg2);
        }

        public void FreeBitmap(IntPtr arg0)
        {
            NativeMethods.IAGSEngine_FreeBitmap(this.handle, arg0);
        }

        public int FWrite(IntPtr arg0, int arg1, int arg2)
        {
            return NativeMethods.IAGSEngine_FWrite(this.handle, arg0, arg1, arg2);
        }

        public int GetAreaScaling(int x, int y)
        {
            return NativeMethods.IAGSEngine_GetAreaScaling(this.handle, x, y);
        }

        public IntPtr GetBackgroundScene(int frame)
        {
            return NativeMethods.IAGSEngine_GetBackgroundScene(this.handle, frame);
        }

        public int GetBitmapColorDepth(IntPtr bmp)
        {
            int width, height, coldepth;
            NativeMethods.IAGSEngine_GetBitmapDimensions(this.handle, bmp, out width, out height, out coldepth);
            return coldepth;
        }

        public void GetBitmapDimensions(IntPtr bmp, out int width, out int height, out int coldepth)
        {
            NativeMethods.IAGSEngine_GetBitmapDimensions(this.handle, bmp, out width, out height, out coldepth);
        }

        public int GetBitmapTransparentColor(IntPtr arg0)
        {
            return NativeMethods.IAGSEngine_GetBitmapTransparentColor(this.handle, arg0);
        }

        public AGSCharacter GetCharacter(int arg0)
        {
            IntPtr cPtr = NativeMethods.IAGSEngine_GetCharacter(this.handle, arg0);
            AGSCharacter ret = (cPtr == IntPtr.Zero) ? null : new AGSCharacter(cPtr, false);
            return ret;
        }

        public int GetCurrentBackground()
        {
            return NativeMethods.IAGSEngine_GetCurrentBackground(this.handle);
        }

        public int GetCurrentRoom()
        {
            return NativeMethods.IAGSEngine_GetCurrentRoom(this.handle);
        }

        public string GetEngineVersion()
        {
            return NativeMethods.IAGSEngine_GetEngineVersion(this.handle);
        }

        public FontType GetFontType(int fontNum)
        {
            return (FontType)NativeMethods.IAGSEngine_GetFontType(this.handle, fontNum);
        }

        public AGSGameOptions GetGameOptions()
        {
            IntPtr cPtr = NativeMethods.IAGSEngine_GetGameOptions(this.handle);
            AGSGameOptions ret = (cPtr == IntPtr.Zero) ? null : new AGSGameOptions(cPtr, false);
            return ret;
        }

        public string GetGraphicsDriverID()
        {
            return NativeMethods.IAGSEngine_GetGraphicsDriverID(this.handle);
        }

        public IntPtr GetManagedObjectAddressByKey(int key)
        {
            return NativeMethods.IAGSEngine_GetManagedObjectAddressByKey(this.handle, key);
        }

        public int GetManagedObjectKeyByAddress(IntPtr address)
        {
            return NativeMethods.IAGSEngine_GetManagedObjectKeyByAddress(this.handle, address);
        }

        public AGSMouseCursor GetMouseCursor(int cursor)
        {
            IntPtr cPtr = NativeMethods.IAGSEngine_GetMouseCursor(this.handle, cursor);
            AGSMouseCursor ret = (cPtr == IntPtr.Zero) ? null : new AGSMouseCursor(cPtr, false);
            return ret;
        }

        public void GetMousePosition(out int x, out int y)
        {
            NativeMethods.IAGSEngine_GetMousePosition(this.handle, out x, out y);
        }

        public int GetMovementPathLastWaypoint(int pathId)
        {
            return NativeMethods.IAGSEngine_GetMovementPathLastWaypoint(this.handle, pathId);
        }

        public int GetMovementPathWaypointCount(int pathId)
        {
            return NativeMethods.IAGSEngine_GetMovementPathWaypointCount(this.handle, pathId);
        }

        public void GetMovementPathWaypointLocation(int pathId, int waypoint, out int x, out int y)
        {
            NativeMethods.IAGSEngine_GetMovementPathWaypointLocation(this.handle, pathId, waypoint, out x, out y);
        }

        public void GetMovementPathWaypointSpeed(int pathId, int waypoint, out int xSpeed, out int ySpeed)
        {
            NativeMethods.IAGSEngine_GetMovementPathWaypointSpeed(this.handle, pathId, waypoint, out xSpeed, out ySpeed);
        }

        public int GetNumBackgrounds()
        {
            return NativeMethods.IAGSEngine_GetNumBackgrounds(this.handle);
        }

        public int GetNumCharacters()
        {
            return NativeMethods.IAGSEngine_GetNumCharacters(this.handle);
        }

        public int GetNumObjects()
        {
            return NativeMethods.IAGSEngine_GetNumObjects(this.handle);
        }

        public AGSObject GetObject(int arg0)
        {
            IntPtr cPtr = NativeMethods.IAGSEngine_GetObject(this.handle, arg0);
            AGSObject ret = (cPtr == IntPtr.Zero) ? null : new AGSObject(cPtr, false);
            return ret;
        }

        public unsafe AGSColor[] GetPalette()
        {
            IntPtr cPtr = NativeMethods.IAGSEngine_GetPalette(this.handle);
            var color = (AGSColor*)cPtr;
            var ret = new AGSColor[256];
            for (int i = 0; i < 256; i++)
            {
                ret[i] = *color;
                color++;
            }

            return ret;
        }

        public void GetPathToFileInCompiledFolder(string fileName, string buffer)
        {
            NativeMethods.IAGSEngine_GetPathToFileInCompiledFolder(this.handle, fileName, buffer);
        }

        public int GetPlayerCharacter()
        {
            return NativeMethods.IAGSEngine_GetPlayerCharacter(this.handle);
        }

        public IntPtr GetRawBitmapSurface(IntPtr arg0)
        {
            return NativeMethods.IAGSEngine_GetRawBitmapSurface(this.handle, arg0);
        }

        public void GetRawColorComponents(int coldepth, int color, out int red, out int green, out int blue, out int alpha)
        {
            NativeMethods.IAGSEngine_GetRawColorComponents(this.handle, coldepth, color, out red, out green, out blue, out alpha);
        }

        public int GetRawPixelColor(int color)
        {
            return NativeMethods.IAGSEngine_GetRawPixelColor(this.handle, color);
        }

        public IntPtr GetRoomMask(MaskType which)
        {
            return NativeMethods.IAGSEngine_GetRoomMask(this.handle, which);
        }

        public int GetSavedData(string buffer, int bufsize)
        {
            return NativeMethods.IAGSEngine_GetSavedData(this.handle, buffer, bufsize);
        }

        public IntPtr GetScreen()
        {
            return NativeMethods.IAGSEngine_GetScreen(this.handle);
        }

        public void GetScreenDimensions(out int width, out int height, out int coldepth)
        {
            NativeMethods.IAGSEngine_GetScreenDimensions(this.handle, out width, out height, out coldepth);
        }

        public Delegate GetScriptFunctionAddress(string funcName, Type type)
        {
            return Marshal.GetDelegateForFunctionPointer(NativeMethods.IAGSEngine_GetScriptFunctionAddress(this.handle, funcName), type);
        }

        public IntPtr GetSpriteGraphic(int arg0)
        {
            return NativeMethods.IAGSEngine_GetSpriteGraphic(this.handle, arg0);
        }

        public int GetSpriteHeight(int arg0)
        {
            return NativeMethods.IAGSEngine_GetSpriteHeight(this.handle, arg0);
        }

        public int GetSpriteWidth(int arg0)
        {
            return NativeMethods.IAGSEngine_GetSpriteWidth(this.handle, arg0);
        }

        public void GetTextExtent(int font, string text, out int width, out int height)
        {
            NativeMethods.IAGSEngine_GetTextExtent(this.handle, font, text, out width, out height);
        }

        public AGSViewFrame GetViewFrame(int view, int loop, int frame)
        {
            IntPtr cPtr = NativeMethods.IAGSEngine_GetViewFrame(this.handle, view, loop, frame);
            AGSViewFrame ret = (cPtr == IntPtr.Zero) ? null : new AGSViewFrame(cPtr);
            return ret;
        }

        public IntPtr GetVirtualScreen()
        {
            return NativeMethods.IAGSEngine_GetVirtualScreen(this.handle);
        }

        public int GetWalkbehindBaseline(int walkbehind)
        {
            return NativeMethods.IAGSEngine_GetWalkbehindBaseline(this.handle, walkbehind);
        }

        public int IncrementManagedObjectRefCount(IntPtr address)
        {
            return NativeMethods.IAGSEngine_IncrementManagedObjectRefCount(this.handle, address);
        }

        public bool IsChannelPlaying(int channel)
        {
            return NativeMethods.IAGSEngine_IsChannelPlaying(this.handle, channel);
        }

        public bool IsGamePaused()
        {
            return NativeMethods.IAGSEngine_IsGamePaused(this.handle);
        }

        public bool IsRunningUnderDebugger()
        {
            return NativeMethods.IAGSEngine_IsRunningUnderDebugger(this.handle);
        }

        public bool IsSpriteAlphaBlended(int slot)
        {
            return NativeMethods.IAGSEngine_IsSpriteAlphaBlended(this.handle, slot);
        }

        public int LookupParserWord(string word)
        {
            return NativeMethods.IAGSEngine_LookupParserWord(this.handle, word);
        }

        public int MakeRawColorPixel(int coldepth, int red, int green, int blue, int alpha)
        {
            return NativeMethods.IAGSEngine_MakeRawColorPixel(this.handle, coldepth, red, green, blue, alpha);
        }

        public void MarkRegionDirty(int left, int top, int right, int bottom)
        {
            NativeMethods.IAGSEngine_MarkRegionDirty(this.handle, left, top, right, bottom);
        }

        public void NotifySpriteUpdated(int slot)
        {
            NativeMethods.IAGSEngine_NotifySpriteUpdated(this.handle, slot);
        }

        public void PlaySoundChannel(int channel, SoundType soundType, int volume, int loop, string filename)
        {
            NativeMethods.IAGSEngine_PlaySoundChannel(this.handle, channel, soundType, volume, loop, filename);
        }

        public void PollSystem()
        {
            NativeMethods.IAGSEngine_PollSystem(this.handle);
        }

        public void PrintDebugConsole(string text)
        {
            NativeMethods.IAGSEngine_PrintDebugConsole(this.handle, text);
        }

        public void QueueGameScriptFunction(string name, bool globalScript, int numArgs, int arg1, int arg2)
        {
            NativeMethods.IAGSEngine_QueueGameScriptFunction__SWIG_0(this.handle, name, globalScript ? 1 : 0, numArgs, arg1, arg2);
        }

        public void QueueGameScriptFunction(string name, bool globalScript, int numArgs, int arg1)
        {
            QueueGameScriptFunction(name, globalScript, numArgs, arg1, 0);
        }

        public void QueueGameScriptFunction(string name, bool globalScript, int numArgs)
        {
            QueueGameScriptFunction(name, globalScript, numArgs, 0);
        }

        public int RegisterManagedObject(IntPtr arg0, AGSScriptManagedObject callback)
        {
            return NativeMethods.IAGSEngine_RegisterManagedObject(this.handle, arg0, callback.Handle);
        }

        public void RegisterScriptFunction(string name, Delegate del)
        {
            this.delList.Add(del);
            IntPtr address = Marshal.GetFunctionPointerForDelegate(del);
            NativeMethods.IAGSEngine_RegisterScriptFunction(this.handle, Marshal.StringToHGlobalAnsi(name), address);
        }

        public void RegisterUnserializedObject(int key, IntPtr arg1, AGSScriptManagedObject callback)
        {
            NativeMethods.IAGSEngine_RegisterUnserializedObject(this.handle, key, arg1, callback.Handle);
        }

        public void ReleaseBitmapSurface(IntPtr arg0)
        {
            NativeMethods.IAGSEngine_ReleaseBitmapSurface(this.handle, arg0);
        }

        public void ReplaceFontRenderer(int fontNumber, AGSFontRenderer newRenderer)
        {
            NativeMethods.IAGSEngine_ReplaceFontRenderer(this.handle, fontNumber, newRenderer.Handle);
        }

        public void RequestEventHook(EventType arg0)
        {
            NativeMethods.IAGSEngine_RequestEventHook(this.handle, (int)arg0);
        }

        public void RoomToViewport(ref int x, ref int y)
        {
            NativeMethods.IAGSEngine_RoomToViewport(this.handle, ref x, ref y);
        }

        public void SetMousePosition(int x, int y)
        {
            NativeMethods.IAGSEngine_SetMousePosition(this.handle, x, y);
        }

        public unsafe void SetPalette(int start, int finish, AGSColor[] arg2)
        {
            if (arg2.Length != 256)
            {
                throw new ArgumentException("arg2");
            }

            fixed (AGSColor* ptr = arg2)
            {
                NativeMethods.IAGSEngine_SetPalette(this.handle, start, finish, new IntPtr(ptr));
            }
        }

        public void SetSpriteAlphaBlended(int slot, int isAlphaBlended)
        {
            NativeMethods.IAGSEngine_SetSpriteAlphaBlended(this.handle, slot, isAlphaBlended);
        }

        public void SetVirtualScreen(IntPtr arg0)
        {
            NativeMethods.IAGSEngine_SetVirtualScreen(this.handle, arg0);
        }

        public void SimulateMouseClick(int button)
        {
            NativeMethods.IAGSEngine_SimulateMouseClick(this.handle, button);
        }

        public void UnrequestEventHook(int arg0)
        {
            NativeMethods.IAGSEngine_UnrequestEventHook(this.handle, arg0);
        }

        public void ViewportToRoom(ref int x, ref int y)
        {
            NativeMethods.IAGSEngine_ViewportToRoom(this.handle, ref x, ref y);
        }

        #endregion Public Methods

        #endregion Methods
    }
}