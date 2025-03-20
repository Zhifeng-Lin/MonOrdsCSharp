using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum ABXFUNCTION_ID
    {
        ABXFUN_UNKNOW = 0x00000000,                // 未知功能
        ABXFUN_SESSION,                             // 線程
        ABXFUN_SUBSCRIBE_QUOTE,                     // 訂閱即時報價
        ABXFUN_SUBSCRIBE_SMARTSHORT,                
        ABXFUN_SUBSCRIBE_SMARTRANK,                 
        ABXFUN_SUBSCRIBE_SMARTMASTER,               
        ABXFUN_SUBSCRIBE_ABUSBULLETIN,              
        ABXFUN_SUBSCRIBE_EXCHANGEBULLETIN,          
        ABXFUN_SUBSCRIBE_NEWS,                     
        ABXFUN_SUBSCRIBE_PRODUCTBULLETIN,           
        ABXFUN_SUBSCRIBE_MARKETREPORT,              
        ABXFUN_SUBSCRIBE_ADVERTISEMENT,             
        ABXFUN_SUBSCRIBE_TRADEREPORT,               
        ABXFUN_SUBSCRIBE_TECHNICALINDEX,			
        ABXFUN_REBUILD_TRADE,                      
        ABXFUN_REBUILD_MINUTETRADE,                
        ABXFUN_REBUILD_PRICETRADE,                 
        ABXFUN_REBUILD_TOTALREFERENCE,             
        ABXFUN_REBUILD_STATISTIC,                   
        ABXFUN_REBUILD_DETAILORDER,                
        ABXFUN_REBUILD_DETAILTRADE,                
        ABXFUN_REBUILD_OLDLOTTRADE,                
        ABXFUN_REBUILD_VIRTUALTRADE,                
        ABXFUN_REBUILD_SMARTSHORT,                 
        ABXFUN_REBUILD_SMARTRANK,                  
        ABXFUN_REBUILD_SMARTMASTER,               
        ABXFUN_REBUILD_EXCHANGEBULLETIN,           
        ABXFUN_REBUILD_HISTORYEXCHANGEBULLETIN,     
        ABXFUN_REBUILD_NEWS,                       
        ABXFUN_REBUILD_HISTORYENEWS,               
        ABXFUN_REBUILD_PRODUCTBULLETIN,            
        ABXFUN_REBUILD_MARKETREPORT,                
        ABXFUN_REBUILD_ADVERTISEMENT,             
        ABXFUN_QUERY_TICKDIFF,                      
        ABXFUN_QUERY_WARRANTRELATIVE,				
        ABXFUN_QUERY_FILE,                         
        ABXFUN_QUERY_ERRORCODETABLE,              
        ABXFUN_QUERY_EXCHANGELIST,                  
        ABXFUN_QUERY_FORMULACLASS,                 
        ABXFUN_QUERY_FORMULALIST,                 
        ABXFUN_QUERY_PRODUCTCLASS,                  
        ABXFUN_QUERY_PRODUCTFUNCTION,               
        ABXFUN_QUERY_STOCKTABLE,                    
        ABXFUN_QUERY_CLASSRELATIONSTOCKLIST,        
        ABXFUN_QUERY_STOCKRELATIONCLASSLIST,        
        ABXFUN_QUERY_STOCKRELATIONSTOCKLIST,        
        ABXFUN_QUERY_STOCKRELATIONWARRANTSLIST,     
        ABXFUN_QUERY_STOCKCLASS,                    
        ABXFUN_QUERY_TRADECLASS,                    
        ABXFUN_QUERY_TRADECLASS2,                  
        ABXFUN_QUERY_BLOCKCLASS,                    
        ABXFUN_QUERY_SMARTRANKCLASS,                
        ABXFUN_QUERY_SMARTSHORTCLASS,               
        ABXFUN_QUERY_SPREADCLASS,                   
        ABXFUN_QUERY_OTHERCLASS,                    
        ABXFUN_QUERY_CLASSTREE,						
        ABXFUN_QUERY_STOCKRELATIONCLASS,            
        ABXFUN_QUERY_CLASSRELATIONSTOCK,            
        ABXFUN_QUERY_QUOTEDATA,                     
        ABXFUN_QUERY_TRADEDATA,                     
        ABXFUN_QUERY_MINUTETRADE,                   
        ABXFUN_QUERY_PRICETRADE,                    
        ABXFUN_QUERY_TOTALREFERENCE,                
        ABXFUN_QUERY_STATISTIC,                     
        ABXFUN_QUERY_DETAILORDER,                   
        ABXFUN_QUERY_DETAILTRADE,                   
        ABXFUN_QUERY_OLDLOTTRADE,                   
        ABXFUN_QUERY_VIRTUALTRADE,                  
        ABXFUN_QUERY_LASTQUOTEDATA,                 
        ABXFUN_QUERY_SORTQUOTEDATA,                 
        ABXFUN_QUERY_HISTORYDATA,                  
        ABXFUN_QUERY_DIVIDEDATA,                   
        ABXFUN_QUERY_TECHNICALINDEXCLASS,           
        ABXFUN_QUERY_TECHNICALINDEXLIST,            
        ABXFUN_QUERY_TECHNICALINDEXDEFINE,          
        ABXFUN_QUERY_TECHNICALINDEXDATA,            
        ABXFUN_QUERY_TECHNICALINDEXDATAREPEAT,      
        ABXFUN_QUERY_EXCHANGEBULLETINCONTENT,       
        ABXFUN_QUERY_NEWSCONTENT,                   
        ABXFUN_QUERY_PRODUCTBULLETINCONTENT,        
        ABXFUN_QUERY_MARKETREPORTCONTENT,           
        ABXFUN_QUERY_EXPERTSELECT,                  
        ABXFUN_GET_USERINFO,                        
        ABXFUN_GET_USERTECHNICALINDEXCOMMONSETUP,   
        ABXFUN_SET_USERTECHNICALINDEXCOMMONSETUP,   
        ABXFUN_SET_USERTECHNICALINDEXSETUP,         
        ABXFUN_GET_USERTECHNICALINDEXSETUP,		    
        ABXFUN_GET_USERENVIRONMENT,                 // 取得用戶系統環境設定
        ABXFUN_GET_USERENVIRONMENTLIST,             // 取得用戶系統環境設定列表
        ABXFUN_GET_USERENVIRONMENTGROUP,            // 取得用戶系統環境設定群組
        ABXFUN_SET_USERENVIRONMENTGROUP,            // 設定用戶系統環境設定群組
        ABXFUN_SET_USERENVIRONMENT,                 // 設定用戶系統環境設定
        ABXFUN_GET_USERENVIRONMENTCONTENT,          // 取得用戶系統環境設定內容
        ABXFUN_SET_USERENVIRONMENTCONTENT,          // 設定用戶系統環境設定內容
        ABXFUN_DELETE_USERENVIRONMENT,              // 刪除用戶系統環境設定
        ABXFUN_GET_USERFEEDBACK,                    
        ABXFUN_GET_USERFEEDBACKCONTENT,             
        ABXFUN_SET_USERFEEDBACK,                    
        ABXFUN_DOWNLOAD_QUOTEDATA,                  
        ABXFUN_REALTIMEQUOTE,                       // 即時報價
        ABXFUN_UPLOAD_FREEFORMAT,                   
        ABXFUN_UPLOAD_EXCHANGE,                     
        ABXFUN_UPLOAD_NEWS,                         
        ABXFUN_UPLOAD_PRODUCT,                      
        ABXFUN_BROADCAST,                           
        ABXFUN_REPORTDATA,                          
        ABXFUN_CHANGE_USERPASSWORD,                 
        ABXFUN_CHECK_USERPASSWORD,                  
        ABXFUN_QUERY_WARNCLASS,                     
        ABXFUN_SUBSCRIBE_SMARTWARN,                 
        ABXFUN_WARNING_ONOFF,                       
        ABXFUN_WARNING_UPDATE,                      
        ABXFUN_WARNING_DELETE,                     
        ABXFUN_WARNING_QUERY,                       
        ABXFUN_HEARTBEAT,                          
        ABXFUN_REALTIMETECH,                        
        ABXFUN_BASETEST,                            
        ABXFUN_QUERY_QUOTE,							
        ABXFUN_QUERY_STOCK,                         
        ABXFUN_QUERY_FLOATNETWORTH,                 
        ABXFUN_QUERY_STOCKUNGAINLOSS,               
        ABXFUN_QUERY_STATEMENT,                     
        ABXFUN_QUERY_FUTURESUNPROFITS,              
        ABXFUN_QUERY_FUTURESSTATEMENT,              
        ABXFUN_ORDER_STOCKORDER,                   
        ABXFUN_QUERY_STOCKORDER,                    
        ABXFUN_ORDER_FUTURESORDER,                  
        ABXFUN_QUERY_FUTURESORDER,                  
        ABXFUN_QUERY_FORMULAID,                     
        ABXFUN_SELECT_STOCK,                        
        ABXFUN_SET_WATCH,                           // 一銀洗價委託設定
        ABXFUN_QUERY_WATCH,                         // 一銀洗價監控查詢
        ABXFUN_QUERY_TRADEORDER                     // 一銀交易委託查詢
    }

    // 狀態定義
    public enum ABXSTATUS_ID
    {
        // 未知狀態
        ABXSTS_UNKNOW = 0x00000000,
        // 連線
        ABXSTS_CONNECT,
        // 斷線
        ABXSTS_DISCONNECT,
        // 傳送
        ABXSTS_SEND,
        // 接收
        ABXSTS_RECEIVE,
        // 登入
        ABXSTS_LOGIN,
        // 登出
        ABXSTS_LOGOUT,
        // 同賬號登入
        ABXSTS_ANOTHERLOGIN,
        // 心跳
        ABXSTS_HEARTBIT,
        // 基本資料
        ABXSTS_STKBASEINFO,
        // 相關資料
        ABXSTS_STKREFINFO,
        // 第一檔委買賣
        ABXSTS_ORDER_1,
        // 第二至五檔委買賣
        ABXSTS_ORDER_2_5,
        // 第六至十檔委買賣
        ABXSTS_ORDER_6_10,
        // 成交
        ABXSTS_TRADE,
        // 總委買賣
        ABXSTS_TOTREFINFO,
        // 一分鐘
        ABXSTS_ONEMININFO,
        // 其他
        ABXSTS_OTHERS,
        // 交易所統計
        ABXSTS_STATISTIC,
        // 交易所狀態
        ABXSTS_EXCHANGESTATUS,
        // Broker Queue
        ABXSTS_BROKERQUEUE,
        // 逐筆成交
        ABXSTS_DETAILTRADE,
        // 逐筆委託
        ABXSTS_DETAILORDER,
        // 零股交易
        ABXSTS_OLDLOT,
        // 虛擬撮合
        ABXSTS_VIRTUALTRADE,
        // 委買賣每檔明細
        ABXSTS_ORDERLIST,
        // 一秒快照
        ABXSTS_ONESECSNAPSHOT,
        // 一秒快照委買賣
        ABXSTS_ONESECSNAPSHOTORDER,
        // 權證相關
        ABXSTS_WARRANTINFO,
        ABXSTS_SMARTSHORT,
        ABXSTS_SMARTRANK,
        ABXSTS_SMARTMASTER,
        ABXSTS_BROADCAST_FREEFORMAT,
        ABXSTS_BROADCAST_EXCHANGE,
        ABXSTS_BROADCAST_NEWS,
        ABXSTS_BROADCAST_PRODUCTBULLETIN,
        ABXSTS_BROADCAST_MARKETREPORT,
        ABXSTS_BROADCAST_ADVERTISEMENT,
        ABXSTS_BROADCAST_TRADE,
        // 清盤
        ABXSTS_CLEAR_TRADE,
        ABXSTS_SMARTMSGWARN,
        ABXSTS_REALTIMETECH,
    }

    // 錯誤定義
    public enum ABXERROR_CODE
    {
        // 正確値
        NO_ERROR = 0,               
        // 程序错误,需退出软件!
        ABXERR_UNKNOW = 4001,
        // ABus Socket Error!
        ABXERR_SOCKET,
        // 您未登入，请先登入!
        ABXERR_UNLOGIN,
        // 無使用權限
        ABXERR_NOPERMISSIONS,
        // 記憶體不足
        ABXERR_OUTOFMEMORY,
        // -IO Error,需退出软件!
        ABXERR_IOERROR,
        // 檢查碼錯誤
        ABXERR_CHECKSUM,
        // ABus 存取失敗
        ABXERR_ACCESSDENY,
        // ABus 即時報價已啟動
        ABXERR_RTQUOSTARTED,
        // ABUs 通訊連線已開啟
        ABXERR_SESSIONOPENED,
        // 檔案名不支援
        ABXERR_UNKNOWFILE,
        // ABusGW Socket Error
        ABXERR_GWSOCKET,
        // 网路不通或斷線
        ABXERR_GSOCKET_BROKEN,
        // 獲取參數(Param)失敗
        ABXERR_GETPARAM,
        // 獲取類別(Class)失敗
        ABXERR_GETCLASS,
        ABXERR_JSON_FORMAT,
        // Synchro同步timeout
        ABXERR_SYNCHRO_TIMEOUT,
        // 重複登入
        ABXERR_DUPLICATELOGIN
    }
}
