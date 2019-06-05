using System;
using System.Runtime.CompilerServices;

namespace Open3dmm
{
    public static unsafe class StructExtensions
    {
#if NATIVEDEP

        public static IntPtr AsPointer<T>(this ref T value) where T : struct
        {
            return new IntPtr(Unsafe.AsPointer(ref value));
        }

        #region ThisCall
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)));
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5, arg6);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5, arg6, arg7);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10);
        }

        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11);
        }
        public static IntPtr ThisCall<T>(ref this T obj, IntPtr address, IntPtr arg1, IntPtr arg2, IntPtr arg3, IntPtr arg4, IntPtr arg5, IntPtr arg6, IntPtr arg7, IntPtr arg8, IntPtr arg9, IntPtr arg10, IntPtr arg11, IntPtr arg12) where T : unmanaged
        {
            return UnmanagedFunctionCall.ThisCall(address, new IntPtr(Unsafe.AsPointer(ref obj)), arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12);
        }

        #endregion  
#endif
    }
}
