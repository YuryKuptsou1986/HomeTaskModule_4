using CartService.DAL.LiteDb.Entities;

namespace CartService.DAL.LiteDb.Providers
{
    public interface ILiteDbSettingsProvider
    {
        public LiteDbSettings ProvideSettings();
    }
}
