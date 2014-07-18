/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Recipes"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Recipes.Interface;
using Recipes.Model;
using Recipes.Service;
using System.Collections.Generic;

namespace Recipes.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            IUnityContainer unity = new UnityContainer();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unity));
            var repo = new RecipeRepository();
 
            unity.RegisterInstance<IMessenger>(Messenger.Default);
            unity.RegisterInstance<IRecipeRepository>(repo, new ContainerControlledLifetimeManager());
            unity.RegisterType<MainViewModel>();
            unity.RegisterType<AddNewRecipeViewModel>();
            unity.RegisterType<AddNewRecipeNameViewModel>();

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AddNewRecipeViewModel AddNewRecipe
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNewRecipeViewModel>();
            }
        }

        public AddNewRecipeNameViewModel AddNewRecipeName
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddNewRecipeNameViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}