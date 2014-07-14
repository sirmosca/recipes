namespace Recipes.Model
{
    public class Ingredient
    {
        private int _ingredientId;
        private int _recipeId;
        private string _description;

        public int RecipeId
        {
            get { return _recipeId; }
            set { _recipeId = value; }
        }
       
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int IngredientId
        {
            get { return _ingredientId; }
            set { _ingredientId = value; }
        }
    }
}
