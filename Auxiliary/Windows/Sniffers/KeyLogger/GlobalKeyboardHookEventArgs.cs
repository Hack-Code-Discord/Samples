/// Written by: LadyYulia
/// Creation Date: 09th of December 2018
/// Purpose: Custom implemementation for HandledEventArgs (provides data for events that can be handled completely in an event handler)
#region ========================================================================= USING =====================================================================================
using System.ComponentModel;
#endregion

namespace KeyLogger
{
    public class GlobalKeyboardHookEventArgs : HandledEventArgs
    {
        #region ================================================================ PROPERTIES =================================================================================
        public SystemKeyState KeyboardState { get; private set; }
        public LowLevelKeyboardInputEvent KeyboardData { get; private set; }
        #endregion

        #region ================================================================== CTOR =====================================================================================
        /// <summary>
        /// Overload C-tor
        /// </summary>
        /// <param name="keyboardData">Information about a low-level keyboard input event</param>
        /// <param name="keyboardState">Information about a system key state</param>
        public GlobalKeyboardHookEventArgs(LowLevelKeyboardInputEvent keyboardData, SystemKeyState keyboardState)
        {
            KeyboardData = keyboardData;
            KeyboardState = keyboardState;
        }
        #endregion
    }
}