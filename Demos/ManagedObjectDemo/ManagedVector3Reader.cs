namespace AGSPluginSharp
{
    using System;
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;

    public class ManagedVector3Reader : AGSManagedObjectReader
    {
        #region Fields

        private readonly AGSEngine engine;
        private readonly ManagedVector3Interface managedVector3Interface;

        #endregion Fields

        #region Constructors

        public ManagedVector3Reader(ManagedVector3Interface managedVector3Interface, AGSEngine engine)
        {
            this.managedVector3Interface = managedVector3Interface;
            this.engine = engine;
        }

        #endregion Constructors

        #region Methods

        #region Public Methods

        public unsafe override void Unserialize(int key, IntPtr serializedData, int dataSize)
        {
            IntPtr ptr = Marshal.AllocHGlobal(sizeof (Vector3));
            var data = (Vector3*)serializedData;

            ((Vector3*)ptr)->X = data->X;
            ((Vector3*)ptr)->Y = data->Y;
            ((Vector3*)ptr)->Z = data->Z;
            this.engine.RegisterUnserializedObject(key, ptr, this.managedVector3Interface);
        }

        #endregion Public Methods

        #endregion Methods
    }
}