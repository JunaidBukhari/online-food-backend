namespace DataAccessLayer
{
    public class Food
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; } 
    }
}