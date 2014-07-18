using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.ViewModel;

namespace Recipes.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void TestCanCreateViewModel()
        {
            MainViewModel vm = new MainViewModel(null, null);
            Assert.IsNotNull(vm);
        }
    }
}
