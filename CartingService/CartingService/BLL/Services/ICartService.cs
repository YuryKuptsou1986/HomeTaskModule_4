using CartService.BLL.Entities.Insert;
using CartService.BLL.Entities.View;

namespace CartService.BLL.Services
{
    public interface ICartService
    {
        public CartViewModel GetCartById(string id);
        public void AddItem(CartInsertViewModel item);
        public void DeleteItem(string cartId, int itemId);
    }
}
