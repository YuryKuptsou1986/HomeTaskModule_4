using CartService.DAL.LiteDb.Providers;
using CartService.Domain.Entities;
using LiteDB;

namespace CartService.DAL.LiteDb.DbContext
{
    public class LiteDBContext : ILiteDBContext
    {
        public ILiteDatabase Database { get; }

        public LiteDBContext(ILiteDbSettingsProvider settingsProvider)
        {
            Database = new LiteDatabase(settingsProvider.ProvideSettings().DataBaseLocation);

            Database.Mapper.Entity<Cart>().DbRef(x => x.Items, nameof(Item));
            Database.Mapper.Entity<Item>().Id(x => x.Id, true);
            Database.GetCollection<Item>().EnsureIndex(x => x.Id);
        }
    }
}
