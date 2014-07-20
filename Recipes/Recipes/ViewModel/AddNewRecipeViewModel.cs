﻿using GalaSoft.MvvmLight;
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
    public class AddNewRecipeViewModel : ViewModelBase
    {
        private string _recipeName;
        private Recipe _recipe;
        private IRecipeRepository _repo;

        public AddNewRecipeViewModel(IRecipeRepository repo)
        {
            _repo = repo;
            Ingredients = new ObservableCollection<Ingredient>();
            Directions = new ObservableCollection<Direction>();
            Save = new RelayCommand(OnSave);
            AddIngredient = new RelayCommand(OnAddIngredient);
            DeleteIngredient = new RelayCommand<Ingredient>(param => OnDeleteIngredient(param));
            AddDirection = new RelayCommand(OnAddDirection);
            DeleteDirection = new RelayCommand<Direction>(param => OnDeleteDirection(param));
        }

        public ICommand Save { get; private set; }

        private void OnSave()
        {
            _recipe.Ingredients = new Collection<Ingredient>(Ingredients);
            _recipe.Directions = new Collection<Direction>(Directions);
            _recipe = _repo.Save(_recipe);
            Messenger.Default.Send(new SaveRecipeCompletedMessage(_recipe));
        }

        public ICommand AddIngredient { get; private set; }

        private void OnAddIngredient()
        {
            var ingredient = new Ingredient();
            Ingredients.Add(ingredient);
        }

        public ICommand DeleteIngredient { get; private set; }

        private void OnDeleteIngredient(Ingredient ingredient)
        {
            Ingredients.Remove(ingredient);
        }

        public ICommand AddDirection { get; private set; }

        private void OnAddDirection()
        {
            var direction = new Direction();
            direction.Step = Directions.Count + 1;
            Directions.Add(direction);
        }

        public ICommand DeleteDirection { get; private set; }

        private void OnDeleteDirection(Direction direction)
        {
            _recipe.Directions.Remove(direction);
            Directions.Remove(direction);
        }

        //TODO: recipe should be passed in via constructor. this is just easier right now.
        public void SetCurrentRecipe(Recipe recipe)
        {
            _recipe = recipe;
            RecipeName = recipe.Name;
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
