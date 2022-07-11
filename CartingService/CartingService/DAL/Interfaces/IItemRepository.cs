using BasketService.Domain.Entities;

namespace BasketService.DAL.Interfaces
{
    public interface IItemRepository
    {
        public void AddItem(Item item);
        public void DeleteItem(int itemId);
    }
}
