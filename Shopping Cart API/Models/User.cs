namespace Shopping_Cart_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<ItemUser> ItemUsers { get; set; }
    }
}
