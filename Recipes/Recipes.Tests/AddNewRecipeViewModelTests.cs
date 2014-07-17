﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Recipes.ViewModel;

namespace Recipes.Tests
{
    [TestClass]
    public class AddNewRecipeViewModelTests
    {
        [TestMethod]
        public void CanAddIngredient()
        {
            AddNewRecipeViewModel vm = new AddNewRecipeViewModel();
            vm.AddIngredient.Execute(null);
            int newCount = vm.Ingredients.Count;
            Assert.AreEqual(1, newCount);
        }
    }
}
