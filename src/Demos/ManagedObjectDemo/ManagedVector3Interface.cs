namespace AGSPluginSharp
{
    using System;
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;

    public class ManagedVector3Interface : AGSScriptManagedObject
    {
        #region Fields

        public const string TypeName = "Vector3";

        #endregion Fields

        #region Constructors

        public ManagedVector3Interface()
            : base(TypeName)
        {
        }

        #endregion Constructors

        #region Methods

        #region Protected Methods

        protected override int Dispose(IntPtr address, bool force)
        {
            Marshal.FreeHGlobal(address);
            return 1;
        }

        protected override int Serialize(IntPtr address, IntPtr buffer, int bufsize)
        {
            var buf = new byte[Marshal.SizeOf(typeof(Vector3))];
            Marshal.Copy(address, buf, 0, buf.Length);
            Marshal.Copy(buf, 0, buffer, buf.Length);
            return buf.Length;
        }

        #endregion Protected Methods

        #endregion Methods
    }
}