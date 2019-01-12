using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Drawing;

namespace Njit.Common
{
    public class RegisteredFileType
    {
        [DllImport("shell32.dll", EntryPoint = "ExtractIconA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern IntPtr ExtractIcon(int hInst, string lpszExeFileName, int nIconIndex);

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern uint ExtractIconEx(string szFileName, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

        [DllImport("user32.dll", EntryPoint = "DestroyIcon", SetLastError = true)]
        private static unsafe extern int DestroyIcon(IntPtr hIcon);

        public class EmbeddedIconInfo
        {
            public EmbeddedIconInfo(string fileName, int iconIndex)
            {
                FileName = fileName;
                IconIndex = iconIndex;
            }

            public string FileName;
            public int IconIndex;

            public override string ToString()
            {
                return this.FileName + "," + this.IconIndex.ToString();
            }
        }

        /// <summary>
        /// دریافت آیکن یک پسوند
        /// </summary>
        /// <param name="extension">پسوند</param>
        /// <returns></returns>
        public static EmbeddedIconInfo GetExtensionDefaultIcon(string extension)
        {
            if (string.IsNullOrEmpty(extension))
                throw new ArgumentNullException(extension);
            EmbeddedIconInfo _EmbeddedIconInfo = null;
            RegistryKey classesRoot = Registry.ClassesRoot;
            if (!extension.StartsWith("."))
                extension = "." + extension;
            RegistryKey rkFileType = classesRoot.OpenSubKey(extension);
            if (rkFileType == null)
                return null;
            object defaultValue = rkFileType.GetValue("");
            if (defaultValue == null)
                return null;
            string defaultIcon = defaultValue.ToString() + "\\DefaultIcon";
            RegistryKey rkFileIcon = classesRoot.OpenSubKey(defaultIcon);
            if (rkFileIcon != null)
            {
                object value = rkFileIcon.GetValue("");
                if (value != null)
                {
                    string fileParam = value.ToString().Replace("\"", "");
                    _EmbeddedIconInfo = GetEmbeddedIconInfo(fileParam);
                }
                rkFileIcon.Close();
            }
            rkFileType.Close();
            classesRoot.Close();
            return _EmbeddedIconInfo;
        }

        static List<KeyValuePair<string, EmbeddedIconInfo>> _iconsInfo;
        public static List<KeyValuePair<string, EmbeddedIconInfo>> GetFileTypesDefaultIcon()
        {
            if (_iconsInfo == null)
                _iconsInfo = GetFileTypesDefaultIcon_Internal();
            return _iconsInfo;
        }

        protected static List<KeyValuePair<string, EmbeddedIconInfo>> GetFileTypesDefaultIcon_Internal()
        {
            RegistryKey classesRoot = Registry.ClassesRoot;
            string[] keyNames = classesRoot.GetSubKeyNames();
            List<KeyValuePair<string, EmbeddedIconInfo>> iconsInfo = new List<KeyValuePair<string, EmbeddedIconInfo>>();
            foreach (string keyName in keyNames)
            {
                if (string.IsNullOrEmpty(keyName))
                    continue;
                int indexOfPoint = keyName.IndexOf(".");
                if (indexOfPoint != 0)
                    continue;
                RegistryKey rkFileType = classesRoot.OpenSubKey(keyName);
                if (rkFileType == null)
                    continue;
                object defaultValue = rkFileType.GetValue("");
                if (defaultValue == null)
                    continue;
                string defaultIcon = defaultValue.ToString() + "\\DefaultIcon";
                RegistryKey rkFileIcon = classesRoot.OpenSubKey(defaultIcon);
                if (rkFileIcon != null)
                {
                    object value = rkFileIcon.GetValue("");
                    if (value != null)
                    {
                        string fileParam = value.ToString().Replace("\"", "");
                        iconsInfo.Add(new KeyValuePair<string, EmbeddedIconInfo>(keyName, GetEmbeddedIconInfo(fileParam)));
                    }
                    rkFileIcon.Close();
                }
                rkFileType.Close();
            }
            classesRoot.Close();
            return iconsInfo;
        }

        public static Icon ExtractIconFromFile(EmbeddedIconInfo fileAndParam)
        {
            IntPtr lIcon = ExtractIcon(0, fileAndParam.FileName, fileAndParam.IconIndex);
            return Icon.FromHandle(lIcon);
        }

        public static Icon ExtractIconFromFile(string fileAndParam)
        {
            return ExtractIconFromFile(GetEmbeddedIconInfo(fileAndParam));
        }

        /// <summary>
        /// دریافت آیکن یک فایل
        /// </summary>
        /// <param name="fileAndParam">آدرس فایل و ایندکس آیکن</param>
        /// <param name="isLarge">آیا یک آیک بزرگ است یا خیر</param>
        /// <returns></returns>
        public static Icon ExtractIconFromFile(EmbeddedIconInfo fileAndParam, bool isLarge)
        {
            unsafe
            {
                uint readIconCount = 0;
                IntPtr[] hDummy = new IntPtr[1] { IntPtr.Zero };
                IntPtr[] hIconEx = new IntPtr[1] { IntPtr.Zero };
                try
                {
                    if (isLarge)
                        readIconCount = ExtractIconEx(fileAndParam.FileName, 0, hIconEx, hDummy, 1);
                    else
                        readIconCount = ExtractIconEx(fileAndParam.FileName, 0, hDummy, hIconEx, 1);
                    if (readIconCount > 0 && hIconEx[0] != IntPtr.Zero)
                    {
                        Icon extractedIcon = (Icon)Icon.FromHandle(hIconEx[0]).Clone();
                        return extractedIcon;
                    }
                    else
                        return null;
                }
                catch (Exception exc)
                {
                    throw new ApplicationException("Could not extract icon", exc);
                }
                finally
                {
                    foreach (IntPtr ptr in hIconEx)
                        if (ptr != IntPtr.Zero)
                            DestroyIcon(ptr);
                    foreach (IntPtr ptr in hDummy)
                        if (ptr != IntPtr.Zero)
                            DestroyIcon(ptr);
                }
            }
        }

        public static Icon ExtractIconFromFile(string fileAndParam, bool isLarge)
        {
            return ExtractIconFromFile(GetEmbeddedIconInfo(fileAndParam), isLarge);
        }

        protected static EmbeddedIconInfo GetEmbeddedIconInfo(string fileAndParam)
        {
            EmbeddedIconInfo embeddedIcon = new EmbeddedIconInfo("", 0);
            if (string.IsNullOrEmpty(fileAndParam))
                return embeddedIcon;
            string fileName = String.Empty;
            int iconIndex = 0;
            string iconIndexString = String.Empty;
            int commaIndex = fileAndParam.IndexOf(",");
            if (commaIndex > 0)
            {
                fileName = fileAndParam.Substring(0, commaIndex);
                iconIndexString = fileAndParam.Substring(commaIndex + 1);
            }
            else
                fileName = fileAndParam;
            if (!string.IsNullOrEmpty(iconIndexString))
            {
                iconIndex = int.Parse(iconIndexString);
                if (iconIndex < 0)
                    iconIndex = 0;
            }
            embeddedIcon.FileName = fileName;
            embeddedIcon.IconIndex = iconIndex;
            return embeddedIcon;
        }
    }
}
