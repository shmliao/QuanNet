using QuanNetCommon.MainControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon.Gateway.CtpGateway
{
    public class CtpGateway:BaseGateway<CtpMdApi, CtpTdApi>
    {
        public MainController MainController;

        public CtpGateway(MainController mainController) 
        {
            MainController = mainController;
        }

        public override string gatewayName
        {
            get 
            {
                return "CTP";
            }
        }

        public override void Connect()
        {
            this.md.Connect();
            this.td.Connect();
        }

        public override void QryAccount()
        {
            this.td.QryAccount();
        }

        public override void SendOrder(OrderReq req)
        {
            this.td.SendOrder(req);
        }

        public override void QryPosition()
        {
            this.td.QryPosition();
        }

        public override void Subscribe(SubscribeReq req)
        {
            this.md.Subscribe(req);
        }

        public override void CancelOrder(CancelOrderReq req)
        {
            this.td.CancelOrder(req);
        }
    }
}
