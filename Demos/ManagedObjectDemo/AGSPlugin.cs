namespace AGSPluginSharp
{
    using System;
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;

    public unsafe sealed class AGSPlugin
    {
        #region Fields

        private readonly ManagedVector3Interface managedVector3Interface = new ManagedVector3Interface();

        private AGSEngine engine;
        private ManagedVector3Reader managedVector3Reader;

        #endregion Fields

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void AddVector3Del(Vector3* obj, Vector3* obj2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate Vector3* CreateVector3Del(float x, float y, float z);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SubVector3Del(Vector3* obj, Vector3* obj2);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate float Vector3GetDel(Vector3* obj);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void Vector3SetDel(Vector3* obj, float val);

        #endregion Delegates

        #region Properties

        #region Public Properties

        public string Name
        {
            get
            {
                return "ManagedObject Plugin";
            }
        }

        #endregion Public Properties

        #endregion Properties

        #region Methods

        #region Public Methods

        public void EditorLoadGame(byte[] buffer)
        {
        }

        public void EditorProperties(IntPtr parentHandle)
        {
        }

        public byte[] EditorSaveGame(int maxBufferSize)
        {
            return new byte[0];
        }

        public void EditorShutdown()
        {
        }

        public int EditorStartup(AGSEditor editor)
        {
            editor.RegisterScriptHeader(@"
            managed struct Vector3 {
            import attribute float X;
            import attribute float Y;
            import attribute float Z;
            import void Add(Vector3* other);
            import void Subtract(Vector3* other);
            import static Vector3* Create(float X, float Y, float Z);
            };
            ");
            return 0;
        }

        public int EngineDebugHook(string scriptName, int lineNum, int reserved)
        {
            return 0;
        }

        public void EngineInitGfx(string driverID, IntPtr data)
        {
        }

        public int EngineOnEvent(EventType evnt, int data)
        {
            return 0;
        }

        public void EngineShutdown()
        {
        }

        public void EngineStartup(AGSEngine engine)
        {
            this.engine = engine;
            this.managedVector3Reader = new ManagedVector3Reader(this.managedVector3Interface, engine);
            engine.AddManagedObjectReader(ManagedVector3Interface.TypeName, this.managedVector3Reader);

            engine.RegisterScriptFunction("Vector3::Create^3", (CreateVector3Del)this.CreateVector3);
            engine.RegisterScriptFunction("Vector3::Add^1", (AddVector3Del)Vector3_Add);
            engine.RegisterScriptFunction("Vector3::Subtract^1", (SubVector3Del)SubtractPoint);
            engine.RegisterScriptFunction("Vector3::set_X", (Vector3SetDel)Vector3_set_X);
            engine.RegisterScriptFunction("Vector3::get_X", (Vector3GetDel)Vector3_get_X);
            engine.RegisterScriptFunction("Vector3::set_Y", (Vector3SetDel)Vector3_set_Y);
            engine.RegisterScriptFunction("Vector3::get_Y", (Vector3GetDel)Vector3_get_Y);
            engine.RegisterScriptFunction("Vector3::set_Z", (Vector3SetDel)Vector3_set_Z);
            engine.RegisterScriptFunction("Vector3::get_Z", (Vector3GetDel)Vector3_get_Z);
        }

        #endregion Public Methods

        #region Private Static Methods

        private static void SubtractPoint(Vector3* obj, Vector3* obj2)
        {
            obj->Subtract(obj2);
        }

        private static void Vector3_Add(Vector3* obj, Vector3* obj2)
        {
            obj->Add(obj2);
        }

        private static float Vector3_get_X(Vector3* obj)
        {
            return obj->X;
        }

        private static float Vector3_get_Y(Vector3* obj)
        {
            return obj->Y;
        }

        private static float Vector3_get_Z(Vector3* obj)
        {
            return obj->Z;
        }

        private static void Vector3_set_X(Vector3* obj, float val)
        {
            obj->X = val;
        }

        private static void Vector3_set_Y(Vector3* obj, float val)
        {
            obj->Y = val;
        }

        private static void Vector3_set_Z(Vector3* obj, float val)
        {
            obj->Z = val;
        }

        #endregion Private Static Methods

        #region Private Methods

        private Vector3* CreateVector3(float x, float y, float z)
        {
            IntPtr ptr = Marshal.AllocHGlobal(sizeof (Vector3));
            var v = (Vector3*)ptr;
            v->X = x;
            v->Y = y;
            v->Z = z;

            this.engine.RegisterManagedObject(ptr, this.managedVector3Interface);
            return (Vector3*)ptr;
        }

        #endregion Private Methods

        #endregion Methods
    }
}