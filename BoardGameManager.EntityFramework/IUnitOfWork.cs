using System;
using System.Data.Entity;
using BoardGameManager.EntityFramework.DbContexts;

namespace BoardGameManager.EntityFramework
{
    public interface IUnitOfWork : IDisposable
    {
        int Save();
        IContext Context { get; }
    }
}