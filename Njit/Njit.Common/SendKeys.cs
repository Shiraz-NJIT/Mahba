using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Njit.Common
{
    public class SendKeys
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint numberOfInputs, INPUT[] inputs, int sizeOfInputStructure);

        /// <summary>
        /// ارسال کلید به برنامه
        /// </summary>
        /// <param name="keyCode">کلید</param>
        public static void SendKeyDown(System.Windows.Forms.Keys keyCode)
        {
            INPUT input = new INPUT
            {
                type = 1
            };
            input.ki = new KEYBDINPUT();
            input.ki.wVk = (short)keyCode;
            input.ki.wScan = 0;
            input.ki.dwFlags = 0;
            input.ki.time = 0;
            input.ki.dwExtraInfo = IntPtr.Zero;
            INPUT[] inputs = new INPUT[] { input };
            if (SendInput(1, inputs, Marshal.SizeOf(typeof(INPUT))) == 0)
            {
                throw new Exception();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)]
            public uint type;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }
    }
}
