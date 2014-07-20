﻿using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Interface
{
    public interface IRecipeRepository
    {
        Recipe Save(string name, string notes, string servingSize);

        Recipe Save(Recipe recipe);
    }
}
