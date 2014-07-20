using GalaSoft.MvvmLight.Messaging;
using Recipes.Model;
using Recipes.Message;
using Recipes.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Service
{
    public class RecipeRepository : IRecipeRepository
    {
        public Recipe Save(string name, string notes, string servingSize)
        {
            Recipe r = new Recipe();
            r.Name = name;
            r.Notes = notes;
            r.ServingSize = servingSize;

            using (var context = new  RecipesEntities())
            {
                r = context.Recipes.Add(r);
                context.SaveChanges();
                return r;
            }
        }

        public Recipe Save(Recipe recipe)
        {
            using (var context = new RecipesEntities())
            {
                recipe = context.Recipes.Add(recipe);
                var v = context.GetValidationErrors();
                context.SaveChanges();
                return recipe;
            }
        }
    }
}
