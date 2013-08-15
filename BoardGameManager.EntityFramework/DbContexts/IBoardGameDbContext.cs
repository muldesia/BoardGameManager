using System;
using System.Data.Entity;
using BoardGameManager.EntityFramework.Entities;

namespace BoardGameManager.EntityFramework.DbContexts
{
    public interface IBoardGameDbContext : IContext
    {
        IDbSet<BoardGame> BoardGames { get; set; }
    }
}