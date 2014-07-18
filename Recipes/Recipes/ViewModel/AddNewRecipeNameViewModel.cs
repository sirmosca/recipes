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

        public AddNewRecipeNameViewModel(IRecipeRepository repo)
        {
            _repo = repo;
            _save = new RelayCommand(OnSave);
            _cancel = new RelayCommand(OnCancel);
        }

        private void OnSave()
        {
            try
            {
                _repo.Save(Name, Notes, ServingSize);
            }
            catch (Exception ex)
            {
                //log here
            }
        }

        private void OnCancel()
        {
            Messenger.Default.Send(new CancelAddNewRecipeNameMessage());
        }

        public ICommand Cancel { get { return _cancel; } }

        public ICommand Save { get { return _save; } }
        
        public string Name { get; set; }

        public string Notes { get; set; }

        public string ServingSize { get; set; }
    }
}
