namespace AGSPluginSharp
{
    using System;
    using System.Drawing;

    using AGSPluginSharp.Wrapper;

    using SlimDX;
    using SlimDX.Direct3D9;

    using EventType = AGSPluginSharp.Wrapper.EventType;

    public sealed class AGSPlugin
    {
        #region Fields

        private AGSEngine engine;
        private bool init;
        private Texture tex;
        private VertexDeclaration vertexDecl;
        private VertexBuffer vertices;

        #endregion Fields

        #region Properties

        #region Public Properties

        public string Name
        {
            get
            {
                return "SlimDX Plugin";
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
            Device device = Device.FromPointer(new IntPtr(data));
            switch (evnt)
            {
                case EventType.FinalScreenDraw:
                {
                    int iTime = Environment.TickCount % 4000;
                    float fAngle = iTime * (2.0f * (float)Math.PI) / 4000.0f;
                    device.SetTransform(TransformState.View, Matrix.RotationY(fAngle));
                }
                    break;
                case EventType.PostScreenDraw:
                {
                    if (!this.init)
                    {
                        this.vertices = new VertexBuffer(device, 3 * 12, Usage.WriteOnly, VertexFormat.None, Pool.Default);
                        this.vertices.Lock(0, 0, LockFlags.None).WriteRange(new[]
                                                                            {
                                                                                new Vector3(50, 0, 1f),
                                                                                new Vector3(100, 100, 1f),
                                                                                new Vector3(0, 100, 1f),
                                                                            });
                        this.vertices.Unlock();

                        var vertexElems = new[]
                                          {
                                              new VertexElement(0, 0, DeclarationType.Float3, DeclarationMethod.Default, DeclarationUsage.PositionTransformed, 0),
                                              VertexElement.VertexDeclarationEnd
                                          };
                        this.vertexDecl = new VertexDeclaration(device, vertexElems);

                        this.tex = new Texture(device, 32, 32, 0, Usage.None, Format.A8R8G8B8, Pool.Managed);
                        this.tex.Fill((v1, v2) => Color.White);
                        this.init = true;
                    }

                    device.SetTexture(0, this.tex);
                    VertexDeclaration oldv = device.VertexDeclaration;
                    device.VertexDeclaration = this.vertexDecl;
                    device.SetStreamSource(0, this.vertices, 0, 12);
                    device.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
                    device.VertexDeclaration = oldv;
                    device.SetTransform(TransformState.View, Matrix.Identity);
                }
                    break;
            }
            return 0;
        }

        public void EngineShutdown()
        {
        }

        public void EngineStartup(AGSEngine engine)
        {
            this.engine = engine;
            this.engine.RequestEventHook(EventType.PostScreenDraw);
            this.engine.RequestEventHook(EventType.FinalScreenDraw);
        }

        #endregion Public Methods

        #endregion Methods
    }
}