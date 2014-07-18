using Recipes.Interface;
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

        public void Save(string name, string notes, string servingSize)
        {
            _numberOfTimesSaveWasCalled++;
        }

        public int NumberOfTimesSaveWasCalled
        {
            get { return _numberOfTimesSaveWasCalled; }
        }
    }
}
