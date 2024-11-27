using RecipesApp.Models;

namespace RecipesApp.Servcises
{
    public class RecipeService : IRepcipeService
    {
        private readonly HttpClient _httpClient;
        private readonly string URl = "https://dummyjson.com/recipes";

        public RecipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<Rootobject> getRecipes()
        {
            return await _httpClient.GetFromJsonAsync<Rootobject>(URl);
        }

        public async Task<Recipe> getRecipesById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Recipe>(URl + $"/{id}");

        }
    }
}
