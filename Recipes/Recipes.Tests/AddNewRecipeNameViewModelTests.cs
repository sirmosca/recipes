using GalaSoft.MvvmLight.Messaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Interface;
using Recipes.Message;
using Recipes.ViewModel;
using System;

namespace Recipes.Tests
{
    [TestClass]
    public class AddNewRecipeNameViewModelTests
    {
        private AddNewRecipeNameViewModel _vm;
        private TestMessenger _messenger;
        private TestRepository _repo;

        [TestInitialize]
        public void Init()
        {
            _repo = new TestRepository();
            _messenger = new TestMessenger(Messenger.Default);
            _vm = new AddNewRecipeNameViewModel(_repo, _messenger); 
        }

        [TestMethod]
        public void CanSaveRecipe()
        {
            _vm.Save.Execute(null);
            Assert.AreEqual(1, _repo.NumberOfTimesSaveWasCalled);
        }

        [TestMethod]
        public void SavingRecipeSendsSaveRecipeCompletedMessage()
        {
            _vm.Save.Execute(null);
            Assert.IsTrue(_messenger.LastMessageTypeSent == typeof(SaveNewRecipeCompletedMessage));
        }

        [TestMethod]
        public void CancellingRecipeSendsCancelAddNewRecipeMessage()
        {
            _vm.Cancel.Execute(null);
            Assert.IsTrue(_messenger.LastMessageTypeSent == typeof(CancelAddNewRecipeNameMessage));
        }
    }
}
