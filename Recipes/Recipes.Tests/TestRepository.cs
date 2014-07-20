using Recipes.Interface;
using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Tests
{
    public class TestRepository : IRecipeRepository
    {
        private int _numberOfTimesSaveWasCalled = 0;

        public Recipe Save(string name, string notes, string servingSize)
        {
            _numberOfTimesSaveWasCalled++;
            return null;
        }

        public Recipe Save(Recipe recipe)
        {
            _numberOfTimesSaveWasCalled++;
            return null;
        }

        public int NumberOfTimesSaveWasCalled
        {
            get { return _numberOfTimesSaveWasCalled; }
        }
    }
}
