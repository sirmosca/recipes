using GalaSoft.MvvmLight.Messaging;
using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Service
{
    public class RecipeRepository
    {
        public void Save(string name, string notes, string servingSize)
        {
            Recipe r = new Recipe();
            r.Name = name;
            r.Notes = notes;
            r.ServingSize = servingSize;

            using (var context = new  RecipesEntities())
            {
                r = context.Recipes.Add(r);
                var b = context.GetValidationErrors();
            }
        }
    }
}
