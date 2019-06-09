using Open3dmm.WinApi;
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
            NativeAbstraction.WinMainCRTStartup();
            return 0;
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
            return Main(argStr.Substring(argStr.IndexOf(' ') + 1).Split(' '));
        }
    }
}
