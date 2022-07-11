using BasketService.DAL.Interfaces;
using BasketService.DAL.Exceptions;
using BasketService.DAL.LiteDb.DbContext;
using BasketService.Domain.Entities;

namespace BasketService.DAL.LiteDb.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly ILiteDBContext _dbContext;

        public ItemRepository(ILiteDBContext dbContext)
        {
            if (dbContext == null) {
                throw new ArgumentNullException("Can not be null", nameof(dbContext));
            }
            _dbContext = dbContext;
        }

        public void AddItem(Item item)
        {
            _dbContext.Database.GetCollection<Item>(nameof(Item)).Insert(item);
        }

        public void DeleteItem(int itemId)
        {
            var item = _dbContext.Database.GetCollection<Item>(nameof(Item)).FindById(itemId);
            if (item == null) {
                throw new NotFoundException(nameof(Item), itemId);
            }

            _dbContext.Database.GetCollection<Item>(nameof(Item)).Delete(itemId);
        }
    }
}
