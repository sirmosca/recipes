using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Interface
{
    public interface IRecipeRepository
    {
        void Save(string name, string notes, string servingSize);
    }
}
