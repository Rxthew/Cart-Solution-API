namespace Shopping_Cart_API.Models
{
    public class ItemUser
    {
        public int ItemId { get; set; }
        public int UserId { get; set; }
        public Item Item { get; set; }

        public User User { get; set; }

        public int Amount { get; set; }

    }
}
