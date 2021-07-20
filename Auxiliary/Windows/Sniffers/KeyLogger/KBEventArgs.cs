/// Written by: LadyYulia
/// Creation Date: 09th of December 2018
/// Purpose: Custom EventArgs class implementation
#region ========================================================================= USING =====================================================================================
using System;
#endregion

namespace KeyLogger
{
    public class KBEventArgs : EventArgs
    {
        #region ============================================================== FIELD MEMBERS ================================================================================
        public GlobalKeyboardHookEventArgs e;
        #endregion

        #region ================================================================ PROPERTIES =================================================================================
        public KeyStates CurrentKey { get; set; }
        #endregion

        #region ================================================================== CTOR =====================================================================================
        /// <summary>
        /// Overload C-tor
        /// </summary>
        /// <param name="currentKeyStates">The current key states enumeration</param>
        public KBEventArgs(KeyStates currentKeyStates)
        { 
            CurrentKey = currentKeyStates; 
        }
        #endregion
    }
}