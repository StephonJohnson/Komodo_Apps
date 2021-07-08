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
        protected readonly Queue<Claim> _claims;

        public ClaimRepo()
        {
            _claims = new Queue<Claim>();
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

            bool wasAdded = (_claims.Count > startingCount);

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

        public void CreateTestClaims()
        {
            _claims.Enqueue(new Claim 
            {
                ClaimId = 1,
                ClaimAmount = 400.00m,
                ClaimType = "Car",
                DateOfIncident = new DateTime(2018, 04, 25),
                ClaimDescription = "Accident",
                DateOfClaim =new DateTime(2018, 01, 31)
            });

            _claims.Enqueue(new Claim
            {
                ClaimId = 2,
                ClaimAmount = 20,
                ClaimType = "Claim2",
                DateOfClaim = DateTime.Now.AddDays(-2),
                ClaimDescription = "Claim2",
                DateOfIncident = DateTime.Now.AddDays(-2)
            });

            _claims.Enqueue(new Claim
            {
                ClaimId = 3,
                ClaimAmount = 30,
                ClaimType = "Claim3",
                DateOfClaim = DateTime.Now.AddDays(-3),
                ClaimDescription = "Claim3",
                DateOfIncident = DateTime.Now.AddDays(-3)
            });
        }
    }
}

