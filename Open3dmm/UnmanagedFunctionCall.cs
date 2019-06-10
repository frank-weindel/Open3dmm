using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open3dmm
{
#if NATIVEDEP
    #region ThisCall
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall0(IntPtr ecx);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall1(IntPtr ecx, IntPtr arg1);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall2(IntPtr ecx, IntPtr arg1, IntPtr arg2);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall3(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall4(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall5(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall6(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall7(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall8(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall9(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall10(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall11(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11);
    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    public delegate IntPtr ThisCall12(IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11, IntPtr arg12);
    #endregion

    #region Cdecl
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl0();
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl1(IntPtr arg1);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl2(IntPtr arg1, IntPtr arg2);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl3(IntPtr arg1, IntPtr arg2, IntPtr arg3);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl4(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl5(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl6(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl7(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl8(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl9(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl10(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl11(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11);
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate IntPtr Cdecl12(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11, IntPtr arg12);
    #endregion

    #region StdCall
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall0();
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall1(IntPtr arg1);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall2(IntPtr arg1, IntPtr arg2);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall3(IntPtr arg1, IntPtr arg2, IntPtr arg3);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall4(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall5(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall6(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall7(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall8(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall9(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall10(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall11(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11);
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate IntPtr StdCall12(IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11, IntPtr arg12);
    #endregion

    public static class UnmanagedFunctionCall
    {
        #region ThisCall
        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, params object[] args)
        {
            return ThisCall(address, ecx, args.AsSpan());
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, Span<object> args)
        {
            Span<IntPtr> preparedArgs = stackalloc IntPtr[args.Length];
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == null)
                    preparedArgs[i] = IntPtr.Zero;
                else if (args[i] is IntPtr ptr)
                    preparedArgs[i] = ptr;
                else if (args[i] is NativeObject nato)
                    preparedArgs[i] = nato.NativeHandle.Address;
                else
                    preparedArgs[i] = new IntPtr(Convert.ToInt64(args[i]));
            }
            return ThisCall(address, ecx, preparedArgs);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, Span<IntPtr> args)
        {
            if (args == Span<IntPtr>.Empty)
                return Marshal.GetDelegateForFunctionPointer<ThisCall0>(address).Invoke(ecx);
            switch (args.Length)
            {
                case 1:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall1>(address).Invoke(ecx, args[0]);
                case 2:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall2>(address).Invoke(ecx, args[0], args[1]);
                case 3:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall3>(address).Invoke(ecx, args[0], args[1], args[2]);
                case 4:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall4>(address).Invoke(ecx, args[0], args[1], args[2], args[3]);
                case 5:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall5>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4]);
                case 6:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall6>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4], args[5]);
                case 7:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall7>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4], args[5], args[6]);
                case 8:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall8>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7]);
                case 9:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall9>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8]);
                case 10:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall10>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9]);
                case 11:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall11>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10]);
                case 12:
                    return Marshal.GetDelegateForFunctionPointer<ThisCall12>(address).Invoke(ecx, args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9], args[10], args[11]);
                default: throw new NotSupportedException("Argument count exceeding 12 is not supported");
            }
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx)
        {
            return ThisCall(address, ecx, Span<IntPtr>.Empty);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1)
        {
            unsafe
            {
                return ThisCall(address, ecx, new Span<IntPtr>(&arg1, 1));
            }
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2)
        {
            Span<IntPtr> args = stackalloc IntPtr[2];
            args[0] = arg1;
            args[1] = arg2;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            Span<IntPtr> args = stackalloc IntPtr[3];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4)
        {
            Span<IntPtr> args = stackalloc IntPtr[4];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5)
        {
            Span<IntPtr> args = stackalloc IntPtr[5];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6)
        {
            Span<IntPtr> args = stackalloc IntPtr[6];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            args[5] = arg6;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7)
        {
            Span<IntPtr> args = stackalloc IntPtr[7];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            args[5] = arg6;
            args[6] = arg7;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8)
        {
            Span<IntPtr> args = stackalloc IntPtr[8];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            args[5] = arg6;
            args[6] = arg7;
            args[7] = arg8;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9)
        {
            Span<IntPtr> args = stackalloc IntPtr[9];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            args[5] = arg6;
            args[6] = arg7;
            args[7] = arg8;
            args[8] = arg9;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10)
        {
            Span<IntPtr> args = stackalloc IntPtr[10];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            args[5] = arg6;
            args[6] = arg7;
            args[7] = arg8;
            args[8] = arg9;
            args[9] = arg10;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11)
        {
            Span<IntPtr> args = stackalloc IntPtr[11];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            args[5] = arg6;
            args[6] = arg7;
            args[7] = arg8;
            args[8] = arg9;
            args[9] = arg10;
            args[10] = arg11;
            return ThisCall(address, ecx, args);
        }

        public static IntPtr ThisCall(IntPtr address, IntPtr ecx, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11, IntPtr arg12)
        {
            Span<IntPtr> args = stackalloc IntPtr[12];
            args[0] = arg1;
            args[1] = arg2;
            args[2] = arg3;
            args[3] = arg4;
            args[4] = arg5;
            args[5] = arg6;
            args[6] = arg7;
            args[7] = arg8;
            args[8] = arg9;
            args[9] = arg10;
            args[10] = arg11;
            args[11] = arg12;
            return ThisCall(address, ecx, args);
        }
        #endregion

        #region StdCall
        public static IntPtr StdCall(IntPtr address)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall0>(address).Invoke();
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall1>(address).Invoke(arg1);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall2>(address).Invoke(arg1, arg2);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall3>(address).Invoke(arg1, arg2, arg3);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall4>(address).Invoke(arg1, arg2, arg3, arg4);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall5>(address).Invoke(arg1, arg2, arg3, arg4, arg5);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall6>(address).Invoke(arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall7>(address).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall8>(address).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall9>(address).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall10>(address).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall11>(address).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }

        public static IntPtr StdCall(IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11, IntPtr arg12)
        {
            return Marshal.GetDelegateForFunctionPointer<StdCall12>(address).Invoke(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }
        #endregion
    }
#endif
}
