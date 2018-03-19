using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon.Event
{

    /// <summary>
    /// 全局事件
    /// </summary>
    public class EventDefine
    {
        public EventDefine()
        {
        }

        /// <summary>
        /// 行情事件
        /// </summary>
        public OnTickEvent _OnTick;
        public delegate void OnTickEvent(TickData tick);
        /// <summary>
        /// 行情事件注册
        /// </summary>
        public event OnTickEvent OnTick
        {
            add
            {
                this._OnTick += value;
            }
            remove
            {
                this._OnTick -= value;
            }
        }

        /// <summary>
        /// Trade事件
        /// </summary>
        public OnTradeEvent _OnTrade;
        public delegate void OnTradeEvent(TradeData trade);
        /// <summary>
        /// Trade事件注册
        /// </summary>
        public event OnTradeEvent OnTrade
        {
            add
            {
                this._OnTrade += value;
            }
            remove
            {
                this._OnTrade -= value;
            }
        }

        /// <summary>
        /// 委托事件
        /// </summary>
        public OnOrderEvent _OnOrder;
        public delegate void OnOrderEvent(OrderData Order);
        /// <summary>
        /// 委托事件注册
        /// </summary>
        public event OnOrderEvent OnOrder
        {
            add
            {
                this._OnOrder += value;
            }
            remove
            {
                this._OnOrder -= value;
            }
        }


        /// <summary>
        /// 持仓事件
        /// </summary>
        public OnPositionEvent _OnPosition;
        public delegate void OnPositionEvent(PositionData Position);
        /// <summary>
        /// 持仓事件
        /// </summary>
        public event OnPositionEvent OnPosition
        {
            add
            {
                this._OnPosition += value;
            }
            remove
            {
                this._OnPosition -= value;
            }
        }


        /// <summary>
        /// 合约事件
        /// </summary>
        public OnContractEvent _OnContract;
        public delegate void OnContractEvent(ContractData Contact);
        /// <summary>
        /// 合约事件注册
        /// </summary>
        public event OnContractEvent OnContract
        {
            add
            {
                this._OnContract += value;
            }
            remove
            {
                this._OnContract -= value;
            }
        }


        /// <summary>
        /// 账户事件
        /// </summary>
        public OnAccountEvent _OnAccount;
        public delegate void OnAccountEvent(AccountData Account);
        /// <summary>
        /// /// 账户事件注册
        /// </summary>
        public event OnAccountEvent OnAccount
        {
            add
            {
                this._OnAccount += value;
            }
            remove
            {
                this._OnAccount -= value;
            }
        }


        /// <summary>
        /// 错误事件
        /// </summary>
        public OnErrorEvent _OnError;
        public delegate void OnErrorEvent(ErrorData Error);
        /// <summary>
        /// 错误事件注册
        /// </summary>
        public event OnErrorEvent OnError
        {
            add
            {
                this._OnError += value;
            }
            remove
            {
                this._OnError -= value;
            }
        }


        /// <summary>
        /// 日志事件
        /// </summary>
        public OnLogEvent _OnLog;
        public delegate void OnLogEvent(LogData Log);
        /// <summary>
        /// 日志事件注册
        /// </summary>
        public event OnLogEvent OnLog
        {
            add
            {
                this._OnLog += value;
            }
            remove
            {
                this._OnLog -= value;
            }
        }
    }

    /// <summary>
    /// 事件定义
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// 计时器事件，每隔1秒发送一次
        /// </summary>
        Timer,
        /// <summary>
        /// 日志事件，全局通用
        /// </summary>
        Log,
        /// <summary>
        /// TICK行情事件
        /// </summary>
        Tick,
        /// <summary>
        /// 成交回报事件
        /// </summary>
        Trade,
        /// <summary>
        /// 委托回报事件
        /// </summary>
        Order,
        /// <summary>
        /// 持仓回报事件
        /// </summary>
        Position,
        /// <summary>
        /// 账户回报事件
        /// </summary>
        Account,
        /// <summary>
        /// 合约基础信息回报事件
        /// </summary>
        Contact,
        /// <summary>
        /// 错误回报事件
        /// </summary>
        Error
    }
}
