using KomodoClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims
{
    public class ClaimUI
    {
        protected readonly ClaimRepo _claimRepo;

        public ClaimUI()
        {
            _claimRepo = new ClaimRepo();
        }

        public void Run()
        {
            DisplayMenu();
        }

        public void DisplayMenu()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                Console.WriteLine("Welcome back Claims Admin. Please select an option: \n" +
                    "1. Show all Claims\n" +
                    "2. Take care of Next Claim \n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;

                    case "2":
                        HandleNextClaim();
                        break;

                    case "3":
                        CreateNewClaim();
                        break;

                    case "4":
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid number bewtween 1 and 4");
                        break;
                }
            }
        }

        private void ShowAllClaims()
        {
            Console.Clear();

            _claimRepo.QueueSeed();

            var claims = _claimRepo.GetClaims();

            if (claims == null || claims == null || !claims.Any())
            {
                Console.WriteLine("No Claims Available.");
                Console.ReadLine();
                return;
            }

            foreach (Claim claim in claims)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {claim.ClaimId}");
                Console.WriteLine($"ClaimType: { claim.ClaimType}");
                Console.WriteLine($"ClaimDescription: { claim.ClaimDescription}");
                Console.WriteLine($"DateOfClaim: { claim.DateOfClaim}");
                Console.WriteLine($"DateOfIncident: { claim.DateOfIncident}");
                Console.WriteLine($"ClaimAmount: { claim.ClaimAmount}");
                Console.WriteLine($"IsValid: {claim.IsValid}");
            }

            Console.ReadLine();
        }

        private void CreateNewClaim()
        {
            Console.Clear();

            Console.WriteLine("Please enter the Claim ID: ");
            int claimId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter the Claim Type: ");
            string claimType = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the Claim Description");
            string claimDescription = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the Claim Amount");
            decimal claimAmount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter the Date of the Incident");
            DateTime dateOfIncident = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter the Date of the Claim");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine();

            var claim = new Claim(0, claimType, claimDescription, claimAmount, dateOfIncident, dateOfClaim);

            _claimRepo.CreateNewClaim(claim);
        }

        private void HandleNextClaim()
        {
            Console.Clear();
            Console.WriteLine("Do you want to deal with this claim now (y/n)");
            char y;
            char n;
            char.TryParse(Console.ReadLine(), out y);
            char.TryParse(Console.ReadLine(), out n);
            Console.WriteLine();


            var claims = _claimRepo.GetClaims();


            //    var isDeleted = _claimRepo.Dequeue();

            //    if (isDeleted)
            //        Console.WriteLine("Removal successful");
            //    else
            //        Console.WriteLine("Removal failed");

            //    Console.ReadLine();
            //}
        }
    }
}

