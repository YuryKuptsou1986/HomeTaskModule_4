using CartingService.DAL.Interfaces;
using CartService.DAL.Exceptions;
using CartService.DAL.LiteDb.DbContext;
using CartService.Domain.Entities;

namespace CartingService.DAL.LiteDb.Repositories
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
            var itemCollection = _dbContext.Database.GetCollection<Item>(nameof(Item)).Insert(item);
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
