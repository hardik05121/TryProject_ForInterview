using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TryProject.Data;
using TryProject.Model;
using TryProject.Model.DTO;

namespace TryProject.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public CategoryAPIController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetCategorys()
        {
            var categories = _db.DataSet.ToList();

            _response.Result = _mapper.Map<List<CategoryDTO>>(categories);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public async Task<ActionResult<APIResponse>> GetCategory(int id)
        {
            var categories = _db.DataSet.FirstOrDefault(x => x.Id == id);

            _response.Result = _mapper.Map<CategoryDTO>(categories);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<ActionResult<APIResponse>> CreateCategory([FromBody] CategoryCreateDTO createDTO)
        {
            Category category = _mapper.Map<Category>(createDTO);
            await _db.DataSet.AddAsync(category);
            await _db.SaveChangesAsync();

            _response.Result = _mapper.Map<CategoryDTO>(category);
            _response.StatusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
            return CreatedAtRoute("GetCategory", new { id = category.Id }, _response);
        }

        [HttpPost("{id:int}", Name = "UpdateCategory")]
        public async Task<ActionResult<APIResponse>> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            Category category = _mapper.Map<Category>(categoryDTO);
            _db.DataSet.Update(category);
            await _db.SaveChangesAsync();

            _response.Result = _mapper.Map<CategoryDTO>(category);
            _response.StatusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
            return Ok(category);
        }

        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        public async Task<ActionResult<APIResponse>> DeleteCategory(int id)
        {
            Category category = await _db.DataSet.FindAsync(id);

            _db.DataSet.Remove(category);
            await _db.SaveChangesAsync();
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
