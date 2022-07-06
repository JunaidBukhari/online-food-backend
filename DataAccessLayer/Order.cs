namespace FoodApp.Model

{
    public class Order
    {
        public int Id { get; set; }
        public int FoodId { get; set; } 
        public int UserId { get; set; }
        public string? Amount { get; set; }
        public string? Status { get; set; }
        public bool Rated { get; set; }
        public string? PaymentMethod { get; set; }

    }
}