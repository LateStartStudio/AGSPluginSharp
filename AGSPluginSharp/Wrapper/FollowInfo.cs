namespace AGSPluginSharp.Wrapper
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct FollowInfo
    {
        #region Fixed Fields

        private readonly byte eagerness;
        private readonly byte dist;

        #endregion Fixed Fields

        #region Constructors

        public FollowInfo(byte eagerness, byte dist)
        {
            this.eagerness = eagerness;
            this.dist = dist;
        }

        #endregion Constructors

        #region Properties

        #region Public Properties

        public byte Dist
        {
            get
            {
                return this.dist;
            }
        }

        public byte Eagerness
        {
            get
            {
                return this.eagerness;
            }
        }

        #endregion Public Properties

        #endregion Properties
    }
}