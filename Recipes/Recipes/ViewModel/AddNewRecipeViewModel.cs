using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using Recipes.Model;

namespace Recipes.ViewModel
{
    public class AddNewRecipeViewModel : ViewModelBase
    {
        private ICommand _addIngredient;
        private string _recipeName;
        private ObservableCollection<Ingredient> _ingredients;

        public AddNewRecipeViewModel()
        {
            RecipeName = "test";
            _ingredients = new ObservableCollection<Ingredient>();
            _addIngredient = new RelayCommand(OnAddIngredient);
        }

        public ICommand AddIngredient
        {
            get { return _addIngredient; }
        }

        private void OnAddIngredient()
        {
            Ingredients.Add(new Ingredient());
        }

        public ObservableCollection<Ingredient> Ingredients
        {
            get
            {
                return _ingredients;
            }
        }

        public string RecipeName
        {
            get { return _recipeName; }
            private set
            {
                _recipeName = value;
                RaisePropertyChanged("RecipeName");
            }
        }
    }
}
