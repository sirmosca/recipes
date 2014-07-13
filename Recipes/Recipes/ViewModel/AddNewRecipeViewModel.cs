using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;


namespace Recipes.ViewModel
{
    public class AddNewRecipeViewModel : ViewModelBase
    {
        private ICommand _theCommand;

        public ICommand TheCommand
        {
            get
            {
                if (_theCommand == null)
                {
                    _theCommand = new RelayCommand(Onstuff);
                }
                return _theCommand;
            }
        }

        private void Onstuff()
        {
            throw new NotImplementedException();
        }
    }
}
