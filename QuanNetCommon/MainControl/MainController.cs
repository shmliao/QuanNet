using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanNetCommon.Gateway;
using QuanNetCommon.Event;

namespace QuanNetCommon.MainControl
{
    public class MainController
    {
        /// <summary>
        /// 主引擎接口
        /// </summary>
        public BaseGateway<IMdApi, ITdApi> Gateway;

        /// <summary>
        /// 主引擎事件
        /// </summary>
        /// <param name="gateway"></param>
        public EventDefine MainEvent;

        public MainController(BaseGateway<IMdApi, ITdApi> gateway)
        {
            this.Gateway = gateway;
            MainEvent = new EventDefine();
        }

        /// <summary>
        /// 初始化连接
        /// </summary>
        public void Connect()
        {
            Gateway.Connect();

        }

        /// <summary>
        /// 订阅行情
        /// </summary>
        public void Subscribe(SubscribeReq req)
        {
            Gateway.Subscribe(req);
        }

        /// <summary>
        /// 发单
        /// </summary>
        public void SendOrder(OrderReq req)
        {
            Gateway.SendOrder(req);
        }

        /// <summary>
        /// 撤单
        /// </summary>
        public void CancelOrder(CancelOrderReq req)
        {
            Gateway.CancelOrder(req);
        }

        /// <summary>
        /// 查询账户
        /// </summary>
        public void QryAccount()
        {
            Gateway.QryAccount();
        }


        /// <summary>
        /// 查询持仓
        /// </summary>
        public void QryPosition()
        {
            Gateway.QryAccount();
        }
    }
}
