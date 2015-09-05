/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;

    #region Enumerations

    [Flags]
    public enum CharacterFlags
    {
        NoScaling = 1,
        FixView = 2,
        NoInteract = 4,
        NoDiagonal = 8,
        AlwaysIdle = 0x10,
        NoLighting = 0x20,
        NoTurning = 0x40,
        NoWalkBehinds = 0x80,
        FlipSprite = 0x100,
        NoBlocking = 0x200,
        ScaleMoveSpeed = 0x400,
        ScaleVolume = 0x1000,
        HasTint = 0x2000,
        BehindShepherd = 0x4000,
        AwaitingMove = 0x8000,
        MoveNotWalk = 0x10000,
        AntiGlide = 0x20000
    }

    [Flags]
    public enum EventType
    {
        AudioDecode = 0x4000,
        EnterRoom = 0x100,
        FinalScreenDraw = 0x800,
        KeyPress = 1,
        LeaveRoom = 0x80,
        MouseClick = 2,
        PostRestoreGame = 0x40000,
        PostScreenDraw = 4,
        PreGuiDraw = 0x40,
        PreRender = 0x10000,
        PreSaveGame = 0x20000,
        PreScreenDraw = 8,
        RestoreGame = 0x20,
        SaveGame = 0x10,
        ScriptDebug = 0x2000,
        SpriteLoad = 0x8000,
        TooHigh = 0x80000,
        TransitionIn = 0x200,
        TransitionOut = 0x400,
        TranlateText = 0x1000
    }

    public enum FontType
    {
        Invalid = 0,
        Sci = 1,
        Ttf = 2
    }

    public enum FrameFlags
    {
        Mirrored = 1
    }

    public enum MaskType
    {
        Hotspot = 3,
        Regions = 4,
        Walkable = 1,
        Walkbehind = 2
    }

    [Flags]
    public enum MouseCursorFlags : byte
    {
        AnimateMove = 1,
        Disabled = 2,
        Standard = 4,
        OnlyAnimateOverHotSpot = 8
    }

    [Flags]
    public enum ObjectFlags : byte
    {
        NoInteract = 1,
        NoWalkbehinds = 2
    }

    public enum SoundType
    {
        Midi = 6,
        Mod = 7,
        Mp3Static = 3,
        Mp3Stream = 2,
        OggStatic = 5,
        OggStream = 4,
        Wave = 1
    }

    #endregion Enumerations
}