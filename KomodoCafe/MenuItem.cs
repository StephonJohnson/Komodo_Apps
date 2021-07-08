namespace KomodoCafe
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public decimal MealPrice { get; set; }
        public string MealIngredients { get; set; }

        public MenuItem() { }

        public MenuItem(int id, int mealNumber, string mealName, string mealDesctription, string mealIngredients, decimal mealPrice)
        {
            Id = id;
            MealNumber = mealNumber;
            MealName = mealName;
            MealDescription = mealDesctription;
            MealPrice = mealPrice;
            MealIngredients = mealIngredients; 
        }
    }
}
