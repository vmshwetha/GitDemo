using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Honeywell.Tools.GraphicsMatch.Library
{
    #region IDispatch Interface

    [Guid("00020400-0000-0000-c000-000000000046"),
    InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDispatch
    {
        int GetTypeInfoCount();

        System.Runtime.InteropServices.ComTypes.ITypeInfo GetTypeInfo(
            [MarshalAs(UnmanagedType.U4)] int iTInfo,
            [MarshalAs(UnmanagedType.U4)] int lcid
            );

        [PreserveSig]
        int GetIDsOfNames(
            ref Guid riid,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr)]
            string[] rgsNames,
            int cNames,
            int lcid,
            [MarshalAs(UnmanagedType.LPArray)] 
            int[] rgDispId
            );

        [PreserveSig]
        int Invoke(
            int dispIdMember,
            [In] ref Guid riid,
            [In, MarshalAs(UnmanagedType.U4)] int lcid,
            [In, MarshalAs(UnmanagedType.U4)] int dwFlags,
            [In, Out] tagDISPPARAMS pDispParams,
            [Out, MarshalAs(UnmanagedType.LPArray)] object[] pVarResult,
            [In, Out] tagEXCEPINFO pExcepInfo,
            [Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] pArgErr
            );
    }

    #endregion

    #region tagDISPPARAMS class

    [StructLayout(LayoutKind.Sequential)]
    public sealed class tagDISPPARAMS
    {
        public IntPtr rgvarg;
        public IntPtr rgdispidNamedArgs;
        [MarshalAs(UnmanagedType.U4)]
        public int cArgs;
        [MarshalAs(UnmanagedType.U4)]
        public int cNamedArgs;
        public tagDISPPARAMS()
        { }
    }
    #endregion

    #region tagEXCEPINFO class

    [StructLayout(LayoutKind.Sequential)]
    public class tagEXCEPINFO
    {
        [MarshalAs(UnmanagedType.U2)]
        public short wCode;
        [MarshalAs(UnmanagedType.U2)]
        public short wReserved;
        [MarshalAs(UnmanagedType.BStr)]
        public string bstrSource;
        [MarshalAs(UnmanagedType.BStr)]
        public string bstrDescription;
        [MarshalAs(UnmanagedType.BStr)]
        public string bstrHelpFile;
        [MarshalAs(UnmanagedType.U4)]
        public int dwHelpContext;
        public IntPtr pvReserved;
        public IntPtr pfnDeferredFillIn;
        [MarshalAs(UnmanagedType.U4)]
        public int scode;
        public tagEXCEPINFO()
        {
            this.pvReserved = IntPtr.Zero;
            this.pfnDeferredFillIn = IntPtr.Zero;
        }

    }

    #endregion

    public class Win32
    {
        [Flags]
        public enum InvokeCallType
        {
            DISPATCH_METHOD = 0x1,
            DISPATCH_PROPERTYGET = 0x2,
            DISPATCH_PROPERTYPUT = 0x4,
            DISPATCH_PROPERTYPUTREF = 0x8,
        }

        public const int INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011);
        public const int E_NOTIMPL = unchecked((int)0x80004001);
        public const int S_OK = 0;
        public const int S_FALSE = 1;

        public const int LOCALE_USER_DEFAULT = 0x0400;

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern void VariantInit(HandleRef pObject);

        [DllImport("oleaut32.dll", PreserveSig = false)]
        public static extern void VariantClear(HandleRef pObject);
    }

    #region IDispatchEx Interface

    public enum FlagsDispIDEx : uint
    {
        fdexNameCaseSensitive = 0x00000001,
        fdexNameEnsure = 0x00000002,
        fdexNameImplicit = 0x00000004,
        fdexNameCaseInsensitive = 0x00000008,
        fdexNameInternal = 0x00000010,
        fdexNameNoDynamicProperties = 0x00000020,
    }

    [ComImport, Guid("A6EF9860-C720-11D0-9337-00A0C90DCAA9"),
    TypeLibType((short)0x1000)]
    public interface IDispatchEx
    {
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void GetDispID([In, MarshalAs(UnmanagedType.BStr)] string bstrName,
        [In] uint grfdex, out int pid);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void RemoteInvokeEx([In] int id, [In] uint lcid, [In] uint dwFlags,
        [In] ref System.Runtime.InteropServices.ComTypes.DISPPARAMS pdp,
        [MarshalAs(UnmanagedType.Struct)] out object pvarRes, out System.Runtime.InteropServices.ComTypes.EXCEPINFO pei,
            [In, MarshalAs(UnmanagedType.Interface)] IServiceProvider pspCaller, [In] uint cvarRefArg, [In] ref uint rgiRefArg,
            [In, Out, MarshalAs(UnmanagedType.Struct)] ref object rgvarRefArg);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void DeleteMemberByName([In, MarshalAs(UnmanagedType.BStr)] string
        bstrName, [In] uint grfdex);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void DeleteMemberByDispID([In] int id);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void GetMemberProperties([In] int id, [In] uint grfdexFetch, out uint pgrfdex);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void GetMemberName([In] int id, [MarshalAs(UnmanagedType.BStr)] out string pbstrName);

        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void GetNextDispID([In] uint grfdex, [In] int id, out int pid);
        [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType =
        MethodCodeType.Runtime)]
        void GetNameSpaceParent([MarshalAs(UnmanagedType.IUnknown)] out object ppunk);
    }

    #endregion

}
