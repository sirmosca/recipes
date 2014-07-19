using GalaSoft.MvvmLight.Messaging;
using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Message
{
    public class DeleteIngredientMessage : MessageBase
    {
        public DeleteIngredientMessage(Ingredient ingredient)
        {
            Ingredient = ingredient;
        }

        public Ingredient Ingredient { get; private set; }
    }
}
