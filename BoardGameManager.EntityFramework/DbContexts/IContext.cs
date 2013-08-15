using System;

namespace BoardGameManager.EntityFramework.DbContexts
{
    public interface IContext : IDisposable
    {
        int SaveChanges();
        void SetModified(object entity);
        void SetAdd(object entity);
    }
}