namespace AGSPluginSharp
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector3
    {
        #region Fixed Fields

        public float X;
        public float Y;
        public float Z;

        #endregion Fixed Fields

        #region Methods

        #region Public Methods

        public unsafe void Add(Vector3* obj)
        {
            this.X += obj->X;
            this.Y += obj->Y;
            this.Z += obj->Z;
        }

        public unsafe void Subtract(Vector3* obj)
        {
            this.X -= obj->X;
            this.Y -= obj->Y;
            this.Z -= obj->Z;
        }

        #endregion Public Methods

        #endregion Methods
    }
}