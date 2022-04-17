using BLOGN.Data.Repositories.IRepository;
using BLOGN.Data.Repositories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICategoryRepository Category => new CategoryRepository(_context);
        public IArticleRepository Article => new ArticleRepository(_context);
        public IUserRepository User => new UserRepository(_context);
        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
