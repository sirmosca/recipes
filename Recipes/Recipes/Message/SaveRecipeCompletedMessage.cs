using GalaSoft.MvvmLight.Messaging;
using Recipes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes.Message
{
    public class SaveRecipeCompletedMessage : MessageBase
    {
        public SaveRecipeCompletedMessage(Recipe recipe)
        {
            Recipe = recipe;
        }

        public Recipe Recipe { get; private set; }
    }
}
