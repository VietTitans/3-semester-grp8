using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionData.Model;

namespace AuctionData.Service;

public interface ITokenServiceAccess
{
    Task<string?> GetNewToken(ApiAccount accountToUse);
}
