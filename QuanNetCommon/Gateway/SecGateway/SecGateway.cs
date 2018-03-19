using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanNetCommon.Gateway.SecGateway
{
    public class SecGateway:BaseGateway<SecMdApi, SecTdApi>
    {
        public override string gatewayName
        {
            get
            {
                return "SEC";
            }
        }
    }
}
