﻿using System.Net;
using BoardGameManager.EntityFramework.DbContexts;

namespace BoardGameManager.EntityFramework
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : IContext, new()
    {
        private readonly IContext _context;

        public UnitOfWork()
        {
            _context = new TContext();
        }

        public UnitOfWork(IContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public IContext Context {
            get
            {
                return (TContext) _context;
            }
        }
    }
}