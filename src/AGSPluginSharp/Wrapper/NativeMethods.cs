/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */ 
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Text;

    internal static class NativeMethods
    {
        #region Fields

#pragma warning disable 169
        private static SWIGExceptionHelper swigExceptionHelper = new SWIGExceptionHelper();
        private static SWIGStringHelper swigStringHelper = new SWIGStringHelper();
#pragma warning restore 169

        private const CallingConvention Convention = CallingConvention.StdCall;
        private const string DllName = "PluginAPIWrapper";

        #endregion Fields

        #region Methods

        #region Public Static Methods

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_activeinv_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_activeinv_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_activeinv_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_activeinv_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_actx_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_actx_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_actx_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_actx_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_acty_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_acty_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_acty_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_acty_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_animating_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_animating_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_animating_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_animating_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_animspeed_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_animspeed_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_animspeed_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_animspeed_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_baseline_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_baseline_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_baseline_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_baseline_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_defview_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_defview_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_defview_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_defview_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_flags_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern CharacterFlags AGSCharacter_flags_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_flags_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_flags_set(HandleRef jarg1, CharacterFlags jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_followinfo_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern FollowInfo AGSCharacter_followinfo_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_followinfo_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_followinfo_set(HandleRef jarg1, FollowInfo jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_following_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_following_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_following_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_following_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_frame_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_frame_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_frame_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_frame_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_idleleft_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_idleleft_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_idleleft_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_idleleft_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_idletime_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_idletime_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_idletime_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_idletime_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_idleview_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_idleview_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_idleview_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_idleview_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_inv_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr AGSCharacter_inv_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_inv_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_inv_set(HandleRef jarg1, short[] jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_loop_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_loop_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_loop_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_loop_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_name_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern string AGSCharacter_name_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_name_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_name_set(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_on_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern char AGSCharacter_on_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_on_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_on_set(HandleRef jarg1, char jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_pic_yoffs_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_pic_yoffs_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_pic_yoffs_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_pic_yoffs_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_prevroom_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_prevroom_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_prevroom_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_prevroom_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_reserved2_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr AGSCharacter_reserved2_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_reserved2_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_reserved2_set(HandleRef jarg1, HandleRef jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_reserved_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr AGSCharacter_reserved_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_reserved_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_reserved_set(HandleRef jarg1, HandleRef jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_room_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_room_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_room_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_room_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_scrname_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern string AGSCharacter_scrname_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_scrname_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_scrname_set(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_talkcolor_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_talkcolor_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_talkcolor_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_talkcolor_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_talkview_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_talkview_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_talkview_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_talkview_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_thinkview_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_thinkview_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_thinkview_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_thinkview_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_transparency_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_transparency_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_transparency_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_transparency_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_view_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_view_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_view_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_view_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_wait_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_wait_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_wait_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_wait_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_walking_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_walking_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_walking_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_walking_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_walkspeed_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_walkspeed_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_walkspeed_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_walkspeed_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_walkspeed_y_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSCharacter_walkspeed_y_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_walkspeed_y_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_walkspeed_y_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_x_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_x_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_x_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_x_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_y_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_y_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_y_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_y_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_z_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSCharacter_z_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSCharacter_z_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSCharacter_z_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_b_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSColor_b_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_b_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSColor_b_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_g_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSColor_g_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_g_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSColor_g_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_padding_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSColor_padding_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_padding_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSColor_padding_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_r_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSColor_r_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSColor_r_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSColor_r_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_bgspeech_game_speed_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_bgspeech_game_speed_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_bgspeech_game_speed_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_bgspeech_game_speed_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_bgspeech_stay_on_display_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_bgspeech_stay_on_display_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_bgspeech_stay_on_display_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_bgspeech_stay_on_display_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_debug_mode_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_debug_mode_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_debug_mode_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_debug_mode_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_disabled_user_interface_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_disabled_user_interface_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_disabled_user_interface_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_disabled_user_interface_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_fast_forward_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_fast_forward_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_fast_forward_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_fast_forward_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_follow_change_room_timer_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_follow_change_room_timer_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_follow_change_room_timer_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_follow_change_room_timer_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_globalvars_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr AGSGameOptions_globalvars_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_globalvars_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_globalvars_set(HandleRef jarg1, int[] jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_gscript_timer_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_gscript_timer_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_gscript_timer_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_gscript_timer_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_item_hit_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_inv_item_hit_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_item_hit_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_inv_item_hit_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_item_wid_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_inv_item_wid_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_item_wid_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_inv_item_wid_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_numdisp_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_inv_numdisp_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_numdisp_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_inv_numdisp_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_numinline_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_inv_numinline_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_numinline_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_inv_numinline_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_numorder_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_inv_numorder_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_numorder_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_inv_numorder_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_top_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_inv_top_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_inv_top_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_inv_top_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_in_cutscene_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_in_cutscene_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_in_cutscene_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_in_cutscene_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_max_dialogoption_width_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_max_dialogoption_width_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_max_dialogoption_width_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_max_dialogoption_width_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_messagetime_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_messagetime_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_messagetime_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_messagetime_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_mp3_loop_before_end_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_mp3_loop_before_end_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_mp3_loop_before_end_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_mp3_loop_before_end_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_no_hicolor_fadein_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_no_hicolor_fadein_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_no_hicolor_fadein_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_no_hicolor_fadein_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_no_multiloop_repeat_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_no_multiloop_repeat_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_no_multiloop_repeat_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_no_multiloop_repeat_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_no_textbg_when_voice_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_no_textbg_when_voice_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_no_textbg_when_voice_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_no_textbg_when_voice_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_roomscript_finished_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_roomscript_finished_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_roomscript_finished_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_roomscript_finished_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_room_height_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_room_height_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_room_height_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_room_height_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_room_width_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_room_width_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_room_width_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_room_width_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_score_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_score_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_score_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_score_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_sierra_inv_color_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_sierra_inv_color_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_sierra_inv_color_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_sierra_inv_color_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_skip_display_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_skip_display_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_skip_display_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_skip_display_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_speech_music_drop_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_speech_music_drop_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_speech_music_drop_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_speech_music_drop_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_speech_textwindow_gui_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_speech_textwindow_gui_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_speech_textwindow_gui_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_speech_textwindow_gui_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_speech_text_shadow_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_speech_text_shadow_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_speech_text_shadow_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_speech_text_shadow_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_swap_portrait_side_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_swap_portrait_side_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_swap_portrait_side_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_swap_portrait_side_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_talkanim_speed_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_talkanim_speed_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_talkanim_speed_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_talkanim_speed_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_text_speed_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_text_speed_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_text_speed_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_text_speed_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_totalscore_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_totalscore_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_totalscore_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_totalscore_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_unfactor_speech_from_textlength_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_unfactor_speech_from_textlength_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_unfactor_speech_from_textlength_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_unfactor_speech_from_textlength_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_usedinv_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_usedinv_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_usedinv_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_usedinv_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_usedmode_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_usedmode_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_usedmode_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_usedmode_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_used_inv_on_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSGameOptions_used_inv_on_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSGameOptions_used_inv_on_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSGameOptions_used_inv_on_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_flags_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern char AGSMouseCursor_flags_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_flags_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSMouseCursor_flags_set(HandleRef jarg1, char jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_hotx_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSMouseCursor_hotx_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_hotx_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSMouseCursor_hotx_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_hoty_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSMouseCursor_hoty_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_hoty_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSMouseCursor_hoty_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_name_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern string AGSMouseCursor_name_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_name_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSMouseCursor_name_set(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_pic_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSMouseCursor_pic_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_pic_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSMouseCursor_pic_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_view_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSMouseCursor_view_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSMouseCursor_view_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSMouseCursor_view_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_baseline_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSObject_baseline_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_baseline_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_baseline_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_cycling_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSObject_cycling_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_cycling_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_cycling_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_flags_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSObject_flags_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_flags_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_flags_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_frame_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSObject_frame_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_frame_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_frame_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_loop_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSObject_loop_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_loop_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_loop_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_moving_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSObject_moving_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_moving_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_moving_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_num_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSObject_num_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_num_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_num_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_on_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSObject_on_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_on_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_on_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_overall_speed_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern byte AGSObject_overall_speed_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_overall_speed_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_overall_speed_set(HandleRef jarg1, byte jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_reserved_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr AGSObject_reserved_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_reserved_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_reserved_set(HandleRef jarg1, HandleRef jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_transparent_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSObject_transparent_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_transparent_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_transparent_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_view_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSObject_view_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_view_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_view_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_wait_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSObject_wait_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_wait_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_wait_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_x_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSObject_x_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_x_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_x_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_y_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSObject_y_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSObject_y_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSObject_y_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_flags_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSViewFrame_flags_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_flags_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSViewFrame_flags_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_pic_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSViewFrame_pic_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_pic_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSViewFrame_pic_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_reserved_for_future_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr AGSViewFrame_reserved_for_future_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_reserved_for_future_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSViewFrame_reserved_for_future_set(HandleRef jarg1, ref int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_sound_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int AGSViewFrame_sound_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_sound_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSViewFrame_sound_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_speed_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSViewFrame_speed_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_speed_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSViewFrame_speed_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_xoffs_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSViewFrame_xoffs_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_xoffs_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSViewFrame_xoffs_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_yoffs_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern short AGSViewFrame_yoffs_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_AGSViewFrame_yoffs_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void AGSViewFrame_yoffs_set(HandleRef jarg1, short jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_AGSCharacter")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_AGSCharacter(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_AGSColor")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_AGSColor(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_AGSGameOptions")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_AGSGameOptions(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_AGSMouseCursor")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_AGSMouseCursor(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_AGSObject")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_AGSObject(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_AGSViewFrame")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_AGSViewFrame(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_IAGSEditor")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_IAGSEditor(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_IAGSEngine")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_IAGSEngine(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_IAGSFontRenderer")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_IAGSFontRenderer(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_IAGSManagedObjectReader")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_IAGSManagedObjectReader(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_delete_IAGSScriptManagedObject")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void delete_IAGSScriptManagedObject(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr FontRenderer_Create(IntPtr p1, IntPtr p2, IntPtr p3, IntPtr p4, IntPtr p5, IntPtr p6, IntPtr p7, IntPtr p8);

        [DllImport(DllName, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void FontRenderer_Delete(IntPtr obj);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_GetEditorHandle")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEditor_GetEditorHandle(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_GetWindowHandle")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEditor_GetWindowHandle(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_pluginId_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEditor_pluginId_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_pluginId_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEditor_pluginId_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_RegisterScriptHeader", CharSet = CharSet.Ansi)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEditor_RegisterScriptHeader(HandleRef jarg1, [MarshalAs(UnmanagedType.LPStr)] StringBuilder jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_UnregisterScriptHeader")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEditor_UnregisterScriptHeader(HandleRef jarg1, StringBuilder jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_version_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEditor_version_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEditor_version_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEditor_version_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_AbortGame")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_AbortGame(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_AddManagedObjectReader")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_AddManagedObjectReader(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_BlitBitmap")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_BlitBitmap(HandleRef jarg1, int jarg2, int jarg3, IntPtr jarg4, bool jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_BlitSpriteRotated")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_BlitSpriteRotated(HandleRef jarg1, int jarg2, int jarg3, IntPtr jarg4, int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_BlitSpriteTranslucent")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_BlitSpriteTranslucent(HandleRef jarg1, int jarg2, int jarg3, IntPtr jarg4, int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_BreakIntoDebugger")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_BreakIntoDebugger(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_CallGameScriptFunction__SWIG_0")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_CallGameScriptFunction__SWIG_0(HandleRef jarg1, string jarg2, int jarg3, int jarg4, int jarg5, int jarg6, int jarg7);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_CanRunScriptFunctionNow")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_CanRunScriptFunctionNow(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_CreateBlankBitmap")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_CreateBlankBitmap(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_CreateDynamicSprite")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_CreateDynamicSprite(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_CreateScriptString")]
        [SuppressUnmanagedCodeSecurity]
        public static extern string IAGSEngine_CreateScriptString(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_DecrementManagedObjectRefCount")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_DecrementManagedObjectRefCount(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_DeleteDynamicSprite")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_DeleteDynamicSprite(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_DisableSound")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_DisableSound(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_DrawText")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_DrawText(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5, StringBuilder jarg6);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_DrawTextWrapped")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_DrawTextWrapped(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5, int jarg6, StringBuilder jarg7);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_FRead")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_FRead(HandleRef jarg1, IntPtr jarg2, int jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_FreeBitmap")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_FreeBitmap(HandleRef jarg1, IntPtr jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_FWrite")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_FWrite(HandleRef jarg1, IntPtr jarg2, int jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetAreaScaling")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetAreaScaling(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetBackgroundScene")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetBackgroundScene(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetBitmapDimensions")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetBitmapDimensions(HandleRef jarg1, IntPtr jarg2, out int jarg3, out int jarg4, out int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetBitmapTransparentColor")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetBitmapTransparentColor(HandleRef jarg1, IntPtr jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetCharacter")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetCharacter(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetCurrentBackground")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetCurrentBackground(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetCurrentRoom")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetCurrentRoom(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetEngineVersion")]
        [SuppressUnmanagedCodeSecurity]
        public static extern string IAGSEngine_GetEngineVersion(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetFontType")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetFontType(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetGameOptions")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetGameOptions(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetGraphicsDriverID")]
        [SuppressUnmanagedCodeSecurity]
        public static extern string IAGSEngine_GetGraphicsDriverID(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetManagedObjectAddressByKey")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetManagedObjectAddressByKey(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetManagedObjectKeyByAddress")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetManagedObjectKeyByAddress(HandleRef jarg1, IntPtr jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetMouseCursor")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetMouseCursor(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetMousePosition")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetMousePosition(HandleRef jarg1, out int jarg2, out int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetMovementPathLastWaypoint")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetMovementPathLastWaypoint(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetMovementPathWaypointCount")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetMovementPathWaypointCount(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetMovementPathWaypointLocation")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetMovementPathWaypointLocation(HandleRef jarg1, int jarg2, int jarg3, out int jarg4, out int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetMovementPathWaypointSpeed")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetMovementPathWaypointSpeed(HandleRef jarg1, int jarg2, int jarg3, out int jarg4, out int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetNumBackgrounds")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetNumBackgrounds(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetNumCharacters")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetNumCharacters(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetNumObjects")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetNumObjects(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetObject")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetObject(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetPalette")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetPalette(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetPathToFileInCompiledFolder")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetPathToFileInCompiledFolder(HandleRef jarg1, string jarg2, string jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetPlayerCharacter")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetPlayerCharacter(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetRawBitmapSurface")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetRawBitmapSurface(HandleRef jarg1, IntPtr jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetRawColorComponents")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetRawColorComponents(HandleRef jarg1, int jarg2, int jarg3, out int jarg4, out int jarg5, out int jarg6, out int jarg7);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetRawPixelColor")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetRawPixelColor(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetRoomMask")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetRoomMask(HandleRef jarg1, MaskType jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetSavedData")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetSavedData(HandleRef jarg1, string jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetScreen")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetScreen(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetScreenDimensions")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetScreenDimensions(HandleRef jarg1, out int jarg2, out int jarg3, out int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetScriptFunctionAddress")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetScriptFunctionAddress(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetSpriteGraphic")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetSpriteGraphic(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetSpriteHeight")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetSpriteHeight(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetSpriteWidth")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetSpriteWidth(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetTextExtent")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_GetTextExtent(HandleRef jarg1, int jarg2, string jarg3, out int jarg4, out int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetViewFrame")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetViewFrame(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetVirtualScreen")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_GetVirtualScreen(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_GetWalkbehindBaseline")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_GetWalkbehindBaseline(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_IncrementManagedObjectRefCount")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_IncrementManagedObjectRefCount(HandleRef jarg1, IntPtr jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_IsChannelPlaying")]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool IAGSEngine_IsChannelPlaying(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_IsGamePaused")]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool IAGSEngine_IsGamePaused(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_IsRunningUnderDebugger")]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool IAGSEngine_IsRunningUnderDebugger(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_IsSpriteAlphaBlended")]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool IAGSEngine_IsSpriteAlphaBlended(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_LookupParserWord")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_LookupParserWord(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_MakeRawColorPixel")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_MakeRawColorPixel(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5, int jarg6);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_MarkRegionDirty")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_MarkRegionDirty(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_NotifySpriteUpdated")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_NotifySpriteUpdated(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_PlaySoundChannel")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_PlaySoundChannel(HandleRef jarg1, int jarg2, SoundType jarg3, int jarg4, int jarg5, string jarg6);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_pluginId_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_pluginId_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_pluginId_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_pluginId_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_PollSystem")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_PollSystem(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_PrintDebugConsole")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_PrintDebugConsole(HandleRef jarg1, string jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_QueueGameScriptFunction__SWIG_0")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_QueueGameScriptFunction__SWIG_0(HandleRef jarg1, string jarg2, int jarg3, int jarg4, int jarg5, int jarg6);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_QueueGameScriptFunction__SWIG_1")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_QueueGameScriptFunction__SWIG_1(HandleRef jarg1, string jarg2, int jarg3, int jarg4, int jarg5);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_QueueGameScriptFunction__SWIG_2")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_QueueGameScriptFunction__SWIG_2(HandleRef jarg1, string jarg2, int jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_RegisterManagedObject")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_RegisterManagedObject(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_RegisterScriptFunction")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_RegisterScriptFunction(HandleRef jarg1, IntPtr jarg2, IntPtr jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_RegisterUnserializedObject")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_RegisterUnserializedObject(HandleRef jarg1, int jarg2, IntPtr jarg3, IntPtr jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_ReleaseBitmapSurface")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_ReleaseBitmapSurface(HandleRef jarg1, IntPtr jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_ReplaceFontRenderer")]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr IAGSEngine_ReplaceFontRenderer(HandleRef jarg1, int jarg2, IntPtr jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_RequestEventHook")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_RequestEventHook(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_RoomToViewport")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_RoomToViewport(HandleRef jarg1, ref int jarg2, ref int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_SetMousePosition")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_SetMousePosition(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_SetPalette")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_SetPalette(HandleRef jarg1, int jarg2, int jarg3, IntPtr jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_SetSpriteAlphaBlended")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_SetSpriteAlphaBlended(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_SetVirtualScreen")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_SetVirtualScreen(HandleRef jarg1, IntPtr jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_SimulateMouseClick")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_SimulateMouseClick(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_UnrequestEventHook")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_UnrequestEventHook(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_version_get")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSEngine_version_get(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_version_set")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_version_set(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSEngine_ViewportToRoom")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSEngine_ViewportToRoom(HandleRef jarg1, ref int jarg2, ref int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_AdjustYCoordinateForFont")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSFontRenderer_AdjustYCoordinateForFont(HandleRef jarg1, ref int jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_EnsureTextValidForFont")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSFontRenderer_EnsureTextValidForFont(HandleRef jarg1, string jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_FreeMemory")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSFontRenderer_FreeMemory(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_GetTextHeight")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSFontRenderer_GetTextHeight(HandleRef jarg1, string jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_GetTextWidth")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSFontRenderer_GetTextWidth(HandleRef jarg1, string jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_LoadFromDisk")]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool IAGSFontRenderer_LoadFromDisk(HandleRef jarg1, int jarg2, int jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_RenderText")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSFontRenderer_RenderText(HandleRef jarg1, string jarg2, int jarg3, IntPtr jarg4, int jarg5, int jarg6, int jarg7);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSFontRenderer_SupportsExtendedCharacters")]
        [SuppressUnmanagedCodeSecurity]
        public static extern bool IAGSFontRenderer_SupportsExtendedCharacters(HandleRef jarg1, int jarg2);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSManagedObjectReader_Unserialize")]
        [SuppressUnmanagedCodeSecurity]
        public static extern void IAGSManagedObjectReader_Unserialize(HandleRef jarg1, int jarg2, IntPtr jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSScriptManagedObject_Dispose")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSScriptManagedObject_Dispose(HandleRef jarg1, IntPtr jarg2, bool jarg3);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSScriptManagedObject_GetType")]
        [SuppressUnmanagedCodeSecurity]
        public static extern string IAGSScriptManagedObject_GetType(HandleRef jarg1);

        [DllImport(DllName, CallingConvention = Convention, EntryPoint = "CSharp_IAGSScriptManagedObject_Serialize")]
        [SuppressUnmanagedCodeSecurity]
        public static extern int IAGSScriptManagedObject_Serialize(HandleRef jarg1, IntPtr jarg2, string jarg3, int jarg4);

        [DllImport(DllName, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ManagedObjectReader_Create(IntPtr unserializeCallback);

        [DllImport(DllName, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void ManagedObjectReader_Delete(IntPtr obj);

        [DllImport(DllName, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern IntPtr ScriptManagedObject_Create(IntPtr disposeCallback, IntPtr getTypeCallback, IntPtr serializeCallback);

        [DllImport(DllName, CallingConvention = Convention)]
        [SuppressUnmanagedCodeSecurity]
        public static extern void ScriptManagedObject_Delete(IntPtr obj);

        #endregion Public Static Methods

        #endregion Methods

        #region Nested Types

        public class SWIGPendingException
        {
            #region Fields

            private static int numExceptionsPending;
            [ThreadStatic]
            private static Exception pendingException;

            #endregion Fields

            #region Properties

            #region Public Static Properties

            public static bool Pending
            {
                get
                {
                    bool pending = false;
                    if (numExceptionsPending > 0)
                        if (pendingException != null)
                            pending = true;
                    return pending;
                }
            }

            #endregion Public Static Properties

            #endregion Properties

            #region Methods

            #region Public Static Methods

            public static Exception Retrieve()
            {
                Exception e = null;
                if (numExceptionsPending > 0)
                {
                    if (pendingException != null)
                    {
                        e = pendingException;
                        pendingException = null;
                        lock (typeof(NativeMethods))
                        {
                            numExceptionsPending--;
                        }
                    }
                }
                return e;
            }

            public static void Set(Exception e)
            {
                if (pendingException != null)
                    throw new ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + pendingException + ")", e);
                pendingException = e;
                lock (typeof(NativeMethods))
                {
                    numExceptionsPending++;
                }
            }

            #endregion Public Static Methods

            #endregion Methods
        }

        private sealed class SWIGExceptionHelper
        {
            #region Fields

            private static readonly ExceptionDelegate ApplicationDelegate = SetPendingApplicationException;
            private static readonly ExceptionArgumentDelegate ArgumentDelegate = SetPendingArgumentException;
            private static readonly ExceptionArgumentDelegate ArgumentNullDelegate = SetPendingArgumentNullException;
            private static readonly ExceptionArgumentDelegate ArgumentOutOfRangeDelegate = SetPendingArgumentOutOfRangeException;
            private static readonly ExceptionDelegate ArithmeticDelegate = SetPendingArithmeticException;
            private static readonly ExceptionDelegate DivideByZeroDelegate = SetPendingDivideByZeroException;
            private static readonly ExceptionDelegate IndexOutOfRangeDelegate = SetPendingIndexOutOfRangeException;
            private static readonly ExceptionDelegate InvalidCastDelegate = SetPendingInvalidCastException;
            private static readonly ExceptionDelegate InvalidOperationDelegate = SetPendingInvalidOperationException;
            private static readonly ExceptionDelegate IODelegate = SetPendingIOException;
            private static readonly ExceptionDelegate NullReferenceDelegate = SetPendingNullReferenceException;
            private static readonly ExceptionDelegate OutOfMemoryDelegate = SetPendingOutOfMemoryException;
            private static readonly ExceptionDelegate OverflowDelegate = SetPendingOverflowException;
            private static readonly ExceptionDelegate SystemDelegate = SetPendingSystemException;

            #endregion Fields

            #region Constructors

            static SWIGExceptionHelper()
            {
                SWIGRegisterExceptionCallbacks_agsplugin(
                    ApplicationDelegate,
                    ArithmeticDelegate,
                    DivideByZeroDelegate,
                    IndexOutOfRangeDelegate,
                    InvalidCastDelegate,
                    InvalidOperationDelegate,
                    IODelegate,
                    NullReferenceDelegate,
                    OutOfMemoryDelegate,
                    OverflowDelegate,
                    SystemDelegate);

                SWIGRegisterExceptionCallbacksArgument_agsplugin(
                    ArgumentDelegate,
                    ArgumentNullDelegate,
                    ArgumentOutOfRangeDelegate);
            }

            #endregion Constructors

            #region Delegates

            private delegate void ExceptionArgumentDelegate(string message, string paramName);

            private delegate void ExceptionDelegate(string message);

            #endregion Delegates

            #region Methods

            #region Public Static Methods

            [DllImport(DllName, CallingConvention = Convention, EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_agsplugin")]
            [SuppressUnmanagedCodeSecurity]
            private static extern void SWIGRegisterExceptionCallbacksArgument_agsplugin(
                ExceptionArgumentDelegate argumentDelegate,
                ExceptionArgumentDelegate argumentNullDelegate,
                ExceptionArgumentDelegate argumentOutOfRangeDelegate);

            [DllImport(DllName, CallingConvention = Convention, EntryPoint = "SWIGRegisterExceptionCallbacks_agsplugin")]
            [SuppressUnmanagedCodeSecurity]
            private static extern void SWIGRegisterExceptionCallbacks_agsplugin(
                ExceptionDelegate applicationDelegate,
                ExceptionDelegate arithmeticDelegate,
                ExceptionDelegate divideByZeroDelegate,
                ExceptionDelegate indexOutOfRangeDelegate,
                ExceptionDelegate invalidCastDelegate,
                ExceptionDelegate invalidOperationDelegate,
                ExceptionDelegate ioDelegate,
                ExceptionDelegate nullReferenceDelegate,
                ExceptionDelegate outOfMemoryDelegate,
                ExceptionDelegate overflowDelegate,
                ExceptionDelegate systemExceptionDelegate);

            #endregion Public Static Methods

            #region Private Static Methods

            private static void SetPendingApplicationException(string message)
            {
                SWIGPendingException.Set(new ApplicationException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingArgumentException(string message, string paramName)
            {
                SWIGPendingException.Set(new ArgumentException(message, paramName, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingArgumentNullException(string message, string paramName)
            {
                Exception e = SWIGPendingException.Retrieve();
                if (e != null)
                    message = message + " Inner Exception: " + e.Message;
                SWIGPendingException.Set(new ArgumentNullException(paramName, message));
            }

            private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
            {
                Exception e = SWIGPendingException.Retrieve();
                if (e != null)
                    message = message + " Inner Exception: " + e.Message;
                SWIGPendingException.Set(new ArgumentOutOfRangeException(paramName, message));
            }

            private static void SetPendingArithmeticException(string message)
            {
                SWIGPendingException.Set(new ArithmeticException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingDivideByZeroException(string message)
            {
                SWIGPendingException.Set(new DivideByZeroException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingIndexOutOfRangeException(string message)
            {
                SWIGPendingException.Set(new IndexOutOfRangeException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingInvalidCastException(string message)
            {
                SWIGPendingException.Set(new InvalidCastException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingInvalidOperationException(string message)
            {
                SWIGPendingException.Set(new InvalidOperationException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingIOException(string message)
            {
                SWIGPendingException.Set(new IOException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingNullReferenceException(string message)
            {
                SWIGPendingException.Set(new NullReferenceException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingOutOfMemoryException(string message)
            {
                SWIGPendingException.Set(new OutOfMemoryException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingOverflowException(string message)
            {
                SWIGPendingException.Set(new OverflowException(message, SWIGPendingException.Retrieve()));
            }

            private static void SetPendingSystemException(string message)
            {
                SWIGPendingException.Set(new SystemException(message, SWIGPendingException.Retrieve()));
            }

            #endregion Private Static Methods

            #endregion Methods
        }

        private sealed class SWIGStringHelper
        {
            #region Fields

            private static readonly SWIGStringDelegate StringDelegate = CreateString;

            #endregion Fields

            #region Constructors

            static SWIGStringHelper()
            {
                SWIGRegisterStringCallback_agsplugin(StringDelegate);
            }

            #endregion Constructors

            #region Delegates

            private delegate string SWIGStringDelegate(string message);

            #endregion Delegates

            #region Methods

            #region Public Static Methods

            [DllImport(DllName, CallingConvention = Convention, EntryPoint = "SWIGRegisterStringCallback_agsplugin")]
            [SuppressUnmanagedCodeSecurity]
            private static extern void SWIGRegisterStringCallback_agsplugin(SWIGStringDelegate stringDelegate);

            #endregion Public Static Methods

            #region Private Static Methods

            private static string CreateString(string cString)
            {
                return cString;
            }

            #endregion Private Static Methods

            #endregion Methods
        }

        #endregion Nested Types
    }
}