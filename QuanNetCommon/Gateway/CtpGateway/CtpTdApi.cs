using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTP;

namespace QuanNetCommon.Gateway.CtpGateway
{
    public class CtpTdApi : CTPTraderAdapter, ITdApi
    {
        string UserID;
        string Password;
        string BrokerID;
        string TdAddress;
        /// <summary>
        /// 授权码，如果没有授权码和软件标识说明该账号不需要验证，服务器连接以后直接登录即可，否则需要先验证来判断该账号是否程序化报备过！
        /// </summary>
        string AuthCode;
        
        /// <summary>
        /// 软件标识
        /// </summary>
        string UserProductInfo;
        public int reqID = 0;
        public CtpGateway Gateway;

        public CtpTdApi(string userID, string password, string brokerID, string tdAddress, string authCode, string userProductInfo, CtpGateway gateway)
        {
            this.UserID = userID;
            this.Password = password;
            this.BrokerID = brokerID;
            this.TdAddress = tdAddress;
            this.AuthCode = authCode;
            this.UserProductInfo = userProductInfo;
            this.Gateway = gateway;

            this.OnFrontConnected += new FrontConnected(HandleOnFrontConnected);
            this.OnFrontDisconnected += new FrontDisconnected(HandleOnFrontDisconnected);
            this.OnHeartBeatWarning += new HeartBeatWarning(HandleOnHeartBeatWarning);
            this.OnRspError += new RspError(HandleOnRspError);
            this.OnRspUserLogin += new RspUserLogin(HandleOnRspUserLogin);
            this.OnRspOrderAction += new RspOrderAction(HandleOnRspOrderAction);
            this.OnRspOrderInsert += new RspOrderInsert(HandleOnRspOrderInsert);
            this.OnRspQryInstrument += new RspQryInstrument(HandleOnRspQryInstrument);
            this.OnRspQryInvestorPosition += new RspQryInvestorPosition(HandleOnRspQryInvestorPosition);
            this.OnRspQryTradingAccount += new RspQryTradingAccount(HandleOnRspQryTradingAccount);
            this.OnRspSettlementInfoConfirm += new RspSettlementInfoConfirm(HandleOnRspSettlementInfoConfirm);
            this.OnRtnOrder += new RtnOrder(HandleOnRtnOrder);
            this.OnRtnTrade += new RtnTrade(HandleOnRtnTrade);
            this.OnRspAuthenticate += new RspAuthenticate(HandleOnRspAuthenticate);

            this.SubscribePublicTopic(EnumTeResumeType.THOST_TERT_RESTART);					// 注册公有流
            this.SubscribePrivateTopic(EnumTeResumeType.THOST_TERT_RESTART);					// 注册私有流
        }

        /// <summary>
        /// 服务器连接
        /// </summary>
        public void HandleOnFrontConnected()
        {
            Console.WriteLine("服务器连接成功");
            if (!string.IsNullOrEmpty(this.AuthCode) && !string.IsNullOrEmpty(this.UserProductInfo))
            {
                this.Authenticate();
            }
            else
            {
                this.ReqUserLogin();
            }
        }

        /// <summary>
        /// """申请验证"""
        /// </summary>
        public void Authenticate()
        {

            if (string.IsNullOrEmpty(UserID) && string.IsNullOrEmpty(BrokerID) && string.IsNullOrEmpty(AuthCode) && string.IsNullOrEmpty(UserProductInfo))
            {
                ThostFtdcReqAuthenticateField req = new ThostFtdcReqAuthenticateField();
                req.AuthCode = this.BrokerID;
                req.UserID = this.UserID;
                req.AuthCode = this.AuthCode;
                req.UserProductInfo = this.UserProductInfo;
                this.ReqAuthenticate(req, ++reqID);
            }
        }

        /// <summary>
        /// 验证回报
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        public void HandleOnRspAuthenticate(ThostFtdcRspAuthenticateField pRspAuthenticateField, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            if (pRspInfo.ErrorID == 0)
            {
                this.ReqUserLogin();
            }
            else
            {
                Console.WriteLine("服务器断开:--->>> Reason = {0}", pRspInfo.ErrorMsg);
            }
        }

        void ReqUserLogin()
        {
            ThostFtdcReqUserLoginField req = new ThostFtdcReqUserLoginField();
            req.BrokerID = this.BrokerID;
            req.UserID = this.UserID;
            req.Password = this.Password;
            int iResult = this.ReqUserLogin(req, ++reqID);
            Console.WriteLine("--->>> 发送用户登录请求: " + ((iResult == 0) ? "成功" : "失败"));
        }

        /// <summary>
        /// 服务器断开
        /// </summary>
        /// <param name="nReason"></param>
        public void HandleOnFrontDisconnected(int nReason)
        {
            Console.WriteLine("服务器断开:--->>> Reason = {0}", nReason);
        }

        /// <summary>
        /// 因为API的心跳报警比较常被触发，且与API工作关系不大，因此选择忽略
        /// </summary>
        /// <param name="nTimeLapse"></param>
        public void HandleOnHeartBeatWarning(int nTimeLapse)
        {

        }

        /// <summary>
        /// 错误回报
        /// </summary>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspError(ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("错误回报" + pRspInfo.ErrorMsg);
        }

        /// <summary>
        /// 登录成功
        /// </summary>
        /// <param name="pRspUserLogin"></param>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspUserLogin(ThostFtdcRspUserLoginField pRspUserLogin, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("登录成功");
        }

        /// <summary>
        /// 撤单错误（柜台）
        /// </summary>
        /// <param name="pInputOrderAction"></param>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspOrderAction(ThostFtdcInputOrderActionField pInputOrderAction, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("撤单错误（柜台）" + pRspInfo.ErrorMsg);
        }

        /// <summary>
        /// ""发单错误（柜台）"""
        /// </summary>
        /// <param name="pInputOrder"></param>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspOrderInsert(ThostFtdcInputOrderField pInputOrder, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            Console.WriteLine("发单错误（柜台）");
        }

        /// <summary>
        /// """合约查询回报"""
        /// </summary>
        /// <param name="pInstrument"></param>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspQryInstrument(ThostFtdcInstrumentField pInstrument, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            var contact = new ContractData();
            contact.gatewayName = this.Gateway.gatewayName;
            contact.symbol = pInstrument.InstrumentID;
            contact.exchange = pInstrument.ExchangeID;
            contact.vtSymbol = pInstrument.InstrumentID;
            contact.name = pInstrument.InstrumentName;
            contact.size = pInstrument.VolumeMultiple;
            contact.priceTick = pInstrument.PriceTick;
            contact.strikePrice = pInstrument.StrikePrice;
            contact.underlyingSymbol = pInstrument.UnderlyingInstrID;
            contact.productClass = (int)pInstrument.ProductClass;
            contact.expiryDate = pInstrument.ExpireDate;
            contact.optionType = (int)pInstrument.OptionsType;
            ///合约推送
            this.Gateway.MainController.MainEvent._OnContract.Invoke(contact);

            if (bIsLast)
            {
                Console.WriteLine("获取合约完毕");
            }

        }

        /// <summary>
        /// 持仓返回
        /// </summary>
        /// <param name="pInvestorPosition"></param>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspQryInvestorPosition(ThostFtdcInvestorPositionField pInvestorPosition, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            var position = new PositionData();
            ///合约推送
            this.Gateway.MainController.MainEvent._OnPosition.Invoke(position);
            if (bIsLast)
            {
                Console.WriteLine("持仓返回完毕");
            }
        }

        /// <summary>
        /// 资金账户查询回报
        /// </summary>
        /// <param name="pTradingAccount"></param>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspQryTradingAccount(ThostFtdcTradingAccountField pTradingAccount, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            var account = new AccountData();
            ///账户推送
            this.Gateway.MainController.MainEvent._OnAccount.Invoke(account);
            if (bIsLast)
            {
                Console.WriteLine("资金账户查询回报完毕");
            }
        }

        /// <summary>
        /// """确认结算信息回报"""
        /// </summary>
        /// <param name="pSettlementInfoConfirm"></param>
        /// <param name="pRspInfo"></param>
        /// <param name="nRequestID"></param>
        /// <param name="bIsLast"></param>
        public void HandleOnRspSettlementInfoConfirm(ThostFtdcSettlementInfoConfirmField pSettlementInfoConfirm, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            if (bIsLast)
            {
                Console.WriteLine("确认结算信息回报完毕");
            }
        }

        /// <summary>
        /// """报单回报"""
        /// </summary>
        /// <param name="pOrder"></param>
        public void HandleOnRtnOrder(ThostFtdcOrderField pOrder)
        {
            var order = new OrderData();
            ///报单推送
            this.Gateway.MainController.MainEvent._OnOrder.Invoke(order);
        }

        /// <summary>
        /// 成交回报
        /// </summary>
        /// <param name="pTrade"></param>
        public void HandleOnRtnTrade(ThostFtdcTradeField pTrade)
        {

            var trade = new TradeData();
            ///成交推送
            this.Gateway.MainController.MainEvent._OnTrade.Invoke(trade);
        }

        public void Connect()
        {
            try
            {
                this.RegisterFront(this.TdAddress);
                this.Init();
                this.Join();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                this.Release();
            }
        }

        /// <summary>
        /// 发单！
        /// </summary>
        /// <param name="order"></param>
        public void SendOrder(OrderReq order)
        {
            ThostFtdcInputOrderField req = new ThostFtdcInputOrderField();
            ///经纪公司代码
            req.BrokerID = this.BrokerID;
            ///投资者代码
            req.InvestorID = this.UserID;
            ///合约代码
            req.InstrumentID = order.symbol;
            ///报单本地委托号，待处理
            //req.OrderRef = ORDER_REF;
            ///用户代码
            //	TThostFtdcUserIDType	UserID;
            ///报单价格条件: 限价
            req.OrderPriceType = CTP.EnumOrderPriceTypeType.LimitPrice;
            ///买卖方向: 
            req.Direction = (EnumDirectionType)order.direction;
            ///组合开平标志: 开仓
            req.CombOffsetFlag_0 = CTP.EnumOffsetFlagType.Open;
            ///组合投机套保标志
            req.CombHedgeFlag_0 = CTP.EnumHedgeFlagType.Speculation;
            ///价格
            req.LimitPrice = order.price;
            ///数量: 1
            req.VolumeTotalOriginal = order.volume;
            ///有效期类型: 当日有效
            req.TimeCondition = CTP.EnumTimeConditionType.GFD;
            ///GTD日期
            //	TThostFtdcDateType	GTDDate;
            ///成交量类型: 任何数量
            req.VolumeCondition = CTP.EnumVolumeConditionType.AV;
            ///最小成交量: 1
            req.MinVolume = 1;
            ///触发条件: 立即
            req.ContingentCondition = CTP.EnumContingentConditionType.Immediately;
            ///止损价
            //	TThostFtdcPriceType	StopPrice;
            ///强平原因: 非强平
            req.ForceCloseReason = CTP.EnumForceCloseReasonType.NotForceClose;
            ///自动挂起标志: 否
            req.IsAutoSuspend = 0;
            ///业务单元
            //	TThostFtdcBusinessUnitType	BusinessUnit;
            ///请求编号
            //	TThostFtdcRequestIDType	RequestID;
            ///用户强评标志: 否
            req.UserForceClose = 0;

            int iResult = this.ReqOrderInsert(req, ++this.reqID);
            Console.WriteLine("--->>> 报单请求: " + ((iResult == 0) ? "成功" : "失败"));
        }

        /// <summary>
        /// 撤单
        /// </summary>
        /// <param name="req"></param>
        public void CancelOrder(CancelOrderReq cancelOrderReq)
        {
            ThostFtdcInputOrderActionField req = new ThostFtdcInputOrderActionField();
            ///经纪公司代码
            req.BrokerID = this.BrokerID;
            ///投资者代码
            req.InvestorID = this.UserID;
            ///报单操作引用
            //	TThostFtdcOrderActionRefType	OrderActionRef;
            ///报单本地委托号
            req.OrderRef = cancelOrderReq.orderID;
            ///请求编号
            //	TThostFtdcRequestIDType	RequestID;
            ///前置编号
            req.FrontID = cancelOrderReq.frontID;
            ///会话编号
            req.SessionID = cancelOrderReq.sessionID;
            ///交易所代码
            //	TThostFtdcExchangeIDType	ExchangeID;
            ///报单编号
            //	TThostFtdcOrderSysIDType	OrderSysID;
            ///操作标志
            req.ActionFlag = CTP.EnumActionFlagType.Delete;
            ///价格
            //	TThostFtdcPriceType	LimitPrice;
            ///数量变化
            //	TThostFtdcVolumeType	VolumeChange;
            ///用户代码
            //	TThostFtdcUserIDType	UserID;
            ///合约代码
            req.InstrumentID = cancelOrderReq.symbol;

            int iResult = this.ReqOrderAction(req, ++this.reqID);
            Console.WriteLine("--->>> 报单操作请求: " + ((iResult == 0) ? "成功" : "失败"));
        }


        public void QryAccount()
        {
            ThostFtdcQryTradingAccountField req = new ThostFtdcQryTradingAccountField();
            req.BrokerID = this.BrokerID;
            req.InvestorID = this.UserID;
            var iResult = this.ReqQryTradingAccount(req, ++this.reqID);
            Console.WriteLine("--->>> 请求查询资金账户: " + ((iResult == 0) ? "成功" : "失败"));
        }

        public void QryPosition()
        {
            ThostFtdcQryInvestorPositionField req = new ThostFtdcQryInvestorPositionField();
            req.BrokerID = this.BrokerID; ;
            req.InvestorID = this.UserID; ;
            int iResult = this.ReqQryInvestorPosition(req, ++this.reqID);
            Console.WriteLine("--->>> 请求查询投资者持仓: " + ((iResult == 0) ? "成功" : "失败"));
        }
    }
}
