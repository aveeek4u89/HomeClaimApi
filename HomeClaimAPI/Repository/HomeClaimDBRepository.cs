using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HomeClaimAPI.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;

namespace HomeClaimAPI.Repository
{ 

    public class HomeClaimDBRepository : IHomeClaimRepository
    {
        private static readonly string DatabaseId = "HomeClaimsDB";
        private static readonly string CollectionId = "HomeClaimsCollection";
        private static DocumentClient client;

        public void Initialize()
        {
            client = new DocumentClient(new Uri("https://azuredocdbdemo.documents.azure.com:443/"), "CqWq62Bo4GvKmfADV448832a1Dzvi3qKK3gjNKy809XQUgKs0eTVYgoHPHiNOAAgjmU29BmoWz0TTo9rAczEgA==");
            CreateDatabaseIfNotExistsAsync().Wait();
            CreateCollectionIfNotExistsAsync().Wait();
        }

        public async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task CreateCollectionIfNotExistsAsync()
        {
            try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 1000 });
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Document> CreateDocument(HomeClaim homeClaimModel)
        {
            try
            {
                return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), homeClaimModel);
            }
            catch (DocumentClientException)
            {
                throw;
            }
            
        }

    }
}
