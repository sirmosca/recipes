using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Model;
using Recipes.ViewModel;
using System;

namespace Recipes.Tests
{
    [TestClass]
    public class AddNewRecipeViewModelTests
    {
        private AddNewRecipeViewModel _vm;
        private TestRepository _repo;
        private IMessenger _messenger;

        [TestInitialize]
        public void Init()
        {
            _repo = new TestRepository();
            _messenger = new TestMessenger();
            _vm = new AddNewRecipeViewModel(_repo, _messenger);
        }

        [TestMethod]
        public void CanAddIngredient()
        {
            _vm.AddIngredient.Execute(null);
            Assert.IsTrue(_vm.HasIngredients);
        }

        [TestMethod]
        public void CanAddDirection()
        {
            _vm.AddDirection.Execute(null);
            Assert.IsTrue(_vm.HasDirections);
        }

        [TestMethod]
        public void CanSaveRecipe()
        {
            Recipe r = new Recipe();
            _vm.SetCurrentRecipe(r);
            _vm.Save.Execute(null);
            Assert.AreEqual(1, _repo.NumberOfTimesSaveWasCalled);
        }

        [TestMethod]
        public void CanDeleteIngredient()
        {
            _vm.AddIngredient.Execute(null);
            _vm.DeleteIngredient.Execute(_vm.Ingredients[0]);
            Assert.IsFalse(_vm.HasIngredients);
        }

        [TestMethod]
        public void CanDeleteDirection()
        {
            _vm.AddDirection.Execute(null);
            _vm.DeleteDirection.Execute(_vm.Directions[0]);
            Assert.IsFalse(_vm.HasDirections);
        }
    }
}
