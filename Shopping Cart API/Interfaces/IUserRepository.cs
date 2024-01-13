using Shopping_Cart_API.Models;

namespace Shopping_Cart_API.Interfaces
{
    public interface IUserRepository
    {
       User GetUser(string username);
        void AddNewItem(int userId, int itemId);
        void RemoveItem(int userId, int itemId);
        void IncrementItem(int userId, int itemId);
        void DecrementItem(int userId, int itemId);
        public void ClearCart(int userId);

    }
}
