

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using TryProject_Utility;
using TryProjectWeb.Model;
using TryProjectWeb.Model.DTO;
using TryProjectWeb.Services.IServices;

namespace TryProjectWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryService categoryService,IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        public async Task<IActionResult> IndexCategory()
        {
            List<CategoryDTO>  categories= new();

            var responce = await _categoryService.GetAllAsync<APIResponse>();
            if (responce != null && responce.IsSuccess)
            {
                categories = JsonConvert.DeserializeObject<List<CategoryDTO>>(Convert.ToString(responce.Result));
            }
            return View(categories);
        }

        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(CategoryCreateDTO createDTO)
        {
            var responce = await _categoryService.CreateAsync<APIResponse>(createDTO);
            if (responce != null && responce.IsSuccess)
            {
                TempData["success"] = "Villa created successfully";
                return RedirectToAction(nameof(IndexCategory));
            }
            TempData["error"] = "Error encountered.";
            return View(createDTO);
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            var response = await _categoryService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                CategoryDTO model = JsonConvert.DeserializeObject<CategoryDTO>(Convert.ToString(response.Result));
                return View(_mapper.Map<CategoryDTO>(model));
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(CategoryDTO model)
        {
            if (ModelState.IsValid)
            {
                TempData["success"] = "Category updated successfully";
                var response = await _categoryService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexCategory));
                }
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var response = await _categoryService.GetAsync<APIResponse>(id);
            if (response != null && response.IsSuccess)
            {
                CategoryDTO model = JsonConvert.DeserializeObject<CategoryDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(CategoryDTO model)
        {

            var response = await _categoryService.DeleteAsync<APIResponse>(model.Id);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Villa deleted successfully";
                return RedirectToAction(nameof(IndexCategory));
            }
            TempData["error"] = "Error encountered.";
            return View(model);
        }
    }
}
