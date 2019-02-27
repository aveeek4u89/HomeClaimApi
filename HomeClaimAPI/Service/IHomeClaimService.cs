using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeClaimAPI.Models;

namespace HomeClaimAPI.Service
{
    public interface IHomeClaimService
    {
        HomeClaim CreateHomeClaim(HomeClaim homeClaim);
    }
}
