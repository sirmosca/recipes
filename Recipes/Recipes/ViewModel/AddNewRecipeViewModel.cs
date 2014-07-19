using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Recipes.Message;
using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipes.ViewModel
{
    public class AddNewRecipeViewModel : ViewModelBase
    {
        private string _recipeName;
        private Recipe _recipe;

        public AddNewRecipeViewModel()
        {
            AddIngredient = new RelayCommand(OnAddIngredient);
            DeleteIngredient = new RelayCommand<Ingredient>(param => OnDeleteIngredient(param));
            AddDirection = new RelayCommand(OnAddDirection);
        }

        public void SetCurrentRecipe(Recipe recipe)
        {
            _recipe = recipe;
            RecipeName = recipe.Name;
            Ingredients = new ObservableCollection<Ingredient>(recipe.Ingredients);
            Directions = new ObservableCollection<Direction>(recipe.Directions);
        }

        public ICommand AddIngredient { get; private set; }

        public ICommand DeleteIngredient { get; private set; }

        private void OnAddIngredient()
        {
            var ingredient = new Ingredient();
            _recipe.Ingredients.Add(ingredient);
            Ingredients.Add(ingredient);
        }

        private void OnDeleteIngredient(Ingredient ingredient)
        {
            _recipe.Ingredients.Remove(ingredient);
            Ingredients.Remove(ingredient);
        }

        public ICommand AddDirection { get; private set; }

        private void OnAddDirection()
        {
            var direction = new Direction();
            direction.Step = Directions.Count + 1;
            Directions.Add(direction);
        }

        public ObservableCollection<Ingredient> Ingredients { get; private set; }

        public ObservableCollection<Direction> Directions { get; private set; }

        public bool HasIngredients
        {
            get { return Ingredients.Count > 0; }
        }

        public bool HasDirections
        {
            get { return Directions.Count > 0; }
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
