using BLOGN.Data.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Category { get; }
        IArticleRepository Article { get; }
        Task SaveAsync();
        void Save();
    }
}
