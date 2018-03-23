using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon
{
    /// <summary>
    /// 交易常量定义
    /// </summary>
    public class TradeCanstant
    {
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectNone="directNone";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectUnkown="directUnkown";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectLong="directLong";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectShort="directShort";
       /// <summary>
       /// 交易,持仓方向
       /// </summary>
       public const string DirectNet="directNet";

       /// <summary>
       ///  交易,持仓方向，证券期权
       /// </summary>
       public const string DirectCoveredShort="directCoveredShort";

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       /// <summary>
       ///  开平常量，
       /// </summary>
       public const string offsetNone="offsetNone";
        /// <summary>
       ///  开平常量，
       /// </summary>
       public const string offsetOpen="offsetOpen";
        /// <summary>
       ///  开平常量，
       /// </summary>
       public const string offsetClose="offsetClose";
        /// <summary>
       ///  开平常量，
       /// </summary>
       public const string offsetCloseToday="offsetCloseToday";
        /// <summary>
       ///  开平常量，
       /// </summary>
       public const string offsetCloseYesterday="offsetCloseYesterday";
        /// <summary>
       ///  开平常量，
       /// </summary>
       public const string offsetUnKown="offsetUnKown";

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

         /// <summary>
       ///  状态常量，
       /// </summary>
       public const string statusNotTraded="statusNotTraded";
        /// <summary>
       ///  状态常量，
       /// </summary>
       public const string statusPartTraded="statusPartTraded";
        /// <summary>
       ///  状态常量，
       /// </summary>
       public const string statusAllTraded="statusAllTraded";
        /// <summary>
       ///  状态常量，
       /// </summary>
       public const string statusCanceled="statusCanceled";
        /// <summary>
       ///  状态常量，
       /// </summary>
       public const string statusReject="statusReject";
        /// <summary>
       ///  状态常量，
       /// </summary>
       public const string statusUnKown="statusUnKown";

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

       /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productEquity="productEquity";

        /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productFutures="productFutures";

           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productOption="productOption";

         /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productIndex="productIndex";

         /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productCombination="productCombination";

             /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productForex="productForex";

           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productUnknown="productUnknown";

           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productSpot="productSpot";

        
           /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productDefer="productDefer";

         /// <summary>
       ///  合约类型常量，
       /// </summary>
       public const string productNone="productNone";


///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
          /// <summary>
       ///  价格类型常量，
       /// </summary>
       public const string priceTypeLimit="priceTypeLimit";

        /// <summary>
       ///  价格类型常量，
       /// </summary>
       public const string priceTypeMarket="priceTypeMarket";

         /// <summary>
       ///  价格类型常量，
       /// </summary>
       public const string priceTypeFak="priceTypeFak";

         /// <summary>
       ///  价格类型常量，
       /// </summary>
       public const string priceTypeFok="priceTypeFok";

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

         /// <summary>
       ///  期权类型，
       /// </summary>
       public const string optionCall="optionCall";

         /// <summary>
       ///  期权类型，
       /// </summary>
       public const string optionPut="optionPut";

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

          /// <summary>
       ///  交易所类型:上交所，
       /// </summary>
       public const string exchangeSSE="exchangeSSE";

        /// <summary>
       ///  交易所类型:深交所，
       /// </summary>
       public const string exchangeSZSE="exchangeSZSE";


          /// <summary>
       ///  交易所类型:中金所，
       /// </summary>
       public const string exchangeCFFEX="exchangeCFFEX";

            /// <summary>
       ///  交易所类型:郑商所，
       /// </summary>
       public const string exchangeCZCE="exchangeCZCE";

              /// <summary>
       ///  交易所类型:上期所，
       /// </summary>
       public const string exchangeSHFE="exchangeSHFE";

         /// <summary>
       ///  交易所类型:大商所，
       /// </summary>
       public const string exchangeDCE="exchangeDCE";


            /// <summary>
       ///  交易所类型:上金所，
       /// </summary>
       public const string exchangeSGE="exchangeSGE";


           /// <summary>
       ///  交易所类型:国际能源交易中心，
       /// </summary>
       public const string exchangeINE="exchangeINE";

        
           /// <summary>
       ///  交易所类型:未知交易所，
       /// </summary>
       public const string exchangeUNKNOWN="exchangeUNKNOWN";

        
           /// <summary>
       ///  交易所类型:空交易所，
       /// </summary>
       public const string exchange="exchange";

        /// <summary>
       ///  交易所类型:港交所，
       /// </summary>
       public const string exchangeHKEX="exchangeHKEX";

           /// <summary>
       ///  交易所类型:香港期货交易所，
       /// </summary>
       public const string exchangeHKFE="exchangeHKFE";

              /// <summary>
       ///  交易所类型:IB智能路由（股票、期权），
       /// </summary>
       public const string exchangeSMART="exchangeSMART";

         /// <summary>
       ///  交易所类型:IB 期货，
       /// </summary>
       public const string exchangeNYMEX="exchangeNYMEX";

         /// <summary>
       ///  交易所类型:CME电子交易平台，
       /// </summary>
       public const string exchangeGLOBEX="exchangeGLOBEX";

           /// <summary>
       ///  交易所类型:IB外汇ECN，
       /// </summary>
       public const string exchangeIDEALPRO="exchangeIDEALPRO";

               /// <summary>
       ///  交易所类型:CME交易所，
       /// </summary>
       public const string exchangeCME="exchangeCME";

             /// <summary>
       ///  交易所类型:ICE交易所，
       /// </summary>
       public const string exchangeICE="exchangeICE";

         /// <summary>
       ///  交易所类型:LME交易所，
       /// </summary>
       public const string exchangeLME="exchangeLME";

          /// <summary>
       ///  交易所类型:OANDA外汇做市商，
       /// </summary>
       public const string exchangeOANDA="exchangeOANDA";

           /// <summary>
       ///  交易所类型:OKCOIN比特币交易所，
       /// </summary>
       public const string exchangeOKCOIN="exchangeOKCOIN";

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            /// <summary>
       ///  货币类型:美元，
       /// </summary>
       public const string currencyUSD="currencyUSD";

        /// <summary>
       ///  货币类型:CNY，
       /// </summary>
       public const string currencyCNY="currencyCNY";

       /// <summary>
       ///  货币类型:HKD，
       /// </summary>
       public const string currencyHKD="currencyHKD";
    }
}
