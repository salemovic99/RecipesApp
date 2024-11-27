namespace RecipesApp.Models
{
    public class Rootobject
    {
        public Recipe[]? recipes { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }

}
