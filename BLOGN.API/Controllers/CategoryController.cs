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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryServices categoryServices, IMapper mapper)
        {
            _categoryServices = categoryServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryServices.GetAll();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Ok(categoryDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryServices.Get(id);
            var categoryDto = _mapper.Map<CategoryDto>(category);
            return Ok(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            var newCategory = await _categoryServices.Add(category);
            return Created(string.Empty,null);
        }
        [HttpPatch]
        public IActionResult Patch(int id, CategoryDto categoryDto)
        {
            if (id == 0)
            {
                return BadRequest();
            }  
            var category = _mapper.Map<Category>(categoryDto);
            _categoryServices.Update(category);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _categoryServices.Delete(id);
            return NoContent();

        }
    }
}
