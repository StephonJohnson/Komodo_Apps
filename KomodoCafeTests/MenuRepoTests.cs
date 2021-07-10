
using KomodoCafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace KomodoCafeTests
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _menuRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this._menuRepository = new MenuRepo();
        }

        [TestMethod]
        public void WhenGetMenuShouldGetTheMenu()
        {
            //Arrange
            Menu menu = null;

            //Act
            menu = _menuRepository.GetMenu();

            //Assert
            Assert.IsNotNull(menu);
        }

        [TestMethod]
        public void WhenGetMenuItemsShouldGetTheMenuItems()
        {
            //Arrange
            List<MenuItem> menuItems = null;

            //Act
            menuItems = _menuRepository.GetMenuItems();

            //Assert
            Assert.IsNotNull(menuItems);
        }

        [TestMethod]
        public void WhenCreateMenuItemShouldCreateMenuItemInMenu()
        {
            //Arrange
            var menu = _menuRepository.GetMenu();
            var menuItems = menu.MenuItems;
            var beforeCount = menuItems.Count;

            var mealNumber = 1;
            var mealName = "TestMealName";
            var mealDescription = "TestMealDescription";
            var mealIngredients = "TestIngredients";
            var mealPrice = 1;

            //Act
            _menuRepository.CreateMenuItem(
            new MenuItem
            {
                Id = 0,
                MealNumber = mealNumber,
                MealName = mealName,
                MealDescription = mealDescription,
                MealIngredients = mealIngredients,
                MealPrice = mealPrice
            });

            var addedMenuItem = _menuRepository.GetMenuItems().FirstOrDefault();

            int afterCount = menuItems.Count;

            //Assert
            Assert.AreNotEqual(beforeCount, afterCount);
            Assert.AreEqual(mealNumber, addedMenuItem.MealNumber);
            Assert.AreEqual(mealName, addedMenuItem.MealName);
            Assert.AreEqual(mealDescription, addedMenuItem.MealDescription);
            Assert.AreEqual(mealIngredients, addedMenuItem.MealIngredients);
            Assert.AreEqual(mealPrice, addedMenuItem.MealPrice);
        }

        [TestMethod]
        public void WhenRemoveMenuItemByMealNumberShouldRemoveMenuItemFromMenu()
        {
            //Arrange
            var mealNumber = 1;

            _menuRepository.CreateMenuItem(
            new MenuItem
            {
                Id = 0,
                MealNumber = mealNumber,
                MealName = string.Empty,
                MealDescription = string.Empty,
                MealIngredients = string.Empty,
                MealPrice = 1
            });

            var menu = _menuRepository.GetMenu();
            var menuItems = menu.MenuItems;
            var beforeCount = menuItems.Count;

            //Act
            var result = _menuRepository.RemoveMenuItemByMealNumber(mealNumber);
            var afterCount = menuItems.Count;

            //Assert
            Assert.IsTrue(result);
            Assert.AreNotEqual(beforeCount, afterCount);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this._menuRepository = null; 
        }
    }
}
