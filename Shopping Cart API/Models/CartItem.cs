namespace Shopping_Cart_API.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int Amount { get; set; }
    }
}
