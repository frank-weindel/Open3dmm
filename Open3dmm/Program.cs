using Open3dmm.Classes;
using Open3dmm.WinApi;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace Open3dmm
{
    public class Program
    {
        public static DebugForm debugForm;
        public static int renderCount = 0;
        static int Main(string[] args)
        {
            RuntimeHelpers.RunClassConstructor(typeof(NativeAbstraction).TypeHandle);
            return __WinMainCRTStartup();
        }

        public static int Bootstrap(string pwzArgument)
        {
            // Open Debug Window in new thread so not to interfere with the 3DMM thread
            // Also required for typing to work in the window
            // Use Program.debugForm.BeginInvoke() to mutate any UI elements on the form.
            Task mytask = Task.Run(() =>
            {
                // Give it a name so we can identify it in the debugger.
                Thread.CurrentThread.Name = "Debug Window Thread";
                Program.debugForm = new DebugForm();
                // Display the form and also run the windows message loop to serve it
                Application.Run(Program.debugForm);
            });

            var argStr = Marshal.PtrToStringUni(PInvoke.Call(LibraryNames.KERNEL32, "GetCommandLineW"));
            int exitCode = Main(argStr.Substring(argStr.IndexOf(' ') + 1).Split(' '));
            PInvoke.Call(LibraryNames.KERNEL32, "ExitProcess", new IntPtr(exitCode));
            return exitCode; //Should never be reached.
        }

        [HookFunction(FunctionNames.__WinMainCRTStartup, CallingConvention = CallingConvention.StdCall)]
        public static int __WinMainCRTStartup()
        {
            NativeAbstraction.GameTimer = new GameTimer();
            var envStrings = PInvoke.Call(LibraryNames.KERNEL32, "GetEnvironmentStrings");
            Marshal.WriteIntPtr((IntPtr)0x004EA1A4, envStrings);
            UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.__cinit);
            UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.WinMain, NativeAbstraction.ModuleHandle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero).ToInt32();
            return 0;
        }

        [HookFunction(FunctionNames.AppMainStatic, CallingConvention = CallingConvention.StdCall)]
        public static void AppMainStatic()
        {
            APP.GlobalAPPInstance.AppMain(1, 0, 2);
        }

        [HookFunction(FunctionNames.Malloc, CallingConvention = CallingConvention.StdCall)]
        public static IntPtr Malloc(int size)
        {
            return NativeHandle.Alloc(size).Address;
        }

        [HookFunction(FunctionNames.Free, CallingConvention = CallingConvention.StdCall)]
        public static bool Free(IntPtr address)
        {
            NativeHandle.Free(address);
            return true;
        }

        //[HookFunction(0x0040caa0, CallingConvention = CallingConvention.ThisCall)]
        //public static void UndefinedFunction_0040caa0(NativeObject @this, GNV pGParm2, RECTANGLE unk)
        //{
        //    var mbmp = @this.GetReference<MBMP>(0x138).GetValue();
        //    if (mbmp != null)
        //    {
        //        Console.WriteLine($"{mbmp.QuadIDPair.Value.Quad.ToString()} - {mbmp.QuadIDPair.Value.ID}");
        //        pGParm2.BlitMBMP(mbmp, rnd.Next(-64, 64), rnd.Next(-64, 64));
        //    }
        //}
    }
}
