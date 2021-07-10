using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimRepository
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimDescription { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }

        //public bool IsValid => (DateOfIncident - DateOfClaim).TotalDays >= 30;
        public bool IsValid
        {
            get
            {
                if ((DateOfClaim - DateOfIncident).TotalDays >= 30)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public Claim() { }

        public Claim
        (int claimId,
        string claimType,
        string claimDescription,
        decimal claimAmount,
        DateTime dateOfIncident,
        DateTime dateOfClaim)
        {
            ClaimId = claimId;
            ClaimType = claimType;
            ClaimDescription = claimDescription;
            ClaimAmount = claimAmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}