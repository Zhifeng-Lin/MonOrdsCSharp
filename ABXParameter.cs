using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // 即時欄位
    public enum ABX_WATCH_ID
    {
        // 基本資料
        ABX_WATCH_STKBASEINFO = 0x00000001,
        // 相關資料
        ABX_WATCH_STKREFINFO = 0x00000002,
        // 第一檔委買賣
        ABX_WATCH_ORDER_1 = 0x00000004,
        // 第二至五檔委買賣
        ABX_WATCH_ORDER_2_5 = 0x00000008,
        // 第六至十檔委買賣
        ABX_WATCH_ORDER_6_10 = 0x00000010,
        // 成交
        ABX_WATCH_TRADE = 0x00000020,
        // 總委買賣
        ABX_WATCH_TOTREFINFO = 0x00000040,
        // 一分鐘
        ABX_WATCH_1MININFO = 0x00000080,
        // 其他
        ABX_WATCH_OTHERS = 0x00000100,
        // 交易所統計
        ABX_WATCH_STATISTIC = 0x00000200,
        // 交易所狀態
        ABX_WATCH_EXCHANGESTATUS = 0x00000400,
        // Broker Queue
        ABX_WATCH_BROKERQUEUE = 0x00000800,
        // 逐筆成交
        ABX_WATCH_DETAILTRADE = 0x00001000,
        // 逐筆委託
        ABX_WATCH_DETAILORDER = 0x00002000,
        // 零股交易
        ABX_WATCH_OLDLOT = 0x00004000,
        // 虛擬撮合
        ABX_WATCH_VIRTUALTRADE = 0x00008000,
        // 一秒快照
        ABX_WATCH_1SECSNAPSHOT = 0x00010000,
        // 委買賣每檔明細
        ABX_WATCH_ORDERLIST = 0x00020000,
        // 權證相關	
        ABX_WATCH_WARRANTINFO = 0x00040000,
        // 一秒快照委買賣
        ABX_WATCH_1SECORDER = 0x00100000,
    }
}
