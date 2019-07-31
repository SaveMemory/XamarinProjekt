using SQLite.Net;

namespace MobileApp
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
