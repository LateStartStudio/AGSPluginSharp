namespace AGSPluginSharp
{
    using System.Runtime.InteropServices;

    using AGSPluginSharp.Wrapper;

    public class AGSScriptFunctions
    {
        #region Fields

        private readonly AGSEngine engine;

        #endregion Fields

        #region Constructors

        public AGSScriptFunctions(AGSEngine engine)
        {
            this.engine = engine;
        }

        #endregion Constructors

        #region Delegates

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DisplayAtDel(int x, int y, int width, string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DisplayAtYDel(int y, string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DisplayDel(string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DisplayMessageAtYDel(int messageNumber, int yposition);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DisplayMessageDel(int messageNumber);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void DisplayTopBarDel(int y, int textColor, int backColor, string titleText, string message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SetSkipSpeechDel(int newMode);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void SetSpeechStyleDel(SpeechStyle speechStyle);

        #endregion Delegates

        #region Enumerations

        public enum SpeechStyle
        {
            Lucasarts = 0,
            Sierra = 1,
            SierraWithBackground = 2,
            FullScreen = 3,
        }

        #endregion Enumerations

        #region Methods

        #region Public Methods

        //Display (string message, ...)
        public void Display(string message)
        {
            this.GetDelegate<DisplayDel>("Display")(message);
        }

        //DisplayAt(int x, int y, int width, string message, ...)
        public void DisplayAt(int x, int y, int width, string message)
        {
            this.GetDelegate<DisplayAtDel>("DisplayAt")(x, y, width, message);
        }

        //DisplayAtY (int y, string message)
        public void DisplayAtY(int y, string message)
        {
            this.GetDelegate<DisplayAtYDel>("DisplayAtY")(y, message);
        }

        //DisplayMessage (int message_number)
        public void DisplayMessage(int messageNumber)
        {
            this.GetDelegate<DisplayMessageDel>("DisplayMessage")(messageNumber);
        }

        //DisplayMessageAtY (int message_number, int yposition)
        public void DisplayMessageAtY(int messageNumber, int yposition)
        {
            this.GetDelegate<DisplayMessageAtYDel>("DisplayMessageAtY")(messageNumber, yposition);
        }

        //DisplayTopBar(int y, int text_color, int back_color, string titleText, string message, ...)
        public void DisplayTopBar(int y, int textColor, int backColor, string titleText, string message)
        {
            this.GetDelegate<DisplayTopBarDel>("DisplayTopBar")(y, textColor, backColor, titleText, message);
        }

        //SetSkipSpeech (int new_mode)
        public void SetSkipSpeech(int newMode)
        {
            this.GetDelegate<SetSkipSpeechDel>("SetSkipSpeech")(newMode);
        }

        //SetSkipSpeech (int new_mode)
        public void SetSpeechStyle(SpeechStyle speechStyle)
        {
            this.GetDelegate<SetSpeechStyleDel>("SetSpeechStyle")(speechStyle);
        }

        #endregion Public Methods

        #region Private Methods

        private T GetDelegate<T>(string name)
            where T : class
        {
            return (this.engine.GetScriptFunctionAddress(name, typeof(T))) as T;
        }

        #endregion Private Methods

        #endregion Methods
    }
}