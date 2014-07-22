using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Recipes.Interface;
using Recipes.Message;
using Recipes.Model;
using Recipes.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipes.ViewModel
{
    public class AddNewRecipeNameViewModel : ViewModelBase
    {
        private ICommand _save;
        private ICommand _cancel;
        private IRecipeRepository _repo;
        private IMessenger _messenger;

        public AddNewRecipeNameViewModel(IRecipeRepository repo, IMessenger messenger)
        {
            _repo = repo;
            _messenger = messenger;
            _save = new RelayCommand(OnSave);
            _cancel = new RelayCommand(OnCancel);
        }

        private void OnSave()
        {
            try
            {
                var recipe = _repo.Save(Name, Notes, ServingSize);
                _messenger.Send(new SaveNewRecipeCompletedMessage(recipe));
            }
            catch (Exception ex)
            {
                //log here
            }
        }

        private void OnCancel()
        {
            _messenger.Send(new CancelAddNewRecipeNameMessage());
        }

        public ICommand Cancel { get { return _cancel; } }

        public ICommand Save { get { return _save; } }
        
        public string Name { get; set; }

        public string Notes { get; set; }

        public string ServingSize { get; set; }
    }
}
