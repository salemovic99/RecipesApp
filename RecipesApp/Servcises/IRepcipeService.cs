using RecipesApp.Models;

namespace RecipesApp.Servcises
{
    public interface IRepcipeService
    {
        public Task<Rootobject> getRecipes();
        public Task<Recipe> getRecipesById(int id);
    }

}
