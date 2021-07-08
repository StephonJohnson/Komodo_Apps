using System;
using System.Linq;

namespace KomodoCafe
{
    public class CafeUI
    {
        private readonly MenuRepo _menuRepo;

        public CafeUI()
        {
            _menuRepo = new MenuRepo();
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

                Console.WriteLine("Welcome back Cafe Admin. Please select an option: \n" +
                    "1. Show all Menu Items\n" +
                    "2. Create a new Menu Item \n" +
                    "3. Remove a Menu Item\n" +
                    "4. Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Show all Items on Menu
                        ShowMenu();
                        break;

                    case "2":
                        //Creating a Menu Item
                        CreateNewMenuItem();
                        break;

                    case "3":
                        //Removing a Menu Item
                        RemoveMenuItem();
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

        private void ShowMenu()
        {
            Console.Clear();

            Menu menu = _menuRepo.GetMenu();

            if (menu == null || menu.MenuItems == null || !menu.MenuItems.Any())
            {
                Console.WriteLine("No Menu Items Available.");
                Console.ReadLine();
                return;
            }

            foreach (MenuItem menuItem in menu.MenuItems)
            {
                //Console Write (Display Content)
                Console.WriteLine($"ID: {menuItem.Id}");
                Console.WriteLine($"MealName: { menuItem.MealName}");
                Console.WriteLine($"MealNumber: { menuItem.MealNumber}");
                Console.WriteLine($"MealDescription: { menuItem.MealDescription}");
                Console.WriteLine($"MealPrice: { menuItem.MealPrice}");
                Console.WriteLine($"Ingredients: { menuItem.MealIngredients}");
            }

            Console.ReadLine();
        }

        private void CreateNewMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Please enter the Meal Number for the New Menu Item: ");
            int mealNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Please enter the Meal Name for the New Menu Item: ");
            string mealName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the Meal Description for the New Menu Item");
            string mealDescription = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the Meal Ingredients for the New Menu Item");
            string mealIngredients = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Please enter the Meal Price for the New Menu Item");
            decimal mealPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine();

            var menuItem = new MenuItem(0 , mealNumber, mealName, mealDescription, mealIngredients, mealPrice);

            _menuRepo.CreateMenuItem(menuItem);
        }

        private void RemoveMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Enter the Meal Number you would like to remove from the Menu:");

            var mealNumber = Convert.ToInt32(Console.ReadLine());

            var isDeleted = _menuRepo.RemoveMenuItemByMealNumber(mealNumber);

            if (isDeleted)
                Console.WriteLine("Removal successful");
            else
                Console.WriteLine("Removal failed");

            Console.ReadLine();
        }
    }
}
