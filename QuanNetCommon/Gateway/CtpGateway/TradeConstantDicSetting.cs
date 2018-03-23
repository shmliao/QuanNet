using CTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon.Gateway.CtpGateway
{
    public class TradeConstantDicSetting
    {
        /// <summary>
        /// 价格类型字典
        /// </summary>
        public static Dictionary<object, object> PriceTypeDic = new Dictionary<object, object>()
        {
            {EnumOrderPriceTypeType.LimitPrice,TradeCanstant.priceTypeLimit},
            {EnumOrderPriceTypeType.AnyPrice,TradeCanstant.priceTypeMarket},
            {TradeCanstant.priceTypeLimit,EnumOrderPriceTypeType.LimitPrice},
            {TradeCanstant.priceTypeMarket,EnumOrderPriceTypeType.AnyPrice}
        };

        /// <summary>
        /// 方向类型字典
        /// </summary>
        public static Dictionary<object, object> DirectionTypeDic = new Dictionary<object, object>()
        {
            {EnumDirectionType.Buy,TradeCanstant.DirectLong},
            {EnumDirectionType.Sell,TradeCanstant.DirectShort},
            {TradeCanstant.DirectLong,EnumDirectionType.Buy},
            {TradeCanstant.DirectShort,EnumDirectionType.Sell},
        };


        /// <summary>
        /// 开平类型字典
        /// </summary>
        public static Dictionary<object, object> OffsetTypeDic = new Dictionary<object, object>()
        {
            {EnumOffsetFlagType.Open,TradeCanstant.offsetOpen},
            {EnumOffsetFlagType.Close,TradeCanstant.offsetClose},
            {EnumOffsetFlagType.CloseToday,TradeCanstant.offsetCloseToday},
            {EnumOffsetFlagType.CloseYesterday,TradeCanstant.offsetCloseYesterday},

            {TradeCanstant.offsetOpen,EnumOffsetFlagType.Open},
            {TradeCanstant.offsetClose,EnumOffsetFlagType.Close},
            {TradeCanstant.offsetCloseToday,EnumOffsetFlagType.CloseToday},
            {TradeCanstant.offsetCloseYesterday,EnumOffsetFlagType.CloseYesterday},
        };

        /// <summary>
        /// 持仓类型字典
        /// </summary>
        public static Dictionary<object, object> PositionTypeDic = new Dictionary<object, object>()
        {

            {EnumPosiDirectionType.Long,TradeCanstant.DirectLong},
            {EnumPosiDirectionType.Short,TradeCanstant.DirectShort},
            {EnumPosiDirectionType.Net,TradeCanstant.DirectNet},
      
            {TradeCanstant.DirectLong,EnumPosiDirectionType.Long},
            {TradeCanstant.DirectShort,EnumPosiDirectionType.Short},
            {TradeCanstant.DirectNet,EnumPosiDirectionType.Net},
        };




        /// <summary>
        /// 产品类型字典
        /// </summary>
        public static Dictionary<object, object> ProductTypeDic = new Dictionary<object, object>()
        {

            {EnumProductClassType.Futures,TradeCanstant.productFutures},
            {EnumProductClassType.Options,TradeCanstant.productOption},
            {EnumProductClassType.Combination,TradeCanstant.productCombination},
      
            {TradeCanstant.productFutures,EnumProductClassType.Futures},
            {TradeCanstant.productOption,EnumProductClassType.Options},
            {TradeCanstant.productCombination,EnumProductClassType.Combination},
        };

        /// <summary>
        /// 委托状态字典,正常返回委托状态是没有拒单的，状态拒单的单子在错误回调里设置
        /// </summary>
        public static Dictionary<object, object> StatusTypeDic = new Dictionary<object, object>()
        {

            {EnumOrderStatusType.AllTraded,TradeCanstant.statusAllTraded},
            {EnumOrderStatusType.PartTradedQueueing,TradeCanstant.statusPartTraded},
            {EnumOrderStatusType.NoTradeQueueing,TradeCanstant.statusNotTraded},
            {EnumOrderStatusType.Canceled,TradeCanstant.statusCanceled},
      
            {TradeCanstant.statusAllTraded,EnumOrderStatusType.AllTraded},
            {TradeCanstant.statusPartTraded,EnumOrderStatusType.PartTradedQueueing},
            {TradeCanstant.statusNotTraded,EnumOrderStatusType.NoTradeQueueing},
            {TradeCanstant.statusCanceled,EnumOrderStatusType.NoTradeQueueing},
        };

           /// <summary>
        ///期权类型字典
        /// </summary>
        public static Dictionary<object, object> OptionTypeDic = new Dictionary<object, object>()
        {

            {EnumOptionsTypeType.Call,TradeCanstant.optionCall},
            {EnumOptionsTypeType.Put,TradeCanstant.optionPut},
  
            {TradeCanstant.optionPut,EnumOptionsTypeType.Put},
            {TradeCanstant.optionCall,EnumOptionsTypeType.Call},
        };
    }
}
