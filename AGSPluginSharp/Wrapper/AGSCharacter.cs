/* This program is free software. It comes without any warranty, to
 * the extent permitted by applicable law. You can redistribute it
 * and/or modify it under the terms of the Do What The Fuck You Want
 * To Public License, Version 2, as published by Sam Hocevar. See
 * http://sam.zoy.org/wtfpl/COPYING for more details. */
namespace AGSPluginSharp.Wrapper
{
    using System;
    using System.Runtime.InteropServices;

    public sealed class AGSCharacter : IDisposable
    {
        #region Fields

        private HandleRef handle;
        private bool ownsHandle;

        #endregion Fields

        #region Constructors

        internal AGSCharacter(IntPtr cPtr, bool cMemoryOwn)
        {
            this.ownsHandle = cMemoryOwn;
            this.handle = new HandleRef(this, cPtr);
        }

        ~AGSCharacter()
        {
            this.Dispose();
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public int ActiveInv
        {
            set
            {
                NativeMethods.AGSCharacter_activeinv_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_activeinv_get(this.handle);
                return ret;
            }
        }

        public short ActX
        {
            set
            {
                NativeMethods.AGSCharacter_actx_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_actx_get(this.handle);
                return ret;
            }
        }

        public short ActY
        {
            set
            {
                NativeMethods.AGSCharacter_acty_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_acty_get(this.handle);
                return ret;
            }
        }

        public short Animating
        {
            set
            {
                NativeMethods.AGSCharacter_animating_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_animating_get(this.handle);
                return ret;
            }
        }

        public short AnimationSpeed
        {
            set
            {
                NativeMethods.AGSCharacter_animspeed_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_animspeed_get(this.handle);
                return ret;
            }
        }

        public short Baseline
        {
            set
            {
                NativeMethods.AGSCharacter_baseline_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_baseline_get(this.handle);
                return ret;
            }
        }

        public int DefView
        {
            set
            {
                NativeMethods.AGSCharacter_defview_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_defview_get(this.handle);
                return ret;
            }
        }

        public CharacterFlags Flags
        {
            set
            {
                NativeMethods.AGSCharacter_flags_set(this.handle, value);
            }
            get
            {
                return NativeMethods.AGSCharacter_flags_get(this.handle);
            }
        }

        public FollowInfo FollowInfo
        {
            set
            {
                NativeMethods.AGSCharacter_followinfo_set(this.handle, value);
            }
            get
            {
                return NativeMethods.AGSCharacter_followinfo_get(this.handle);
            }
        }

        public short Following
        {
            set
            {
                NativeMethods.AGSCharacter_following_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_following_get(this.handle);
                return ret;
            }
        }

        public short Frame
        {
            set
            {
                NativeMethods.AGSCharacter_frame_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_frame_get(this.handle);
                return ret;
            }
        }

        public short IdleLeft
        {
            set
            {
                NativeMethods.AGSCharacter_idleleft_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_idleleft_get(this.handle);
                return ret;
            }
        }

        public short IdleTime
        {
            set
            {
                NativeMethods.AGSCharacter_idletime_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_idletime_get(this.handle);
                return ret;
            }
        }

        public int IdleView
        {
            set
            {
                NativeMethods.AGSCharacter_idleview_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_idleview_get(this.handle);
                return ret;
            }
        }

        public short[] Inv
        {
            set
            {
                if (this.Inv.Length != 301)
                {
                    throw new ArgumentException();
                }

                NativeMethods.AGSCharacter_inv_set(this.handle, value);
            }
            get
            {
                IntPtr cPtr = NativeMethods.AGSCharacter_inv_get(this.handle);
                var retValue = new short[301];
                Marshal.Copy(cPtr, retValue, 0, retValue.Length);
                return retValue;
            }
        }

        public short Loop
        {
            set
            {
                NativeMethods.AGSCharacter_loop_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_loop_get(this.handle);
                return ret;
            }
        }

        public string Name
        {
            set
            {
                NativeMethods.AGSCharacter_name_set(this.handle, value);
            }
            get
            {
                string ret = NativeMethods.AGSCharacter_name_get(this.handle);
                return ret;
            }
        }

        public char On
        {
            set
            {
                NativeMethods.AGSCharacter_on_set(this.handle, value);
            }
            get
            {
                char ret = NativeMethods.AGSCharacter_on_get(this.handle);
                return ret;
            }
        }

        public short PicYOffset
        {
            set
            {
                NativeMethods.AGSCharacter_pic_yoffs_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_pic_yoffs_get(this.handle);
                return ret;
            }
        }

        public int PrevRoom
        {
            set
            {
                NativeMethods.AGSCharacter_prevroom_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_prevroom_get(this.handle);
                return ret;
            }
        }

        public int Room
        {
            set
            {
                NativeMethods.AGSCharacter_room_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_room_get(this.handle);
                return ret;
            }
        }

        public string ScreenName
        {
            set
            {
                NativeMethods.AGSCharacter_scrname_set(this.handle, value);
            }
            get
            {
                string ret = NativeMethods.AGSCharacter_scrname_get(this.handle);
                return ret;
            }
        }

        public int TalkColor
        {
            set
            {
                NativeMethods.AGSCharacter_talkcolor_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_talkcolor_get(this.handle);
                return ret;
            }
        }

        public int TalkView
        {
            set
            {
                NativeMethods.AGSCharacter_talkview_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_talkview_get(this.handle);
                return ret;
            }
        }

        public int ThinkView
        {
            set
            {
                NativeMethods.AGSCharacter_thinkview_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_thinkview_get(this.handle);
                return ret;
            }
        }

        public short Transparency
        {
            set
            {
                NativeMethods.AGSCharacter_transparency_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_transparency_get(this.handle);
                return ret;
            }
        }

        public int View
        {
            set
            {
                NativeMethods.AGSCharacter_view_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_view_get(this.handle);
                return ret;
            }
        }

        public int Wait
        {
            set
            {
                NativeMethods.AGSCharacter_wait_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_wait_get(this.handle);
                return ret;
            }
        }

        public short Walking
        {
            set
            {
                NativeMethods.AGSCharacter_walking_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_walking_get(this.handle);
                return ret;
            }
        }

        public short Walkspeed
        {
            set
            {
                NativeMethods.AGSCharacter_walkspeed_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_walkspeed_get(this.handle);
                return ret;
            }
        }

        public short WalkspeedY
        {
            set
            {
                NativeMethods.AGSCharacter_walkspeed_y_set(this.handle, value);
            }
            get
            {
                short ret = NativeMethods.AGSCharacter_walkspeed_y_get(this.handle);
                return ret;
            }
        }

        public int X
        {
            set
            {
                NativeMethods.AGSCharacter_x_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_x_get(this.handle);
                return ret;
            }
        }

        public int Y
        {
            set
            {
                NativeMethods.AGSCharacter_y_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_y_get(this.handle);
                return ret;
            }
        }

        public int Z
        {
            set
            {
                NativeMethods.AGSCharacter_z_set(this.handle, value);
            }
            get
            {
                int ret = NativeMethods.AGSCharacter_z_get(this.handle);
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
                        NativeMethods.delete_AGSCharacter(this.handle);
                    }
                    this.handle = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        #endregion Public Methods

        #region Internal Static Methods

        internal static HandleRef GetCPtr(AGSCharacter obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.handle;
        }

        #endregion Internal Static Methods

        #endregion Methods
    }
}