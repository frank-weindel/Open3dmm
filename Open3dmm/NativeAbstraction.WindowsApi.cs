using Open3dmm.WinApi;
using System;
using System.Threading;
using Microsoft.Win32;

enum RegistryKeys : uint
{
    HKEY_CLASSES_ROOT = 0x80000000,
    HKEY_CURRENT_USER = 0x80000001,
    HKEY_LOCAL_MACHINE = 0x80000002,
    HKEY_USERS = 0x80000003,
    HKEY_PERFORMANCE_DATA = 0x80000004,
    HKEY_PERFORMANCE_TEXT = 0x80000050,
    HKEY_PERFORMANCE_NLSTEXT = 0x80000060,
    HKEY_CURRENT_CONFIG = 0x80000005,
    HKEY_DYN_DATA = 0x80000006,
    HKEY_CURRENT_USER_LOCAL_SETTINGS = 0x80000007
}
namespace Open3dmm
{
    partial class NativeAbstraction
    {
        public static IntPtr MainWindowHandle;
        public static IntPtr MainWindowDC;
        public static IntPtr MainWindowBitmap;
        static partial void SetWindowsApiHooks()
        {
            //ApiDetour.TryHook<StdCall1>(LibraryNames.USER32, "GetDC", (originalFunction) =>
            //{
            //    return (hwnd) =>
            //    {
            //        if (hwnd != IntPtr.Zero && hwnd == MainWindowHandle)
            //        {
            //            if (MainWindowDC == default)
            //            {
            //                var winDC = originalFunction(hwnd);
            //                MainWindowDC = PInvoke.Call(LibraryNames.GDI32, "CreateCompatibleDC", winDC);
            //                MainWindowBitmap = PInvoke.Call(LibraryNames.GDI32, "CreateCompatibleBitmap", winDC, new IntPtr(640), new IntPtr(480));
            //                PInvoke.Call(LibraryNames.GDI32, "SelectObject", MainWindowDC, MainWindowBitmap);
            //            }
            //            return MainWindowDC;
            //        }
            //        else return originalFunction(hwnd);
            //    };
            //}, out _);

            ApiDetour.TryHook<StdCall12>(LibraryNames.USER32, "CreateWindowExA", originalFunction =>
            {
                return (dwExStyle, lpClassName, lpWindowName, dwStyle, X, Y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam) =>
                {
                    // The first time this is called will be on creation of the main 3DMM window.
                    var result = originalFunction(dwExStyle, lpClassName, lpWindowName, dwStyle, X, Y, nWidth, nHeight, hWndParent, hMenu, hInstance, lpParam);
                    if (MainWindowHandle == IntPtr.Zero)
                    {
                        MainWindowHandle = result;
                        InitGraphics();
                    }
                    return result;
                };
            }
            , out _);

            ApiDetour.TryHook<StdCall1>(LibraryNames.KERNEL32, "GetModuleHandleA", originalFunction =>
            {
                return lpModuleName =>
                {
                    if (lpModuleName == IntPtr.Zero)
                        return ModuleHandle;
                    //Console.WriteLine("GetModuleHandleA: " + Marshal.PtrToStringAnsi(lpModuleName));
                    return originalFunction(lpModuleName);
                };
            }, out _);

            ApiDetour.TryHook<StdCall9>(LibraryNames.ADVAPI32, "RegCreateKeyExA", originalFunction =>
            {
                return (hKey, lpSubKey, Reserved, lpClass, dwOptions, samDesired, lpSecurityAttributes, phkResult, lpdwDisposition) =>
                {
                    Console.WriteLine(Enum.GetName(typeof(RegistryKeys), (uint) hKey));
                    Console.WriteLine(System.Runtime.InteropServices.Marshal.PtrToStringAnsi(lpSubKey));
                    return originalFunction(hKey, lpSubKey, Reserved, lpClass, dwOptions, (IntPtr)0x00020019, lpSecurityAttributes, phkResult, lpdwDisposition);
                };
            }, out _);

            ApiDetour.TryHook<StdCall2>(LibraryNames.USER32, "SetCursorPos", originalFunction =>
            {
                return (x, y) =>
                {
                    // A fix for the jumping mouse cursor issue in Windows 10, post Fall Creators Update 2018.
                    if (originalFunction(x, y) == IntPtr.Zero)
                        return IntPtr.Zero;
                    Thread.Sleep(15);
                    return new IntPtr(1);
                };
            }, out _);




        }
    }
}
