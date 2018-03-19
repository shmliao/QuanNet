using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanNetCommon.Gateway.SecGateway;

namespace QuanNetCommon.Gateway
{
    /// <summary>
    /// 接口抽象类，每一个实例化的接口都有一个mdApi和一个tdApi
    /// </summary>
    /// <typeparam name="mdApi"></typeparam>
    /// <typeparam name="tdApi"></typeparam>
    public abstract class BaseGateway<mdApi, tdApi>
        where mdApi : IMdApi
        where tdApi : ITdApi
    {

        public BaseGateway()
        {

        }

        public abstract string gatewayName 
        {
            get;
        } 


        public mdApi md
        {
            get;
            private set;
        }

        public tdApi td
        {
            get;
            private set;
        }

        public virtual void SetMdApiAndTdApi(mdApi m, tdApi t)
        {
            this.md = m;
            this.td = t;
        }


        /// <summary>
        /// 初始化连接
        /// </summary>
        public virtual void Connect()
        {
            md.Connect();
            td.Connect();

        }

        /// <summary>
        /// 订阅行情
        /// </summary>
        public virtual void Subscribe(SubscribeReq req)
        {
            md.Subscribe(req);
        }

        /// <summary>
        /// 发单
        /// </summary>
        public virtual void SendOrder(OrderReq req)
        {
            td.SendOrder(req);
        }

        /// <summary>
        /// 撤单
        /// </summary>
        public virtual void CancelOrder(CancelOrderReq req)
        {
            td.CancelOrder(req);
        }

        /// <summary>
        /// 查询账户
        /// </summary>
        public virtual void QryAccount()
        {
            td.QryAccount();
        }


        /// <summary>
        /// 查询持仓
        /// </summary>
        public virtual void QryPosition()
        {
            td.QryAccount();
        }

    }

    public class test : BaseGateway<SecMdApi, SecTdApi>
    {

        public override string gatewayName
        {
            get { return "test"; }
        }
    }

    public class testclass
    {
        public testclass()
        {
            SecMdApi md = new SecMdApi();
            SecTdApi td = new SecTdApi();
            test a = new test();
            a.SetMdApiAndTdApi(md, td);
        }
    }
}
