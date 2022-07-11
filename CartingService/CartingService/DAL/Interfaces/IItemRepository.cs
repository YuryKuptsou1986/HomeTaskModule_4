using CartService.Domain.Entities;

namespace CartingService.DAL.Interfaces
{
    public interface IItemRepository
    {
        public void AddItem(Item item);
        public void DeleteItem(int itemId);
    }
}
