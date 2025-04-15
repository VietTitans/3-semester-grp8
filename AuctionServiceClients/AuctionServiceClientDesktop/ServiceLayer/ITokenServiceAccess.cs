using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionServiceClientDesktop.ModelLayer;

namespace AuctionServiceClientDesktop.ServiceLayer
{
    public interface ITokenServiceAccess
    {
        Task<string?> GetNewToken(ApiAccount accountToUse);
    }

}
