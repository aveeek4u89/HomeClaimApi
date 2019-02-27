using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;

namespace HomeClaimAPI.Models
{
    public class HomeClaimContext : IHomeClaimContext
    {
        private readonly ICosmosDatabase database;
        private const string EndpointUri = "<your endpoint URI>";
        private const string PrimaryKey = "<your key>";
        DocumentClient client;

        public HomeClaimContext(IConfiguration configuration)
        {
            var constr = Environment.GetEnvironmentVariable("Mongo_DB");
            if(ReferenceEquals(constr, null))
            {
                constr = configuration.GetSection("MongoDB:ConnectionString").Value;
            }
            client = new MongoClient(constr);
            database = client.GetDatabase(configuration.GetSection("MongoDB:Database").Value);
        }

        private async Task GetStartedDemo()
        {
            this.client = new DocumentClient(new Uri(EndpointUri), PrimaryKey);
        }

        public IMongoCollection<HomeClaim> Categories => database.GetCollection<HomeClaim>("Categories");
    }
}
