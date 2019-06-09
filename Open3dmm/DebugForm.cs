using Open3dmm.Classes;
using Open3dmm.WinApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Open3dmm
{



    public partial class DebugForm : Form
    {
        public DebugForm()
        {
            InitializeComponent();
        }

        public unsafe GPT AllocateGPT(RECTANGLE rect, int bitsPerPixel = 1)
        {
            return NativeObject.FromPointer<GPT>(UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.AllocateGPT, new IntPtr(&rect), new IntPtr(bitsPerPixel)));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RECTANGLE rect = new RECTANGLE(0, 0, 10000, 10000);
            GPT gpt = AllocateGPT(rect, 8);
            
            textBox.Text = "" + gpt.NativeHandle.Address.ToInt32().ToString("X") + " , " + gpt.Vtable.Address.ToInt32().ToString("X") + "Bit Depth: " + gpt.BitDepth + ", " +
                "Width: " + gpt.Width + ", Height: " + gpt.Height + ", Pixel Buffer: " + gpt.PixelBuffer.ToInt32().ToString("X");

            PInvoke.Call(LibraryNames.GDI32, "DeleteObject", gpt.DIBPointer);


            gpt.VirtualCall(0x10); // Free?
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void GptList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GptButton_Click(object sender, EventArgs e)
        {
            GPT selectedGPT = (GPT)this.gptList.SelectedItem;
            if (selectedGPT != null)
            {
                if (selectedGPT.NativeHandle.IsDisposed)
                {
                    MessageBox.Show("Handle disposed");
                    return;
                }
                //IntPtr hdc = Win32.GetDCEx(this.Handle, IntPtr.Zero, Win32.DeviceContextValues.Window);
                //IntPtr hdc = PInvoke.Call(LibraryNames.USER32, "GetDCEx", this.Handle, IntPtr.Zero, (IntPtr)Win32.DeviceContextValues.Window);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromHwnd(this.Handle);

                System.Drawing.Graphics gptGraphics = System.Drawing.Graphics.FromHdc(selectedGPT.DC);

                gptGraphics.DrawLine(System.Drawing.Pens.Aqua, 0, 0, 100, 100);
                

                try
                {
                    IntPtr hdc = g.GetHdc();
                    IntPtr gptHdc = gptGraphics.GetHdc();
                    Win32.BitBlt(hdc, 0, 0, selectedGPT.Width, selectedGPT.Height, gptHdc, 0, 0, Win32.TernaryRasterOperations.SRCCOPY);
                }
                finally
                {
                    gptGraphics.ReleaseHdc();
                    g.ReleaseHdc();
                }


                textBox.Text = "" + selectedGPT.DC.ToString("X");// + " - " + hdc.ToString("X");

            }
        }


        //[DllImport("user32.dll")]
        //private extern static IntPtr SetActiveWindow(IntPtr handle);
        //private const int WM_ACTIVATE = 6;
        //private const int WA_INACTIVE = 0;

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == WM_ACTIVATE)
        //    {
        //        if (((int)m.WParam & 0xFFFF) != WA_INACTIVE)
        //        {
        //            if (m.LParam != IntPtr.Zero)
        //            {
        //                SetActiveWindow(m.LParam);
        //            }
        //            else
        //            {
        //                // Could not find sender, just in-activate it.
        //                SetActiveWindow(IntPtr.Zero);
        //            }
        //            return;
        //        }
        //    }

        //    base.WndProc(ref m);
        //}

    }
}
