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
            AddNewRecipeViewModel vm = new AddNewRecipeViewModel(null);
            vm.AddIngredient.Execute(null);
            int newCount = vm.Ingredients.Count;
            Assert.IsTrue(vm.HasIngredients);
        }

        [TestMethod]
        public void CanAddDirection()
        {
            AddNewRecipeViewModel vm = new AddNewRecipeViewModel(null);
            vm.AddDirection.Execute(null);
            Assert.IsTrue(vm.HasDirections);
        }
    }
}
