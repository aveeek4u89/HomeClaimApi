using System;
using System.Collections.Generic;
using HomeClaimAPI.Models;
using HomeClaimAPI.Repository;
using HomeClaimAPI.Exceptions;
using Microsoft.Azure.Documents;

namespace HomeClaimAPI.Service
{
    public class HomeClaimService : IHomeClaimService
    {
        private readonly IHomeClaimRepository repository;

        public HomeClaimService(IHomeClaimRepository homeClaimRepository)
        {
            repository = homeClaimRepository;
        }

        public HomeClaim CreateHomeClaim(HomeClaim HomeClaim)
        {
            HomeClaim ResHomeClaim;
            Document ResDoc;
            try
            {
                ResDoc = repository.CreateDocument(HomeClaim).Result;
                if (ReferenceEquals(ResDoc, null))
                {
                    throw new Exception();
                }
                else
                {
                    ResHomeClaim = new HomeClaim();
                    ResHomeClaim.id = ResDoc.Id;
                }
            }
            catch
            {
                throw;
            }

            return ResHomeClaim;
        }

    }
}
