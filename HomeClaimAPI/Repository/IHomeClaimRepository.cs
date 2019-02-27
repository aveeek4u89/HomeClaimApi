using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HomeClaimAPI.Models;
using Microsoft.Azure.Documents;

namespace HomeClaimAPI.Repository
{
    public interface IHomeClaimRepository
    {
        void Initialize();
        Task CreateDatabaseIfNotExistsAsync();
        Task CreateCollectionIfNotExistsAsync();
        Task<Document> CreateDocument(HomeClaim homeClaimModel);
    }
}
