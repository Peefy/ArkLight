using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace ArkLight.Util
{
    /// <summary>
    /// 内存共享的C++ winapi 封装
    /// </summary>
    public class MemoryShare
    {
        private static MemoryShare _instance;

        public static MemoryShare Instance =>
            _instance ?? (_instance = new MemoryShare());

        public MemoryShare()
        {
            if (OSUtil.IsWindows() == false)
                throw new Exception("This class can be only use on win os.");
        }

        public class Contants
        {
            public const int ERROR_ALREADY_EXISTS = 183;

            public const int FILE_MAP_COPY = 1;

            public const int FILE_MAP_WRITE = 2;

            public const int FILE_MAP_READ = 4;

            public const int FILE_MAP_ALL_ACCESS = 6;

            public const int PAGE_READONLY = 2;

            public const int PAGE_READWRITE = 4;

            public const int PAGE_WRITECOPY = 8;

            public const int PAGE_EXECUTE = 16;

            public const int PAGE_EXECUTE_READ = 32;

            public const int PAGE_EXECUTE_READWRITE = 64;

            public const int SEC_COMMIT = 134217728;

            public const int SEC_IMAGE = 16777216;

            public const int SEC_NOCACHE = 268435456;

            public const int SEC_RESERVE = 67108864;

            public const int INVALID_HANDLE_VALUE = -1;

            public const int InfoSize = 50;

        }

        private IntPtr _hSharedMemoryFile = IntPtr.Zero;

        private IntPtr _pwData = IntPtr.Zero;

        private IntPtr _pwDataWrite = IntPtr.Zero;

        private IntPtr _pwDataRead = IntPtr.Zero;

        private bool _bInit;

        private int _length;

        private int _count;

        private Semaphore _semRead;

        private Semaphore _semWrite;

        private Semaphore _semWriteLength;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateFileMapping(int hFile, IntPtr lpAttributes, uint flProtect, uint dwMaxSizeHi, uint dwMaxSizeLow, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr OpenFileMapping(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr MapViewOfFile(IntPtr hFileMapping, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool UnmapViewOfFile(IntPtr pvBaseAddress);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern bool CloseHandle(IntPtr handle);

        [DllImport("kernel32")]
        private static extern int GetLastError();

        public IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam, bool isHandle = false)
        {
            return SendMessage(hWnd, Msg, wParam, lParam);
        }

        public IntPtr CreateFileMapping(int hFile, IntPtr lpAttributes, uint flProtect, 
            uint dwMaxSizeHi, uint dwMaxSizeLow, string lpName, bool isHandle = false)
        {
            return CreateFileMapping(hFile, lpAttributes, flProtect, dwMaxSizeHi, dwMaxSizeLow, lpName);
        }

        public IntPtr OpenFileMapping(int dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, 
            string lpName, bool isHandle = false)
        {
            return OpenFileMapping(dwDesiredAccess, bInheritHandle, lpName);
        }

        public IntPtr MapViewOfFile(IntPtr hFileMapping, uint dwDesiredAccess, 
            uint dwFileOffsetHigh, uint dwFileOffsetLow, uint dwNumberOfBytesToMap, bool isHandle = false)
        {
            return MapViewOfFile(hFileMapping, dwDesiredAccess, dwFileOffsetHigh, dwFileOffsetLow, dwNumberOfBytesToMap);
        }

        public bool UnmapViewOfFile(IntPtr pvBaseAddress, bool isHandle = false)
        {
            return UnmapViewOfFile(pvBaseAddress);
        }

        public bool CloseHandle(IntPtr handle, bool isHandle = false)
        {
            return CloseHandle(handle);
        }

        public int GetLastError(bool isHandle = false)
        {
            return GetLastError();
        }

    }
}
