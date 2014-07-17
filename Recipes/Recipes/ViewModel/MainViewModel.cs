using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System.Windows.Input;
using System.Windows.Controls;

using Recipes.Message;
using Recipes.Model;

namespace Recipes.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;
        private ICommand _viewRecipes;
        private ICommand _addRecipe;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _addRecipe = new RelayCommand(OnAddRecipe, () => true);
            _viewRecipes = new RelayCommand(OnViewRecipes, () => true);
            Messenger.Default.Register<CancelAddNewRecipeNameMessage>(this, message => OnCancelAddNewRecipeName(message));
            Messenger.Default.Register<SaveRecipeCompletedMessage>(this, message => OnSaveRecipeCompleted(message));
        }

        private void OnCancelAddNewRecipeName(MessageBase mb)
        {
            CurrentViewModel = null;
        }

        private void OnSaveRecipeCompleted(SaveRecipeCompletedMessage message)
        {
            CurrentViewModel = new AddNewRecipeViewModel(message.Recipe);
        }

        public ICommand ViewRecipes
        {
            get { return _viewRecipes; }
        }

        private void OnViewRecipes()
        {
            throw new System.NotImplementedException();
        }

        public ICommand AddRecipe
        {
            get { return _addRecipe; }
        }

        private void OnAddRecipe()
        {
            CurrentViewModel = new AddNewRecipeNameViewModel();
        }

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (_currentViewModel == value) return;
                _currentViewModel = value;
                RaisePropertyChanged("CurrentViewModel");
            }
        }
    }
}