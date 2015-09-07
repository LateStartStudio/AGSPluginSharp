/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class AGSGameOptions : IDisposable
    {
        #region Fields

        private HandleRef handle;
        private bool ownsHandle;

        #endregion Fields

        #region Constructors

        internal AGSGameOptions(IntPtr cPtr, bool cMemoryOwn)
        {
            this.ownsHandle = cMemoryOwn;
            this.handle = new HandleRef(this, cPtr);
        }

        ~AGSGameOptions()
        {
            this.Dispose();
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public int BgspeechGameSpeed
        {
            set
            {
                NativeMethods.AGSGameOptions_bgspeech_game_speed_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_bgspeech_game_speed_get(this.handle);
                return ret;
            }
        }

        public int BgspeechStayOnDisplay
        {
            set
            {
                NativeMethods.AGSGameOptions_bgspeech_stay_on_display_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_bgspeech_stay_on_display_get(this.handle);
                return ret;
            }
        }

        public int DebugMode
        {
            set
            {
                NativeMethods.AGSGameOptions_debug_mode_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_debug_mode_get(this.handle);
                return ret;
            }
        }

        public int DisabledUserInterface
        {
            set
            {
                NativeMethods.AGSGameOptions_disabled_user_interface_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_disabled_user_interface_get(this.handle);
                return ret;
            }
        }

        public int FastForward
        {
            set
            {
                NativeMethods.AGSGameOptions_fast_forward_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_fast_forward_get(this.handle);
                return ret;
            }
        }

        public int FollowChangeRoomTimer
        {
            set
            {
                NativeMethods.AGSGameOptions_follow_change_room_timer_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_follow_change_room_timer_get(this.handle);
                return ret;
            }
        }

        public int[] Globalvars
        {
            set
            {
                NativeMethods.AGSGameOptions_globalvars_set(this.handle, value);
            }

            get
            {
                IntPtr cPtr = NativeMethods.AGSGameOptions_globalvars_get(this.handle);
                var retValue = new int[50];
                Marshal.Copy(cPtr, retValue, 0, 50);
                return retValue;
            }
        }

        public int GscriptTimer
        {
            set
            {
                NativeMethods.AGSGameOptions_gscript_timer_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_gscript_timer_get(this.handle);
                return ret;
            }
        }

        public int InCutscene
        {
            set
            {
                NativeMethods.AGSGameOptions_in_cutscene_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_in_cutscene_get(this.handle);
                return ret;
            }
        }

        public int InvItemHit
        {
            set
            {
                NativeMethods.AGSGameOptions_inv_item_hit_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_inv_item_hit_get(this.handle);
                return ret;
            }
        }

        public int InvItemWid
        {
            set
            {
                NativeMethods.AGSGameOptions_inv_item_wid_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_inv_item_wid_get(this.handle);
                return ret;
            }
        }

        public int InvNumdisp
        {
            set
            {
                NativeMethods.AGSGameOptions_inv_numdisp_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_inv_numdisp_get(this.handle);
                return ret;
            }
        }

        public int InvNuminline
        {
            set
            {
                NativeMethods.AGSGameOptions_inv_numinline_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_inv_numinline_get(this.handle);
                return ret;
            }
        }

        public int InvNumorder
        {
            set
            {
                NativeMethods.AGSGameOptions_inv_numorder_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_inv_numorder_get(this.handle);
                return ret;
            }
        }

        public int InvTop
        {
            set
            {
                NativeMethods.AGSGameOptions_inv_top_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_inv_top_get(this.handle);
                return ret;
            }
        }

        public int MaxDialogoptionWidth
        {
            set
            {
                NativeMethods.AGSGameOptions_max_dialogoption_width_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_max_dialogoption_width_get(this.handle);
                return ret;
            }
        }

        public int Messagetime
        {
            set
            {
                NativeMethods.AGSGameOptions_messagetime_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_messagetime_get(this.handle);
                return ret;
            }
        }

        public int Mp3LoopBeforeEnd
        {
            set
            {
                NativeMethods.AGSGameOptions_mp3_loop_before_end_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_mp3_loop_before_end_get(this.handle);
                return ret;
            }
        }

        public int NoHicolorFadein
        {
            set
            {
                NativeMethods.AGSGameOptions_no_hicolor_fadein_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_no_hicolor_fadein_get(this.handle);
                return ret;
            }
        }

        public int NoMultiloopRepeat
        {
            set
            {
                NativeMethods.AGSGameOptions_no_multiloop_repeat_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_no_multiloop_repeat_get(this.handle);
                return ret;
            }
        }

        public int NoTextbgWhenVoice
        {
            set
            {
                NativeMethods.AGSGameOptions_no_textbg_when_voice_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_no_textbg_when_voice_get(this.handle);
                return ret;
            }
        }

        public int RoomHeight
        {
            set
            {
                NativeMethods.AGSGameOptions_room_height_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_room_height_get(this.handle);
                return ret;
            }
        }

        public int RoomscriptFinished
        {
            set
            {
                NativeMethods.AGSGameOptions_roomscript_finished_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_roomscript_finished_get(this.handle);
                return ret;
            }
        }

        public int RoomWidth
        {
            set
            {
                NativeMethods.AGSGameOptions_room_width_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_room_width_get(this.handle);
                return ret;
            }
        }

        public int Score
        {
            set
            {
                NativeMethods.AGSGameOptions_score_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_score_get(this.handle);
                return ret;
            }
        }

        public int SierraInvColor
        {
            set
            {
                NativeMethods.AGSGameOptions_sierra_inv_color_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_sierra_inv_color_get(this.handle);
                return ret;
            }
        }

        public int SkipDisplay
        {
            set
            {
                NativeMethods.AGSGameOptions_skip_display_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_skip_display_get(this.handle);
                return ret;
            }
        }

        public int SpeechMusicDrop
        {
            set
            {
                NativeMethods.AGSGameOptions_speech_music_drop_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_speech_music_drop_get(this.handle);
                return ret;
            }
        }

        public int SpeechTextShadow
        {
            set
            {
                NativeMethods.AGSGameOptions_speech_text_shadow_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_speech_text_shadow_get(this.handle);
                return ret;
            }
        }

        public int SpeechTextwindowGUI
        {
            set
            {
                NativeMethods.AGSGameOptions_speech_textwindow_gui_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_speech_textwindow_gui_get(this.handle);
                return ret;
            }
        }

        public int SwapPortraitSide
        {
            set
            {
                NativeMethods.AGSGameOptions_swap_portrait_side_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_swap_portrait_side_get(this.handle);
                return ret;
            }
        }

        public int TalkanimSpeed
        {
            set
            {
                NativeMethods.AGSGameOptions_talkanim_speed_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_talkanim_speed_get(this.handle);
                return ret;
            }
        }

        public int TextSpeed
        {
            set
            {
                NativeMethods.AGSGameOptions_text_speed_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_text_speed_get(this.handle);
                return ret;
            }
        }

        public int Totalscore
        {
            set
            {
                NativeMethods.AGSGameOptions_totalscore_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_totalscore_get(this.handle);
                return ret;
            }
        }

        public int UnfactorSpeechFromTextlength
        {
            set
            {
                NativeMethods.AGSGameOptions_unfactor_speech_from_textlength_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_unfactor_speech_from_textlength_get(this.handle);
                return ret;
            }
        }

        public int Usedinv
        {
            set
            {
                NativeMethods.AGSGameOptions_usedinv_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_usedinv_get(this.handle);
                return ret;
            }
        }

        public int UsedInvOn
        {
            set
            {
                NativeMethods.AGSGameOptions_used_inv_on_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_used_inv_on_get(this.handle);
                return ret;
            }
        }

        public int Usedmode
        {
            set
            {
                NativeMethods.AGSGameOptions_usedmode_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSGameOptions_usedmode_get(this.handle);
                return ret;
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public void Dispose()
        {
            lock (this)
            {
                if (this.handle.Handle != IntPtr.Zero)
                {
                    if (this.ownsHandle)
                    {
                        this.ownsHandle = false;
                        NativeMethods.delete_AGSGameOptions(this.handle);
                    }
                    this.handle = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        #endregion Public Methods

        #region Internal Static Methods

        internal static HandleRef getCPtr(AGSGameOptions obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.handle;
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}