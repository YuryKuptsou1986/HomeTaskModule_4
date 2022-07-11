using System.Collections.Generic;

namespace CartService.BLL.Entities.View
{
    public class CartViewModel
    {
        public string Id { get; set; }

        public IEnumerable<ItemViewModel> Items { get; set; }
    }
}
