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
        private IMessenger _messenger;

        public AddNewRecipeViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            Ingredients = new ObservableCollection<Ingredient>();
            Directions = new ObservableCollection<Direction>();
            AddIngredient = new RelayCommand(OnAddIngredient);
            DeleteIngredient = new RelayCommand<Ingredient>(OnDeleteIngredient);
            AddDirection = new RelayCommand(OnAddDirection);
        }

        public void SetCurrentRecipe(Recipe recipe)
        {
            RecipeName = recipe.Name;
        }

        public ICommand AddIngredient { get; private set; }

        public ICommand DeleteIngredient { get; private set; }

        private void OnAddIngredient()
        {
            Ingredients.Add(new Ingredient());
        }

        private void OnDeleteIngredient(Ingredient ingredient)
        {
            _messenger.Send<DeleteIngredientMessage>(new DeleteIngredientMessage(ingredient));
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
