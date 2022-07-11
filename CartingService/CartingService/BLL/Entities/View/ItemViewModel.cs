using CartService.Domain.Entities;

namespace CartService.BLL.Entities.View
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ImageInfoViewModel ImageInfo { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
