using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Njit.Common
{
    public static class FontHelper
    {
        /// <summary>
        /// نصب فونت
        /// </summary>
        /// <param name="fontFilePath">مسیر فایل فونت</param>
        /// <param name="fontName">نام فونت</param>
        /// <param name="overwrite">رونویسی شود یا خیر</param>
        /// <returns></returns>
        public static bool InstallFontInWindows(string fontFilePath, string fontName, bool overwrite)
        {
            try
            {
                string fileName = System.IO.Path.GetFileName(fontFilePath);
                string directory = System.IO.Path.GetDirectoryName(fontFilePath).TrimEnd('\\');
                string fontsDir = FolderPath.GetFolderPath(FolderPath.SpecialFolder.Fonts).TrimEnd('\\');
                string systemFontFilePath = System.IO.Path.Combine(fontsDir, fileName);
                int removeCount = 0;
                if (string.Compare(fontsDir, directory, true) != 0)
                {
                    if (!overwrite)
                    {
                        if (System.IO.File.Exists(systemFontFilePath))
                            return true;
                        else
                        {
                            System.IO.File.Copy(fontFilePath, systemFontFilePath, true);
                            fontFilePath = systemFontFilePath;
                        }
                    }
                    else
                    {
                        if (System.IO.File.Exists(systemFontFilePath))
                        {
                            removeCount = 0;
                            while (RemoveFontResource(systemFontFilePath))
                            {
                                removeCount++;
                            }
                            try
                            {
                                System.IO.File.Copy(fontFilePath, systemFontFilePath, true);
                            }
                            catch { }
                            fontFilePath = systemFontFilePath;
                        }
                        else
                        {
                            System.IO.File.Copy(fontFilePath, systemFontFilePath, true);
                            fontFilePath = systemFontFilePath;
                        }
                    }
                }
                if (removeCount > 0)
                {
                    for (int i = 0; i < removeCount; i++)
                    {
                        AddFontResource(fontFilePath);
                    }
                }
                else
                    if (AddFontResource(fontFilePath) == 0) return false;
                SaveFontInRegistry(fontName, fileName);
                BroadcastFontchange();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static void SaveFontInRegistry(string fontName, string fileName)
        {
            Microsoft.Win32.RegistryKey reg = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", true);
            reg.SetValue(fontName + " (TrueType)", fileName);
            reg.Close();
        }

        public static void BroadcastFontchange()
        {
            SendMessage(HWND_BROADCAST, WM_FONTCHANGE, 0, 0);
        }

        public static string GetFontName(string fontFilePath)
        {
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            try
            {
                fontCollection.AddFontFile(fontFilePath);
            }
            catch (System.IO.FileNotFoundException)
            {
                return null;
            }
            return fontCollection.Families[0].Name;
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        const int HWND_BROADCAST = 0xFFFF;
        const int WM_FONTCHANGE = 0x1D;

        [DllImport("gdi32.dll", EntryPoint = "AddFontResourceW", SetLastError = true)]
        public static extern int AddFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                         string lpFileName);

        [DllImport("gdi32.dll", EntryPoint = "RemoveFontResourceW", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool RemoveFontResource([In][MarshalAs(UnmanagedType.LPWStr)]
                                            string lpFileName);
    }
}
