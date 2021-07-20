/// Written by: LadyYulia
/// Creation Date: 27th of December, 2020
/// Purpose: View code behind for the MainWindow window
#region ========================================================================= USING =====================================================================================
using System;
using System.Windows;
#endregion

namespace KeyLogger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ============================================================== FIELD MEMBERS ================================================================================
        Controller controller = new Controller();
        #endregion

        #region ================================================================== CTOR =====================================================================================
        /// <summary>
        /// Default C-tor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            controller.SetupKeyboardHooks();
            controller.KeyPressed += Controller_KeyPressed;
        }
        #endregion

        #region ============================================================= EVENT HANDLERS ================================================================================
        /// <summary>
        /// Handles the controller KeyPressed event
        /// </summary>
        private void Controller_KeyPressed(object sender, KBEventArgs e)
        {
            // display the captured key at the keyboard
            Console.WriteLine(e.CurrentKey);
            if (e.CurrentKey == KeyStates.F3Down)
            {               
                e.e.Handled = true;
            }
        }
        #endregion
    }
}
