using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Njit.Common
{
    public class SingleInstance
    {
        public SingleInstance(string assemblyGuid)
        {
            this.assemblyGuid = assemblyGuid;
            WM_SHOWFIRSTINSTANCE = Win32.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", assemblyGuid);
        }

        public static int WM_SHOWFIRSTINSTANCE;
        Mutex mutex;
        string assemblyGuid;

        private bool _IsMainInstance;
        public bool IsMainInstance
        {
            get
            {
                return _IsMainInstance;
            }
        }

        public bool Start()
        {
            string mutexName = String.Format("Local\\{0}", assemblyGuid);
            mutex = new Mutex(true, mutexName, out _IsMainInstance);
            return _IsMainInstance;
        }

        public void ShowFirstInstance()
        {
            Win32.PostMessage((IntPtr)Win32.HWND_BROADCAST, WM_SHOWFIRSTINSTANCE, IntPtr.Zero, IntPtr.Zero);
        }

        public void Stop()
        {
            mutex.ReleaseMutex();
        }
    }
}
