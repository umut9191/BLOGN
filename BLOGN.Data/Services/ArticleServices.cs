using BLOGN.Data.Repositories.IRepository;
using BLOGN.Data.Services.IServices;
using BLOGN.Data.UnitOfWork;
using BLOGN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data.Services
{
    public class ArticleServices : Services<Article>, IArticleServices
    {
        public ArticleServices(IUnitOfWork unitOfWork, IRepository<Article> repository) : base(unitOfWork, repository)
        {
        }
    }
}
