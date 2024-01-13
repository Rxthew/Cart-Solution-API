using Microsoft.EntityFrameworkCore;
using Shopping_Cart_API.Data;
using Shopping_Cart_API.Interfaces;
using Shopping_Cart_API.Models;

namespace Shopping_Cart_API.Repository
{
    public class UserRepository: IUserRepository { 

        private readonly CartContext _context;

        public UserRepository(CartContext context)
        {
            _context = context;
        }

        public User GetUser(string username)

        {
            return _context.Users
                  .Where(u => u.Username == username)
                  .FirstOrDefault();

        }
        
        public void AddNewItem(int userId, int itemId)
        {
            User user =  _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            Item newItem = _context.Items.Where(i => i.Id == itemId).FirstOrDefault();

            _context.ItemUsers.Add(new ItemUser() { 
                Amount = 1, 
                Item = newItem,
                ItemId = itemId, 
                User = user, 
                UserId = userId,
            });

            _context.SaveChanges();
        }

        public void RemoveItem(int userId, int itemId)
        {
            
            ItemUser itemUser = _context.ItemUsers.Where(iu => iu.ItemId == itemId && iu.UserId == userId).FirstOrDefault();
            _context.ItemUsers.Remove(itemUser);

            _context.SaveChanges();
        }

        public void IncrementItem(int userId, int itemId)
        {
            ItemUser itemUser = _context.ItemUsers.Where(iu => iu.ItemId == itemId && iu.UserId == userId).FirstOrDefault();

            itemUser.Amount++;

            _context.SaveChanges();
        }

        public void DecrementItem(int userId, int itemId)
        {
            ItemUser itemUser = _context.ItemUsers.Where(iu => iu.ItemId == itemId && iu.UserId == userId).FirstOrDefault();

            if (itemUser.Amount > 0)
            {
                itemUser.Amount--;
            }
            else
            {
                _context.ItemUsers.Remove(itemUser);
            }

            _context.SaveChanges();
        }

        public void ClearCart(int userId)
        {

            ICollection<ItemUser> userCart = _context.ItemUsers.Where(iu => iu.UserId == userId).ToList();
            _context.ItemUsers.RemoveRange(userCart);
            

            _context.SaveChanges();
        }


    }
}
