using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuanNetCommon
{
    /// <summary>
    ///  """回调函数推送数据的基础类，其他数据类继承于此"""
    /// </summary>
    public class BaseData
    {
        public BaseData()
        {
        }
        /// <summary>
        /// Gateway名称
        /// </summary>
        public string gatewayName;

        ///<summary>
        /// 原始数据
        ///<summary>
        public string rawData;
    }

    /// <summary>
    /// """Tick行情数据类"""
    /// </summary>
    public class TickData : BaseData
    {
        public TickData()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;

        /// <summary>
        /// 最新成交价
        /// </summary>
        public double lastPrice;            
        /// <summary>
        /// 最新成交量
        /// </summary>
        public int lastVolume;            
        /// <summary>
        /// 今天总成交量
        /// </summary>
        public int volume;                 

        /// <summary>
        /// 持仓量
        /// </summary>
        public int openInterest;          
        /// <summary>
        /// 时间 11:20:56.5
        /// </summary>
        public string time;              
        /// <summary>
        /// 日期 20151009
        /// </summary>
        public string date;                
        /// <summary>
        /// python的datetime时间对象
        /// </summary>
        public DateTime datetime;               

        // 常规行情
        /// <summary>
        /// 今日开盘价
        /// </summary>
        public double openPrice;        
        /// <summary>
        /// 今日最高价
        /// </summary>
        public double highPrice;          
        /// <summary>
        /// 今日最低价
        /// </summary>
        public double lowPrice;         
        /// <summary>
        ///昨收盘价
        /// </summary>
        public double preClosePrice;

        
        /// <summary>
        /// 涨停价
        /// </summary>
        public double upperLimit;
        /// <summary>
        /// 跌停价
        /// </summary>
        public double lowerLimit;        

        // 五档行情
        public double bidPrice1;
        public double bidPrice2;
        public double bidPrice3;
        public double bidPrice4;
        public double bidPrice5;

        public double askPrice1;
        public double askPrice2;
        public double askPrice3;
        public double askPrice4;
        public double askPrice5;

        public int bidVolume1;
        public int bidVolume2;
        public int bidVolume3;
        public int bidVolume4;
        public int bidVolume5;

        public int askVolume1;
        public int askVolume2;
        public int askVolume3;
        public int askVolume4;
        public int askVolume5;
    }

    /// <summary>
    /// """K线数据"""
    /// </summary>
    public class BarData : BaseData
    {
        public BarData()
        {
        }


        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;

        public double open;         
        public double high;
        public double low;
        public double close;

        /// <summary>
        /// // bar开始的时间，日期
        /// </summary>
        public string date;

        /// <summary>
        /// // bar开始的时间，日期
        /// </summary>
        public string time;

        /// <summary>
        /// // bar开始的时间，日期
        /// </summary>
        public DateTime datetime;               

        /// <summary>
        /// 成交量
        /// </summary>
        public int volume;            

        /// <summary>
        /// 持仓量
        /// </summary>
        public int openInterest;           
    }

    /// <summary>
    ///  """成交数据类"""
    /// </summary>
    public class TradeData : BaseData
    {
        public TradeData()
        {

        }

        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;

        /// <summary>
        /// 成交编号
        /// </summary>
        public string tradeID;  
       /// <summary>
        /// 成交在vt系统中的唯一编号
       /// </summary>
        public string vtTradeID;          

        /// <summary>
        ///  // 订单编号
        /// </summary>
        public string orderID;    
        /// <summary>
        ///  // 订单在vt系统中的唯一编号
        /// </summary>
        public string vtOrderID;          

        /// <summary>
        /// // 成交方向
        /// </summary>
        public int direction;          
        /// <summary>
        ///  // 成交开平仓
        /// </summary>
        public int offset;             
        /// <summary>
        ///  // 成交价格
        /// </summary>
        public double price;               
        /// <summary>
        /// // 成交数量
        /// </summary>
        public int volume;                 
        /// <summary>
        ///  // 成交时间
        /// </summary>
        public DateTime tradeTime;           
    }

    /// <summary>
    /// ""订单数据类"""
    /// </summary>
    public class OrderData : BaseData
    {
        public OrderData()
        {
        }


        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;


        public int spdOrderID;

        /// <summary>
        /// 订单编号
        /// </summary>
        public string orderID;             
        /// <summary>
        /// 订单在vt系统中的唯一编号
        /// </summary>
        public string vtOrderID;          

        // 报单相关
        /// <summary>
        /// 报单方向
        /// </summary>
        public int direction;          
        /// <summary>
        /// 报单开平仓
        /// </summary>
        public int offset;            
        /// <summary>
        /// 报单价格
        /// </summary>
        public double price;               
        /// <summary>
        /// 报单总数量
        /// </summary>
        public int totalVolume;            
        /// <summary>
        /// 报单成交数量
        /// </summary>
        public int tradedVolume;           
        /// <summary>
        /// 报单状态
        /// </summary>
        public int status;             

        /// <summary>
        /// 发单时间
        /// </summar
        public DateTime orderTime;           
        /// <summary>
        /// 撤单时间
        /// </summary>
        public DateTime cancelTime;          

       /// <summary>
        /// 前置机编号
       /// </summary>
        public int frontID;                
        /// <summary>
        /// 连接编号
        /// </summary>
        public int sessionID;              
    }

    /// <summary>
    /// """持仓数据类"""
    /// </summary>
    public class PositionData : BaseData
    {
        public PositionData()
        {
        }


        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;

        // 持仓相关
        /// <summary>
        /// 持仓方向
        /// </summary>
        public string direction;          
        /// <summary>
        /// 持仓量
        /// </summary>
        public int position;             
        /// <summary>
        /// 冻结数量
        /// </summary>
        public int frozen;                
        /// <summary>
        /// 持仓均价
        /// </summary>
        public double price;               
        /// <summary>
        /// 持仓在vt系统中的唯一代码，通常是vtSymbol.方向
        /// </summary>
        public string vtPositionName;      
        /// <summary>
        /// 昨持仓
        /// </summary>
        public int ydPosition;             
        /// <summary>
        /// 持仓盈亏
        /// </summary>
        public double positionProfit;      
    }

    /// <summary>
    /// """账户数据类"""
    /// </summary>
    public class AccountData : BaseData
    {
        public AccountData()
        {
        }


        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;


        // 账号代码相关
        /// <summary>
        /// 账户代码
        /// </summary>
        public string accountID;           
        /// <summary>
        /// 账户在vt中的唯一代码，通常是 Gateway名.账户代码
        /// </summary>
        public string vtAccountID;       

        // 数值相关
        /// <summary>
        /// 昨日账户结算净值
        /// </summary>
        public double preBalance;         
        /// <summary>
        /// 账户净值
        /// </summary>
        public double balance;             
        /// <summary>
        /// 可用资金
        /// </summary>
        public double available;          
        /// <summary>
        /// 今日手续费
        /// </summary>
        public double commission;          
        /// <summary>
        /// 保证金占用
        /// </summary>
        public double margin;             
        /// <summary>
        /// 平仓盈亏
        /// </summary>
        public double closeProfit;         
        /// <summary>
        /// 持仓盈亏
        /// </summary>
        public double positionProfit;      
        /// <summary>
        /// 风险度
        /// </summary>
        public double risk;                   
    }


    /// <summary>
    /// """错误数据类"""
    /// </summary>
    public class ErrorData : BaseData
    {
        public ErrorData()
        {
        }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string errorID;             
        /// <summary>
        /// 错误信息
        /// </summary>
        public int errorMsg;           
        /// <summary>
        /// 补充信息
        /// </summary>
        public int additionalInfo;     
        /// <summary>
        /// 错误生成时间
        /// </summary>
        public DateTime errorTime;
    }

    /// <summary>
    /// """日志数据类"""
    /// </summary>
    public class LogData : BaseData
    {
        public LogData()
        {
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public int logLevel;          
        /// <summary>
        /// 补充信息
        /// </summary>
        public int logContent;    
        /// <summary>
        /// /错误生成时间
        /// </summary>

        public DateTime logTime;
    }

    /// <summary>
    /// """合约详细信息类"""
    /// </summary>
    public class ContractData : BaseData
    {
        public ContractData()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;
        /// <summary>
        /// 合约中文名
        /// </summary>
        public string name;               

        /// <summary>
        /// 合约类型
        /// </summary>
        public int productClass;       
        /// <summary>
        /// 合约大小
        /// </summary>
        public int size;                   
        /// <summary>
        /// 合约最小价格
        /// </summary>
        public double priceTick;           

        // 期权相关
        /// <summary>
        /// 期权行权价
        /// </summary>
        public double strikePrice;        
        /// <summary>
        /// 标的物合约代码
        /// </summary>
        public string underlyingSymbol;   
        /// <summary>
        /// 期权类型
        /// </summary>
        public int optionType;        
        /// <summary>
        /// 到期日
        /// </summary>
        public string expiryDate;          
    }


    /// <summary>
    /// """订阅行情时传入的对象类"""
    /// </summary>
    public class SubscribeReq
    {
        public SubscribeReq()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;

        // 以下为IB相关
        /// <summary>
        /// 合约类型
        /// </summary>
        public int productClass;       
        /// <summary>
        /// 合约货币
        /// </summary>
        public string currency;            
        /// <summary>
        /// 到期日
        /// </summary>
        public string expiry;              
        /// <summary>
        /// 行权价
        /// </summary>
        public double strikePrice;         
        /// <summary>
        /// 期权类型
        /// </summary>
        public int optionType;         

    }

    /// <summary>
    /// """发单时传入的对象类"""
    /// </summary>
    public class OrderReq
    {
        public OrderReq()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;

        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;

        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;

        /// <summary>
        /// 价格
        /// </summary>
        public double price;     
          
        /// <summary>
        /// 数量
        /// </summary>
        public int volume;                 

        /// <summary>
        /// 价格类型
        /// </summary>
        public string priceType;  
         
        /// <summary>
        /// 买卖
        /// </summary>
        public int direction;  
         
        /// <summary>
        /// 开平
        /// </summary>
        public string offset;              

        // 以下为IB相关
        /// <summary>
        /// 合约类型
        /// </summary>
        public int productClass;   
    
        /// <summary>
        /// 合约货币
        /// </summary>
        public string currency;  
          
        /// <summary>
        /// 到期日
        /// </summary>
        public string expiry;              

        /// <summary>
        /// 行权价
        /// </summary>
        public double strikePrice;  
       
        /// <summary>
        /// 期权类型
        /// </summary>
        public int optionType;  
          
        /// <summary>
        /// 合约月,IB专用
        /// </summary>
        public string lastTradeDateOrContractMonth;   

        /// <summary>
        /// 乘数,IB专用
        /// </summary>
        public string multiplier;                     

    }

    /// <summary>
    /// """撤单时传入的对象类"""
    /// </summary>
    public class CancelOrderReq
    {
        public CancelOrderReq()
        {
        }
        /// <summary>
        /// 合约代码
        /// </summary>
        public string symbol;
        /// <summary>
        /// 交易所代码
        /// </summary>
        public string exchange;
        /// <summary>
        /// 合约在本系统中的唯一代码，通常是 合约代码.交易所代码
        /// </summary>
        public string vtSymbol;

        /// <summary>
        /// 报单号
        /// </summary>
        public string orderID;  
          
        /// <summary>
        /// 前置机号
        /// </summary>
        public int frontID;             

        /// <summary>
        /// 会话号
        /// </summary>
        public int sessionID;           

    }
}
