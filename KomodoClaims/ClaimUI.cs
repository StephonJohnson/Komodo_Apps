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
                        //Show all Items on Menu
                        ShowAllClaims();
                        break;

                    case "2":
                        //Creating a Menu Item
                        //HandleNextClaim();
                        break;

                    case "3":
                        //Removing a Menu Item
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

            _claimRepo.CreateTestClaims();

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
            //Console.Clear();

            //Console.WriteLine("Please enter the Claim ID: ");
            //int claimId = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine();

            //Console.WriteLine("Please enter the Claim Type: ");
            //string claimType = Console.ReadLine();
            //Console.WriteLine();

            //Console.WriteLine("Please enter the Claim Description");
            //string claimDescription = Console.ReadLine();
            //Console.WriteLine();

            //Console.WriteLine("Please enter the Claim Amount");
            //decimal claimAmount = Convert.ToDecimal(Console.ReadLine());
            //Console.WriteLine();

            //Console.WriteLine("Please enter the Date of the Incident");
            //DateTime dateOfIncident = Console.ReadLine(dateOfIncident);
            //Console.WriteLine();
            
            //Console.WriteLine("Please enter the Date of the Claim");
            //decimal mealPrice = Convert.ToDecimal(Console.ReadLine());
            //Console.WriteLine();
            
            //Console.WriteLine("Please enter if the Claim is Valid");
            //bool isValid  = Console.ReadLine(true);
            //Console.WriteLine();

            //var claim = new Claim(0, claimType, claimDescription, claimAmount, dateOfIncident, dateOfClaim, isValid);

            //_claimRepo.CreateNewClaim(claim);
        }

        private void RemoveMenuItem()
        {
            //Console.Clear();

            //Console.WriteLine("Enter the Meal Number you would like to remove from the Menu:");

            //var mealNumber = Convert.ToInt32(Console.ReadLine());

            //var isDeleted = _menuRepo.RemoveMenuItemByMealNumber(mealNumber);

            //if (isDeleted)
            //    Console.WriteLine("Removal successful");
            //else
            //    Console.WriteLine("Removal failed");

            //Console.ReadLine();
        }
    }
}

