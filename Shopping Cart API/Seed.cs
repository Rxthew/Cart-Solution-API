using Shopping_Cart_API.Data;
using Shopping_Cart_API.Models;

namespace Shopping_Cart_API

    
{
    public class Seed
    {
        private readonly CartContext cartContext;
        public Seed(CartContext cartContext)
        {
            this.cartContext = cartContext;
        }
        public void SeedDataContext()
        {
            if(!cartContext.ItemUsers.Any()) {

                User John = new User()
                {
                    Username = "John Doe",
                    Password = "johndoe"

                };
                User Jane = new User()
                {
                    Username = "Jane Doe",
                    Password = "janedoe"

                };
                Item Red = new Item()
                {
                    Name = "Classic Red Pullover Hoodie",
                    Price = 7797

                };
                Item Heather = new Item()
                {
                    Name = "Classic Heather Grey Hoodie",
                    Price = 69
                };
                Item Grey = new Item()
                {
                    Name = "Classic Grey Hooded Sweatshirt",
                    Price = 90
                };
                Item Black = new Item()
                {
                    Name = "Classic Black Hooded Sweatshirt",
                    Price = 79
                };

                var users = new List<User>() { John, Jane };
                var items = new List<Item>() { Red, Heather, Grey, Black };


                var itemUsers = new List<ItemUser>()
                {
                    new ItemUser()
                    {
                        Amount = 1,
                        Item = Red,
                        User = John

                    },
                    new ItemUser()
                    {
                        Amount = 2,
                        Item = Heather,
                        User = Jane

                    }
                };

                cartContext.Items.AddRange(items);
                cartContext.Users.AddRange(users);
                cartContext.ItemUsers.AddRange(itemUsers);
                cartContext.SaveChanges();
            }
        }
    }
}
