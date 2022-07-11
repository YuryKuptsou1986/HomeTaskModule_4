using LiteDB;

namespace CartService.DAL.LiteDb.DbContext
{
    public interface ILiteDBContext
    {
        ILiteDatabase Database { get; }
    }
}
