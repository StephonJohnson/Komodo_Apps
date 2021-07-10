using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimRepository
{
    public class ClaimRepo

    {
        //FakeDatabase
        protected readonly Queue<Claim> _claims = new Queue<Claim>();


        public ClaimRepo()
        {


        }

        //READ
        public Queue<Claim> GetClaims()
        {
            return _claims;
        }

        //CRUD
        //CREATE
        public bool CreateNewClaim(Claim claim)
        {
            int startingCount = _claims.Count;

            int uniqueId = GetUniqueId();

            claim.ClaimId = uniqueId;

            _claims.Enqueue(claim);

            bool wasAdded = _claims.Count > startingCount;

            return wasAdded;
        }

        //REMOVE
        public bool RemoveClaim(int claimId)
        {
            //if (claimId <= 0)
            //    return false;

            //var claim = _claims.FirstOrDefault(x => x.ClaimId == claimId);

            //if (claim == null)
            //    return false;

            _claims.Dequeue();

            return true;
        }

        private int GetUniqueId()
        {
            var count = _claims.Count;

            return count += 1;
        }

        public void QueueSeed()
        {
            _claims.Enqueue(new Claim
            {
                ClaimId = 1,
                ClaimAmount = 400.00m,
                ClaimType = "Car",
                DateOfIncident = new DateTime(2018, 04, 25),
                ClaimDescription = "Accident",
                DateOfClaim = new DateTime(2018, 04, 27)
            });

            _claims.Enqueue(new Claim
            {
                ClaimId = 2,
                ClaimAmount = 4000.00m,
                ClaimType = "Home",
                DateOfIncident = new DateTime(2018, 04, 11),
                ClaimDescription = "Kitchen Fire",
                DateOfClaim = new DateTime(2018, 04, 12),
            });

            _claims.Enqueue(new Claim
            {
                ClaimId = 3,
                ClaimAmount = 40.00m,
                ClaimType = "Theft",
                DateOfIncident = new DateTime(2018, 04, 27),
                ClaimDescription = "Stolen Pancakes",
                DateOfClaim = new DateTime(2018, 06, 01),
            });
        }
    }
}

