// See https://aka.ms/new-console-template for more information


using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace SampleNamespace
{
    // process callback function
    public delegate void processDelegate(IntPtr wparam, IntPtr lparam);
    // Easy to retrieve strings, only if the parameters match.
    delegate uint func(IntPtr pabx, IntPtr text, uint length);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct MonOrds
    {
        public int Id;                       // 4 bytes
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string Value;                 // 10 bytes
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string Name;                  // 固定大小字串，16 bytes
    }

    public static class Utils
    {
        public static byte[] StructToBytes<T>(T structure) where T : struct
        {
            int size = Marshal.SizeOf(structure); 
            byte[] bytes = new byte[size];

            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structure, buffer, false); 
                Marshal.Copy(buffer, bytes, 0, size); 
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }

            return bytes;
        }

        public static string Utf8ToUnicode(IntPtr putf8)
        {
            int count = 0;
            byte[] buffer;

            for (count = 0; Marshal.ReadByte(putf8, count) > 0; count++)
            {
            }
            buffer = new byte[count];
            Marshal.Copy(putf8, buffer, 0, count);

            return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }
    }

    internal static class ABXToolkitMethods
    {
        // 初始ABX環境
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void initByCABXToolkit(string applicationDirectory);
        // 啟動ABX可執行物件
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void startByCABXToolkit();
        // 中止ABX可執行物件
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void stopByCABXToolkit();
        // 釋放ABX環境
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void destroyByCABXToolkit();
        // 新增ABX訊息通知
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void addListenerByCABXToolkit(processDelegate notification);
        // 移除ABX訊息通知
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void removeListenerByCABXToolkit(processDelegate notification);
        // 登入ABX服務
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void loginByCABXToolkit(string abusID, ushort abusPort, int productID, int userType, int loginType, 
            string userAccount, string userPassword, int timeout, int aliveTime, byte proxyType, string proxyID, uint proxyPort, 
            string proxyAccount, string proxyPassword);
        // 登出ABX服務
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void logoutByCABXToolkit(string abusID, ushort abusPort);
        // 派分ABX請求代碼
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern ushort dispatchRequestIDByCABXToolkit();
        // 查詢ABX物件介面
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr queryInterfaceByCABXToolkit(string interfaceName);
        // 取得功能代碼
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern int getFunctionIDByICABXResult(IntPtr pabxResult);
        // 取得回報狀態代碼
        [DllImport("ABXToolkit.dll")]
        internal static extern int getStatusIDByICABXResult(IntPtr pabxResult);
        // 取得回報錯誤代碼
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern int getErrorCodeByICABXResult(IntPtr pabxResult);
        // 取得回報錯誤描述
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern uint getErrorDescriptionByICABXResult(IntPtr pabxResult, IntPtr perrorCode, uint length);
        // 取得回報資料
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr getDataByICABXResult(IntPtr pabxResult);
        // Request 移除參考
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void removeReferenceByICABXRequest(IntPtr pabxRequest);
        // Result 移除物件參考
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, 
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void removeReferenceByICABXResult(IntPtr pabxResult);
        // 洗價委託設定
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void setWatchByICABXRequest(
            IntPtr pabxRequest,
            ushort requestID,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] monOrdsData,
            ulong monOrdsDataLength
        );
        // 取得ICABXTagValueItem數量
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern ulong getCountByICABXTagValueOverview(IntPtr picABXTagValueOverview);
        // 經由索引值取得取得ICABXTagValueItem數量項目介面
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr atIndexByICABXTagValueOverview(IntPtr picABXTagValueOverview, ulong ullIndex);
        // 移除ICABXTagValueOverview參考計數
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void removeReferenceByICABXTagValueOverview(IntPtr picABXTagValueOverview);
        // 取得TagNo
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern uint getTagNoByICABXTagValueItem(IntPtr picABXTagValueItem);
        // 取得Tag內容
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr getValueByICABXTagValueItem(IntPtr picABXTagValueItem, byte[]? value, ulong ullDataLength);
        // 移除ICABXTagValueItem參考計數
        [DllImport("ABXToolkit.dll", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true,
            CallingConvention = CallingConvention.StdCall)]
        internal static extern void removeReferenceByICABXTagValueItem(IntPtr picABXTagValueItem);
    }

    public class ABXToolkitClass
    {
        static readonly processDelegate processMethond = new(ProcessMethod);
        public static void Init(string applicationDir)
        {
            ABXToolkitMethods.initByCABXToolkit(applicationDir);
        }
        public static void Start()
        {
            ABXToolkitMethods.startByCABXToolkit();
        }
        public static void AddListener()
        {
            ABXToolkitMethods.addListenerByCABXToolkit(processMethond);
        }
        public static void Login()
        {
            ABXToolkitMethods.loginByCABXToolkit(
                "127.0.0.0",
                12345, 1, 1, 1, "Test", "123TS", 0, 0, 0, "", 0, "", "");
        }
        public static void Logout()
        {
            ABXToolkitMethods.logoutByCABXToolkit("127.0.0.0", 12345);
        }
        public static void RemoveListener()
        {
            ABXToolkitMethods.removeListenerByCABXToolkit(processMethond);
        }
        public static void Stop()
        {
            ABXToolkitMethods.stopByCABXToolkit();
        }
        public static void Destory()
        {
            ABXToolkitMethods.destroyByCABXToolkit();
        }
        public static void SetMonOrds()
        {
            IntPtr pabxRequest = ABXToolkitMethods.queryInterfaceByCABXToolkit("ICABXRequest");
            ushort requestID = ABXToolkitMethods.dispatchRequestIDByCABXToolkit();

            MonOrds monOrdsStruct = new()
            {
                Id = 123,
                Value = "4.567",
                Name = "SampleName"
            };

            byte[] monOrdsData = Utils.StructToBytes(monOrdsStruct);
            ulong dataLength = (ulong)monOrdsData.Length;

            if (IntPtr.Zero != pabxRequest)
            {
                ABXToolkitMethods.setWatchByICABXRequest(pabxRequest, requestID, monOrdsData, dataLength);
                ABXToolkitMethods.removeReferenceByICABXRequest(pabxRequest);
            }
        }
        public static void ProcessMethod(IntPtr wparam, IntPtr lparam)
        {
            IntPtr pabxResult = lparam;
            IntPtr abxTagValueOverview = IntPtr.Zero;
            IntPtr abxTagValueItem;
            IntPtr ptext;
            int errCode;
            uint tagNo, length;
            string text;
            if (IntPtr.Zero == pabxResult)
            {
                return;
            }

            switch (_ = ABXToolkitMethods.getFunctionIDByICABXResult(pabxResult))
            {
                case (int)ConsoleApp1.ABXFUNCTION_ID.ABXFUN_SESSION:
                    switch (_ = ABXToolkitMethods.getStatusIDByICABXResult(pabxResult))
                    {
                        case (int)ConsoleApp1.ABXSTATUS_ID.ABXSTS_LOGIN:
                            errCode = ABXToolkitMethods.getErrorCodeByICABXResult(pabxResult);
                            if ((int)ConsoleApp1.ABXERROR_CODE.NO_ERROR != errCode)
                            {
                                length = ABXToolkitMethods.getErrorDescriptionByICABXResult(pabxResult, IntPtr.Zero, 0);
                                ptext = Marshal.AllocHGlobal((int)(length + 1));
                                _ = ABXToolkitMethods.getErrorDescriptionByICABXResult(pabxResult, ptext, length + 1);
                                text = Utils.Utf8ToUnicode(ptext) + " ";
                                Marshal.FreeHGlobal(ptext);
                                Console.WriteLine($"Login errorCode : {errCode}, errorDes : {text}");
                            } else
                            {
                                Console.WriteLine($"Login success.");
                            }
                             break;
                    }
                    break;
                case (int)ConsoleApp1.ABXFUNCTION_ID.ABXFUN_SET_WATCH:
                    errCode = ABXToolkitMethods.getErrorCodeByICABXResult(pabxResult);
                    if ((int)ConsoleApp1.ABXERROR_CODE.NO_ERROR != errCode)
                    {
                        Console.WriteLine($"set Watch error.");
                    } else
                    {
                        if (IntPtr.Zero != (abxTagValueOverview = ABXToolkitMethods.getDataByICABXResult(pabxResult)))
                        {
                            for (ulong i = 0, len = ABXToolkitMethods.getCountByICABXTagValueOverview(abxTagValueOverview); len > i; i++)
                            {
                                abxTagValueItem = ABXToolkitMethods.atIndexByICABXTagValueOverview(abxTagValueOverview, i);
                                if (IntPtr.Zero != abxTagValueItem) 
                                {
                                    tagNo = ABXToolkitMethods.getTagNoByICABXTagValueItem(abxTagValueItem);
                                    if (tagNo == 8) // 假設tagNo8 需要資料長度去帶出資料
                                    {
                                        // 實際取自上一個項目DataLen, 這邊假設情境要取得的是MonOrds.
                                        ulong dataLength = (ulong)Marshal.SizeOf(typeof(MonOrds));
                                        byte[] buffer = new byte[dataLength];
                                        ABXToolkitMethods.getValueByICABXTagValueItem(abxTagValueItem, buffer, dataLength);
                                        IntPtr ptr = Marshal.AllocHGlobal(buffer.Length);
                                        Marshal.Copy(buffer, 0, ptr, buffer.Length);
                                        MonOrds monOrds = Marshal.PtrToStructure<MonOrds>(ptr);
                                        Marshal.FreeHGlobal(ptr);
                                        Console.WriteLine($"ID: {monOrds.Id}, Value: {monOrds.Value}, Name: {monOrds.Name}");
                                    }
                                    else
                                    {   // 正常取出
                                        ptext = ABXToolkitMethods.getValueByICABXTagValueItem(abxTagValueItem, null, 0);
                                        string tagContent = Marshal.PtrToStringAnsi(ptext)!;
                                        Console.WriteLine($"tagNo: {tagNo}, value: {tagContent}");
                                    }
                                    ABXToolkitMethods.removeReferenceByICABXTagValueItem(abxTagValueItem);
                                }
                            }
                            ABXToolkitMethods.removeReferenceByICABXTagValueOverview(abxTagValueOverview);
                        }
                    }
                    Console.WriteLine("Press <Enter> to exit. ");
                    break;
                default: break;
            }
        }
    }
    public class SampleClass
    {
        static void Main(string[] args)
        {
            ABXToolkitClass.Init(System.IO.Directory.GetCurrentDirectory());
            ABXToolkitClass.Start();
            ABXToolkitClass.AddListener();
            ABXToolkitClass.Login();
            ABXToolkitClass.SetMonOrds();
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            ABXToolkitClass.Logout();
            ABXToolkitClass.RemoveListener();
            ABXToolkitClass.Stop();
            ABXToolkitClass.Destory();
        }
    }
}