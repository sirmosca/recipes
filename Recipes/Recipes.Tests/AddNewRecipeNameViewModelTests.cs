using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Interface;
using Recipes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Tests
{
    [TestClass]
    public class AddNewRecipeNameViewModelTests
    {
        [TestMethod]
        public void CanSaveRecipe()
        {
            var repo = new TestRepository();
            var vm = new AddNewRecipeNameViewModel(repo);
            vm.Save.Execute(null);
            Assert.AreEqual(1, repo.NumberOfTimesSaveWasCalled);
        }
    }
}
