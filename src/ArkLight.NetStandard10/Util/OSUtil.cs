using System;
using System.Collections.Generic;
using System.Text;

namespace ArkLight.Util
{
    [Obsolete]
    public class OSUtil
    {
        public static bool IsLinux() => false;

        public static bool IsMacOS() => false;

        public static bool IsIOS() => false;

        public static bool IsAndroid() => false;

        public static bool IsWindows() => true;

        public static OSPlatfom OSPlatfom
        {
            get
            {
                return OSPlatfom.Windows;
            }
        }

    }

    public enum OSPlatfom
    {
        Linux,
        MacOS,
        Windows,
        Android,
        iOS,
        Other
    }

}
