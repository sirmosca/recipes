using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;

using System.Windows.Input;
using System.Windows.Controls;

using Recipes.Interface;
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
        private IRecipeRepository _repo;
        private IMessenger _messenger;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IRecipeRepository repo, IMessenger messenger)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _repo = repo;
            _addRecipe = new RelayCommand(OnAddRecipe, () => true);
            _searchRecipes = new RelayCommand(OnSearchRecipes, () => true);

            if (messenger == null)
            {
                return;
            }
            _messenger = messenger;
            _messenger.Register<CancelAddNewRecipeNameMessage>(this, message => OnCancelAddNewRecipeName(message));
            _messenger.Register<SaveNewRecipeCompletedMessage>(this, message => OnNewSaveRecipeCompleted(message));
            _messenger.Register<SaveRecipeCompletedMessage>(this, message => OnSaveRecipeCompleted(message));
        }

        public ICommand SearchRecipes { get; private set; }
        
        public ICommand AddRecipe { get; private set; }

        private void OnCancelAddNewRecipeName(MessageBase mb)
        {
            CurrentViewModel = null;
        }

        private void OnNewSaveRecipeCompleted(SaveNewRecipeCompletedMessage message)
        {
            var vm = new AddNewRecipeViewModel(_repo, _messenger);
            vm.SetCurrentRecipe(message.Recipe);
            CurrentViewModel = vm;
        }

        private void OnSaveRecipeCompleted(SaveRecipeCompletedMessage message)
        {
            CurrentViewModel = null;
        }

        private void OnSearchRecipes()
        {
            throw new System.NotImplementedException();
        }

        private void OnAddRecipe()
        {
            CurrentViewModel = new AddNewRecipeNameViewModel(_repo);
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