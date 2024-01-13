﻿using Shopping_Cart_API.Data;
using Shopping_Cart_API.Interfaces;
using Shopping_Cart_API.Models;

namespace Shopping_Cart_API.Repository
{
    public class ItemRepository(CartContext context) : IItemRepository
    {
        private readonly CartContext _context = context;

        public ICollection<Item> GetItems()
        {
            return _context.Items.ToList();
        }

        public ICollection<Item> GetItemsByUser(int userId)
        {
            return _context.ItemUsers.Where(iu => iu.User.Id == userId).Select(i => i.Item).ToList();
        }
    }
}
