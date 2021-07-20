/// Written by: LadyYulia
/// Creation Date: 09th of December 2018
/// Purpose: Controller class for implementing a keyboard hook
#region ========================================================================= USING =====================================================================================
using System;
#endregion

namespace KeyLogger
{
    public class Controller : IDisposable
    {
        #region ============================================================== FIELD MEMBERS ================================================================================
        public static bool isAltDown = false;
        public static bool isCtrlDown = false;
        public static bool isShiftDown = false;
        
        public event EventHandler<KBEventArgs> KeyPressed;
        public KeyStates currentKeyState;

        private GlobalKeyboardHook globalKeyboardHook;
        #endregion

        #region ================================================================= METHODS ===================================================================================
        /// <summary>
        /// Sets up a new keyboard hook
        /// </summary>
        public void SetupKeyboardHooks()
        {
            // instantiate a new global keyboard hook
            globalKeyboardHook = new GlobalKeyboardHook();
            // subscribe tot he KeyboardPressed event
            globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        /// <summary>
        /// Disposes the global keyboard hook
        /// </summary>
        public void Dispose()
        {
            globalKeyboardHook?.Dispose();
        }
        #endregion

        #region ============================================================= EVENT HANDLERS ================================================================================
        /// <summary>
        /// Internal handler for the KeyboardPressed event
        /// </summary>
        /// <param name="e">A custom EventArgs value implemented for the global keyboard hook</param>
        private void OnKeyPressed(GlobalKeyboardHookEventArgs e)
        {
            // create a new custom event args instance and pass the e parameter to it
            KBEventArgs args = new KBEventArgs(currentKeyState);
            args.e = e;
            // trigger the KeyPressed event
            KeyPressed?.Invoke(this, args);
        }

        /// <summary>
        /// Handles KeyboardPressed event
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">An object containing event data</param>
        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e) 
        {
            // assign the current key state based on the processed low-level keyboard hook flags and the virtual code of the event
            // note that a value of 0 on bit 4 of the flag indicates the event was NOT injected!
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 80)
                currentKeyState = KeyStates.PDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 80)
                currentKeyState = KeyStates.PUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 27)
                currentKeyState = KeyStates.EscapeDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 27)
                currentKeyState = KeyStates.EscapeUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 112)
                currentKeyState = KeyStates.F1Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 112)
                currentKeyState = KeyStates.F1Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 113)
                currentKeyState = KeyStates.F2Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 113)
                currentKeyState = KeyStates.F2Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 114)
                currentKeyState = KeyStates.F3Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 114)
                currentKeyState = KeyStates.F3Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 115)
                currentKeyState = KeyStates.F4Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 115)
                currentKeyState = KeyStates.F4Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 116)
                currentKeyState = KeyStates.F5Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 116)
                currentKeyState = KeyStates.F5Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 117)
                currentKeyState = KeyStates.F6Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 117)
                currentKeyState = KeyStates.F6Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 118)
                currentKeyState = KeyStates.F7Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 118)
                currentKeyState = KeyStates.F7Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 119)
                currentKeyState = KeyStates.F8Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 119)
                currentKeyState = KeyStates.F8Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 120)
                currentKeyState = KeyStates.F9Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 120)
                currentKeyState = KeyStates.F9Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 121)
                currentKeyState = KeyStates.F10Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 121)
                currentKeyState = KeyStates.F10Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 122)
                currentKeyState = KeyStates.F11Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 122)
                currentKeyState = KeyStates.F11Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 123)
                currentKeyState = KeyStates.F12Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 123)
                currentKeyState = KeyStates.F12Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 44)
                currentKeyState = KeyStates.PrintScreenDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 44)
                currentKeyState = KeyStates.PrintScreenUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 145)
                currentKeyState = KeyStates.ScrollLockDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 145)
                currentKeyState = KeyStates.ScrollLockUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 19)
                currentKeyState = KeyStates.PauseDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 19)
                currentKeyState = KeyStates.PauseUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 192)
                currentKeyState = KeyStates.TildaDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 192)
                currentKeyState = KeyStates.TildaUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 49)
                currentKeyState = KeyStates.ExclamationDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 49)
                currentKeyState = KeyStates.ExclamationUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 50)
                currentKeyState = KeyStates.AtDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 50)
                currentKeyState = KeyStates.AtUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 51)
                currentKeyState = KeyStates.SharpDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 51)
                currentKeyState = KeyStates.SharpUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 52)
                currentKeyState = KeyStates.DollarDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 52)
                currentKeyState = KeyStates.DollarUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 53)
                currentKeyState = KeyStates.PercentDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 53)
                currentKeyState = KeyStates.PercentUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 54)
                currentKeyState = KeyStates.PowerDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 54)
                currentKeyState = KeyStates.PowerUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 55)
                currentKeyState = KeyStates.AmpDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 55)
                currentKeyState = KeyStates.AmpUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 56)
                currentKeyState = KeyStates.AsterixDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 56)
                currentKeyState = KeyStates.AsterixUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 57)
                currentKeyState = KeyStates.LeftRoundParentesysDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 57)
                currentKeyState = KeyStates.LeftRoundParentesysUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 48)
                currentKeyState = KeyStates.RightRoundParentesysDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 48)
                currentKeyState = KeyStates.RightRoundParentesysUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 189)
                currentKeyState = KeyStates.DashDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 189)
                currentKeyState = KeyStates.DashUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 187)
                currentKeyState = KeyStates.EqualDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 187)
                currentKeyState = KeyStates.EqualUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 8)
                currentKeyState = KeyStates.BackspaceDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 8)
                currentKeyState = KeyStates.BackspaceUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 9)
                currentKeyState = KeyStates.TabDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 9)
                currentKeyState = KeyStates.TabUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 81)
                currentKeyState = KeyStates.QDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 81)
                currentKeyState = KeyStates.QUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 87)
                currentKeyState = KeyStates.WDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 87)
                currentKeyState = KeyStates.WUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 69)
                currentKeyState = KeyStates.EDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 69)
                currentKeyState = KeyStates.EUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 82)
                currentKeyState = KeyStates.RDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 82)
                currentKeyState = KeyStates.RUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 84)
                currentKeyState = KeyStates.TDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 84)
                currentKeyState = KeyStates.TUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 89)
                currentKeyState = KeyStates.YDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 89)
                currentKeyState = KeyStates.YUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 85)
                currentKeyState = KeyStates.UDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 85)
                currentKeyState = KeyStates.UUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 73)
                currentKeyState = KeyStates.IDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 73)
                currentKeyState = KeyStates.IUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 79)
                currentKeyState = KeyStates.ODown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 79)
                currentKeyState = KeyStates.OUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 219)
                currentKeyState = KeyStates.LeftSquareBracketDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 219)
                currentKeyState = KeyStates.LeftSquareBracketUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 221)
                currentKeyState = KeyStates.RightSquareBracketDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 221)
                currentKeyState = KeyStates.RightSquareBracketUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 220)
                currentKeyState = KeyStates.BackslashDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 220)
                currentKeyState = KeyStates.BackslashUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 221)
                currentKeyState = KeyStates.RightSquareBracketDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 221)
                currentKeyState = KeyStates.RightSquareBracketUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 20)
                currentKeyState = KeyStates.CapsDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 20)
                currentKeyState = KeyStates.CapsUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 65)
                currentKeyState = KeyStates.ADown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 65)
                currentKeyState = KeyStates.AUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 83)
                currentKeyState = KeyStates.SDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 83)
                currentKeyState = KeyStates.SUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 68)
                currentKeyState = KeyStates.DDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 68)
                currentKeyState = KeyStates.DUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 70)
                currentKeyState = KeyStates.FDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 70)
                currentKeyState = KeyStates.FUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 71)
                currentKeyState = KeyStates.GDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 71)
                currentKeyState = KeyStates.GUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 72)
                currentKeyState = KeyStates.HDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 72)
                currentKeyState = KeyStates.HUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 74)
                currentKeyState = KeyStates.JDOwn;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 74)
                currentKeyState = KeyStates.JUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 75)
                currentKeyState = KeyStates.KDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 75)
                currentKeyState = KeyStates.KUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 76)
                currentKeyState = KeyStates.LDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 76)
                currentKeyState = KeyStates.LUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 186)
                currentKeyState = KeyStates.SemicolonDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 186)
                currentKeyState = KeyStates.SemicolonUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 222)
                currentKeyState = KeyStates.QuoteDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 222)
                currentKeyState = KeyStates.QuoteUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 13)
                currentKeyState = KeyStates.EnterDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 13)
                currentKeyState = KeyStates.EnterUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 160)
                currentKeyState = KeyStates.LeftShiftDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 160)
                currentKeyState = KeyStates.LeftShiftUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 90)
                currentKeyState = KeyStates.ZDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 90)
                currentKeyState = KeyStates.ZUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 88)
                currentKeyState = KeyStates.XDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 88)
                currentKeyState = KeyStates.XUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 67)
                currentKeyState = KeyStates.CDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 67)
                currentKeyState = KeyStates.CUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 86)
                currentKeyState = KeyStates.VDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 86)
                currentKeyState = KeyStates.VUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 66)
                currentKeyState = KeyStates.BDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 66)
                currentKeyState = KeyStates.BUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 78)
                currentKeyState = KeyStates.NDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 78)
                currentKeyState = KeyStates.NUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 77)
                currentKeyState = KeyStates.MDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 77)
                currentKeyState = KeyStates.Mup;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 188)
                currentKeyState = KeyStates.LeftAngleBracketDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 188)
                currentKeyState = KeyStates.LeftAngleBracketUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 190)
                currentKeyState = KeyStates.RightAngleBracketDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 190)
                currentKeyState = KeyStates.RightAngleBracketUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 191)
                currentKeyState = KeyStates.SlashDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 191)
                currentKeyState = KeyStates.SlashUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 161)
                currentKeyState = KeyStates.RightShiftDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 161)
                currentKeyState = KeyStates.RightShiftUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 162)
                currentKeyState = KeyStates.LeftCtrlDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 162)
                currentKeyState = KeyStates.LeftCtrlUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 91)
                currentKeyState = KeyStates.LeftWinDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 91)
                currentKeyState = KeyStates.LeftWinUp;
            if (e.KeyboardState == SystemKeyState.SysKeyDown && e.KeyboardData.Flags == 32 && e.KeyboardData.VirtualCode == 164)
                currentKeyState = KeyStates.LeftAltDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 164)
                currentKeyState = KeyStates.LeftAltUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 32)
                currentKeyState = KeyStates.SpaceDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 32)
                currentKeyState = KeyStates.SpaceUp;
            if (e.KeyboardState == SystemKeyState.SysKeyDown && e.KeyboardData.Flags == 33 && e.KeyboardData.VirtualCode == 165)
                currentKeyState = KeyStates.RightAltDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 165)
                currentKeyState = KeyStates.RightAltUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 92)
                currentKeyState = KeyStates.RightWinDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 92)
                currentKeyState = KeyStates.RightWinUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 93)
                currentKeyState = KeyStates.FnDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 93)
                currentKeyState = KeyStates.FnUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 163)
                currentKeyState = KeyStates.RightCtrlDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 163)
                currentKeyState = KeyStates.RightCtrlUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 45)
                currentKeyState = KeyStates.InsertDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 45)
                currentKeyState = KeyStates.InsertUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 36)
                currentKeyState = KeyStates.HomeDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 36)
                currentKeyState = KeyStates.HomeUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 33)
                currentKeyState = KeyStates.PageUpDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 33)
                currentKeyState = KeyStates.PageUpUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 46)
                currentKeyState = KeyStates.DeleteDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 46)
                currentKeyState = KeyStates.DeleteUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 35)
                currentKeyState = KeyStates.EndDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 35)
                currentKeyState = KeyStates.EndUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 34)
                currentKeyState = KeyStates.PageDownDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 34)
                currentKeyState = KeyStates.PageDownUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 38)
                currentKeyState = KeyStates.UpArrowDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 38)
                currentKeyState = KeyStates.UpArrowUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 37)
                currentKeyState = KeyStates.LeftArrowDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 37)
                currentKeyState = KeyStates.LeftArrowUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 40)
                currentKeyState = KeyStates.DownArrowDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 40)
                currentKeyState = KeyStates.DownArrowUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 39)
                currentKeyState = KeyStates.RightArrowDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 39)
                currentKeyState = KeyStates.RightArrowUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 144)
                currentKeyState = KeyStates.NumLockDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 144)
                currentKeyState = KeyStates.NumLockUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 111)
                currentKeyState = KeyStates.DivideDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 111)
                currentKeyState = KeyStates.DivideUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 106)
                currentKeyState = KeyStates.MultiplyDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 106)
                currentKeyState = KeyStates.MultiplyUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 109)
                currentKeyState = KeyStates.MinusDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 109)
                currentKeyState = KeyStates.MinusUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 107)
                currentKeyState = KeyStates.PlusDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 107)
                currentKeyState = KeyStates.PlusUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 1 && e.KeyboardData.VirtualCode == 13)
                currentKeyState = KeyStates.NumEnterDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 129 && e.KeyboardData.VirtualCode == 13)
                currentKeyState = KeyStates.NumEnterUp;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 96)
                currentKeyState = KeyStates.Num0Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 96)
                currentKeyState = KeyStates.Num0Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 97)
                currentKeyState = KeyStates.Num1Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 97)
                currentKeyState = KeyStates.Num1Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 98)
                currentKeyState = KeyStates.Num2Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 98)
                currentKeyState = KeyStates.Num2Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 99)
                currentKeyState = KeyStates.Num3Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 99)
                currentKeyState = KeyStates.Num3Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 100)
                currentKeyState = KeyStates.Num4Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 100)
                currentKeyState = KeyStates.Num4Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 101)
                currentKeyState = KeyStates.Num5Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 101)
                currentKeyState = KeyStates.Num5Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 102)
                currentKeyState = KeyStates.Num6Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 102)
                currentKeyState = KeyStates.Num6Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 103)
                currentKeyState = KeyStates.Num7Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 103)
                currentKeyState = KeyStates.Num7Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 104)
                currentKeyState = KeyStates.Num8Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 104)
                currentKeyState = KeyStates.Num8Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 105)
                currentKeyState = KeyStates.Num9Down;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 105)
                currentKeyState = KeyStates.Num9Up;
            if (e.KeyboardState == SystemKeyState.KeyDown && e.KeyboardData.Flags == 0 && e.KeyboardData.VirtualCode == 110)
                currentKeyState = KeyStates.NumDotDown;
            if (e.KeyboardState == SystemKeyState.KeyUp && e.KeyboardData.Flags == 128 && e.KeyboardData.VirtualCode == 110)
                currentKeyState = KeyStates.NumDotUp;
            // get the state of the modifier keys based on the processed low-level keyboard hook flags and the virtual code of the event
            if ((e.KeyboardState == SystemKeyState.KeyDown || e.KeyboardState == SystemKeyState.SysKeyDown) && (e.KeyboardData.Flags == 0 || e.KeyboardData.Flags == 32 || e.KeyboardData.Flags == 33) && (e.KeyboardData.VirtualCode == 164 || e.KeyboardData.VirtualCode == 165))
                isAltDown = true;
            if (e.KeyboardState == SystemKeyState.KeyDown && (e.KeyboardData.Flags == 0 || e.KeyboardData.Flags == 1) && (e.KeyboardData.VirtualCode == 162 || e.KeyboardData.VirtualCode == 163))
                isCtrlDown = true;
            if (e.KeyboardState == SystemKeyState.KeyDown && (e.KeyboardData.Flags == 0 || e.KeyboardData.Flags == 1) && (e.KeyboardData.VirtualCode == 160 || e.KeyboardData.VirtualCode == 161))
                isShiftDown = true;

            if (e.KeyboardState == SystemKeyState.KeyUp && (e.KeyboardData.Flags == 128 || e.KeyboardData.Flags == 129) && (e.KeyboardData.VirtualCode == 164 || e.KeyboardData.VirtualCode == 165))
                isAltDown = false;
            if (e.KeyboardState == SystemKeyState.KeyUp && (e.KeyboardData.Flags == 128 || e.KeyboardData.Flags == 129) && (e.KeyboardData.VirtualCode == 162 || e.KeyboardData.VirtualCode == 163))
                isCtrlDown = false;
            if (e.KeyboardState == SystemKeyState.KeyUp && (e.KeyboardData.Flags == 128 || e.KeyboardData.Flags == 129) && (e.KeyboardData.VirtualCode == 160 || e.KeyboardData.VirtualCode == 161))
                isShiftDown = false;
            OnKeyPressed(e);
            // Console.WriteLine("state: " + e.KeyboardState + " === flags: " + e.KeyboardData.Flags + " === vkey code: " + e.KeyboardData.VirtualCode);
            // for canceling the further event bubbling: e.Handled = true; 
        }
        #endregion
    }
}