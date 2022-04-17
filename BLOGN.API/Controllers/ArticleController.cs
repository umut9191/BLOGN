using AutoMapper;
using BLOGN.Data.Services.IServices;
using BLOGN.Models;
using BLOGN.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BLOGN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleServices _articleServices;
        private readonly IMapper _mapper;
        public ArticleController(IArticleServices articleServices, IMapper mapper)
        {
            _articleServices = articleServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var article = await _articleServices.GetAll();
            var articleDto = _mapper.Map<IEnumerable<ArticleDto>>(article);
            return Ok(articleDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var article = await _articleServices.Get(id);
            var articleDto = _mapper.Map<ArticleDto>(article);
            return Ok(articleDto);
        }
        [HttpPost]
        public async Task<IActionResult> Save(ArticleDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            var newArticle = await _articleServices.Add(article);
            return Created(string.Empty, null);
        }
        [HttpPatch]
        public IActionResult Patch(int id, ArticleDto articleDto)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var article = _mapper.Map<Article>(articleDto);
            _articleServices.Update(article);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _articleServices.Delete(id);
            return NoContent();

        }
    }
}
