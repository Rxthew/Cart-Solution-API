using Shopping_Cart_API.Models;

namespace Shopping_Cart_API.Interfaces
{
    public interface IItemRepository
    {
        ICollection<Item> GetItems();
        ICollection<Item> GetItemsByUser(int userId);
    }
}
