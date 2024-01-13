namespace Shopping_Cart_API.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Price { get; set; }
        public ICollection<ItemUser> ItemUsers { get; set; }


    }
}
