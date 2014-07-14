using GalaSoft.MvvmLight;
using System.Windows.Input;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Command;

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
        private Control _currentControl;
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
        }

        public ICommand ViewRecipes
        {
            get
            {
                if (_viewRecipes == null)
                {
                    _viewRecipes = new RelayCommand(OnViewRecipes, () => true);
                }

                return _viewRecipes;
            }
        }

        private void OnViewRecipes()
        {
            throw new System.NotImplementedException();
        }

        public ICommand AddRecipe
        {
            get
            { 
                if (_addRecipe == null) 
                {
                    _addRecipe = new RelayCommand(OnAddRecipe, () => true);
                }

                return _addRecipe;
            }
        }

        private void OnAddRecipe()
        {
            CurrentControl = new View.AddNewRecipeView();
        }

        public Control CurrentControl
        {
            get
            {
                return _currentControl;
            }
            private set 
            {
                _currentControl = value;
                RaisePropertyChanged("CurrentControl");
            }
        }
    }
}