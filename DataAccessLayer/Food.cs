namespace FoodApp.Model
{
    public class Food
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public float? Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public bool Available { get; set; } 

    }
}