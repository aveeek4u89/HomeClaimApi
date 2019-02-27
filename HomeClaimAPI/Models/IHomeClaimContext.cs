using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace HomeClaimAPI.Models
{
    public interface IHomeClaimContext
    {
        IMongoCollection<HomeClaim> Categories { get; }
    }
}
