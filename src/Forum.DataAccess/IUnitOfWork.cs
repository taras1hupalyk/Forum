using Forum.DataAccess.Repositories.Interfaces;

namespace Forum.DataAccess
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        ICategoryRepository Categories { get; }

        void Save();
    }
}