namespace DataAccess.Repository
{
    using Infrastructure.Entities;

    public interface IMainRepository
    {
        UserModel GetUser(string username);
    }
}
