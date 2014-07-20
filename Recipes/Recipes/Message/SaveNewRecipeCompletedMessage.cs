using GalaSoft.MvvmLight.Messaging;
using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Message
{
    public class SaveNewRecipeCompletedMessage : MessageBase
    {
        public SaveNewRecipeCompletedMessage(Recipe recipe)
        {
            Recipe = recipe;
        }

        public Recipe Recipe { get; private set; }
    }
}
