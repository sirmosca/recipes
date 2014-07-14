//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recipes.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        public Recipe()
        {
            this.Directions = new HashSet<Direction>();
            this.Ingredients = new HashSet<Ingredient>();
        }
    
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string ServingSize { get; set; }
    
        public virtual ICollection<Direction> Directions { get; set; }
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
