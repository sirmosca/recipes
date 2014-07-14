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
        private ObservableCollection<Ingredient> _ingredients;

        public AddNewRecipeViewModel()
        {
            _ingredients = new ObservableCollection<Ingredient>();
        }

        public ICommand AddIngredient
        {
            get
            {
                if (_addIngredient == null)
                {
                    _addIngredient = new RelayCommand(OnAddIngredient);
                }

                return _addIngredient;
            }
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
    }
}
