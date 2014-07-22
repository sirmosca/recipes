using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Message;
using Recipes.ViewModel;
using System;
using System.Threading;


namespace Recipes.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        private MainViewModel _vm;
        private IMessenger _messenger;

        [TestInitialize]
        public void Init()
        {
            _messenger = new TestMessenger(Messenger.Default);
            _vm = new MainViewModel(new TestRepository(), _messenger);
        }

        [TestMethod]
        public void TestCanCreateViewModel()
        {
            Assert.IsNotNull(_vm);
        }

        [TestMethod]
        public void TestCancelCommandClearsView()
        {
            _vm.CurrentViewModel = new AddNewRecipeNameViewModel(null);
            _messenger.Send<CancelAddNewRecipeNameMessage>(new CancelAddNewRecipeNameMessage());
            Assert.IsNull(_vm.CurrentViewModel);
        }

        [TestMethod]
        public void WhenAddingRecipeThenNewRecipeNameViewIsDisplayed()
        {
            _vm.AddRecipe.Execute(null);
            Assert.IsNotNull(_vm.CurrentViewModel);
        }
    }
}
