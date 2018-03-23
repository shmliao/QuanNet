using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon.Gateway
{

    /// <summary>
    /// 行情接口，需要实现很多方法
    /// </summary>
    public interface IMdApi
    {

        /// <summary>
        /// 初始化连接
        /// </summary>
        void Connect();

        /// <summary>
        /// 订阅合约
        /// </summary>
        void Subscribe(SubscribeReq req);
    }


    /// <summary>
    /// 交易接口，需要实现很多方法
    /// </summary>
    public interface ITdApi
    {
        /// <summary>
        /// 初始化连接
        /// </summary>
        void Connect();


        /// <summary>
        /// 发单
        /// </summary>
        void SendOrder(OrderReq req);


        /// <summary>
        /// 撤单
        /// </summary>
        void CancelOrder(CancelOrderReq req);


        /// <summary>
        /// 查询账户
        /// </summary>
        void QryAccount();


        /// <summary>
        /// 查询持仓
        /// </summary>
        void QryPosition();
 
    }

}
