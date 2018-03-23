using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CTP;

namespace QuanNetCommon.Gateway.CtpGateway
{
    public class CtpMdApi : CTPMDAdapter,IMdApi
    {

        public string UserID;
        public string Password;
        public string BrokerID;
        public string MdAddress;
        public int reqID=0;
        public CtpGateway Gateway;

        public CtpMdApi(string userID,string password,string brokerID,string mdAddress,CtpGateway gateway):base()
        {
            this.UserID = userID;
            this.Password = password;
            this.BrokerID = brokerID;
            this.MdAddress = mdAddress;
            this.Gateway = gateway;

            //注册回调函数
            this.OnFrontConnected += new FrontConnected(HandleOnFrontConnected);
            this.OnFrontDisconnected += new FrontDisconnected(HandleOnFrontDisconnected);
            this.OnRspError += new RspError(HandleOnRspError);
            this.OnHeartBeatWarning += new HeartBeatWarning(HandleOnHeartBeatWarning);
            this.OnRspSubMarketData += new RspSubMarketData(HandleOnRspSubMarketData);
            this.OnRspUnSubMarketData += new RspUnSubMarketData(HandleOnRspUnSubMarketData);
            this.OnRspUserLogin += new RspUserLogin(HandleOnRspUserLogin);
            this.OnRspUserLogout += new RspUserLogout(HandleOnRspUserLogout);
            this.OnRtnDepthMarketData += new RtnDepthMarketData(HandleOnRtnDepthMarketData);
        }

        public void Connect()
        {
            try
            {
                this.RegisterFront(this.MdAddress);
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
        /// 合约订阅
        /// </summary>
        /// <param name="req"></param>
        public void Subscribe(SubscribeReq req)
        {
            string instrumentID = req.symbol;
            this.SubscribeMarketData(new string[] { instrumentID });
        }

        /// <summary>
        /// 登录
        /// </summary>
        public void Login()
        {
            ThostFtdcReqUserLoginField loginReq=new ThostFtdcReqUserLoginField();
            loginReq.UserID=this.UserID;
            loginReq.Password=this.Password;
            loginReq.BrokerID=this.Password;
            this.ReqUserLogin(loginReq, this.reqID);
        }

        /// <summary>
        /// """服务器连接"""
        /// </summary>
        public void HandleOnFrontConnected()
        {
             this.Login();
        }

        /// <summary>
        /// 服务器断开
        /// </summary>
        public void HandleOnFrontDisconnected(int nReason)
        {
            throw new NotImplementedException();
        }

        public void HandleOnRtnNotice()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// """错误回报"""
        /// </summary>
        public void HandleOnRspError(ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 心跳回调
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        public void HandleOnHeartBeatWarning(int nTimeLapse) 
        {

        }

        /// <summary>
        /// 订阅回调
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        public void HandleOnRspSubMarketData(ThostFtdcSpecificInstrumentField pSpecificInstrument, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast) 
        {

        }


        /// <summary>
        /// 取消订阅回调
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        public void HandleOnRspUnSubMarketData(ThostFtdcSpecificInstrumentField pSpecificInstrument, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast) 
        {
      
        }

        /// <summary>
        /// 登录回调
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        public void HandleOnRspUserLogin(ThostFtdcRspUserLoginField pRspUserLogin, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast) 
        {
        }


        /// <summary>
        /// 登出回调
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        public void HandleOnRspUserLogout(ThostFtdcUserLogoutField pUserLogout, ThostFtdcRspInfoField pRspInfo, int nRequestID, bool bIsLast) 
        {
        }

        /// <summary>
        /// 行情返回回调
        /// </summary>
        /// <param name="pDepthMarketData"></param>
        public void HandleOnRtnDepthMarketData(ThostFtdcDepthMarketDataField pDepthMarketData) 
        {
            var tick = new TickData();
            tick.gatewayName = this.Gateway.gatewayName;
            tick.symbol = pDepthMarketData.InstrumentID;
            tick.vtSymbol = pDepthMarketData.InstrumentID;
            tick.exchange = "";
            tick.lastPrice = pDepthMarketData.LastPrice;
            tick.volume = pDepthMarketData.Volume;
            tick.openInterest = (int)pDepthMarketData.OpenInterest;
            tick.time = pDepthMarketData.UpdateTime;
            tick.openPrice = pDepthMarketData.OpenPrice;
            tick.highPrice = pDepthMarketData.HighestPrice;
            tick.lowPrice = pDepthMarketData.LowestPrice;
            tick.preClosePrice = pDepthMarketData.PreClosePrice;
            tick.upperLimit = pDepthMarketData.UpperLimitPrice;
            tick.lowerLimit = pDepthMarketData.LowerLimitPrice;
            tick.bidPrice1 = pDepthMarketData.BidPrice1;
            tick.bidVolume1 = pDepthMarketData.BidVolume1;
            tick.bidPrice2 = pDepthMarketData.BidPrice2;
            tick.bidVolume2 = pDepthMarketData.BidVolume2;
            tick.bidPrice3 = pDepthMarketData.BidPrice3;
            tick.bidVolume3 = pDepthMarketData.BidVolume3;
            tick.bidPrice4 = pDepthMarketData.BidPrice4;
            tick.bidVolume4 = pDepthMarketData.BidVolume4;
            tick.bidPrice5 = pDepthMarketData.BidPrice5;
            tick.bidVolume5 = pDepthMarketData.BidVolume5;
            ///行情推送
            this.Gateway.MainController.MainEvent._OnTick.Invoke(tick);
        }
    }
    

}
