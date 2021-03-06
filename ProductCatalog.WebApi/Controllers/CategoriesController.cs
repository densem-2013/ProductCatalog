﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Models.Categories;
using ProductCatalog.Services.Abstract;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCatalog.WebApi.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _categoryService.SelectAsync(c => _mapper.Map<CategoryModel>(c), c => c.Deleted != true, include: f => f.Include(s => s.SpecFields));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _categoryService.SingleOrDefaultAsync(c => _mapper.Map<CategoryModel>(c), c => c.Id == id, f => f.Include(s => s.SpecFields));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = _mapper.Map<Category>(model);

            category = await _categoryService.Create(category);

            var view = _mapper.Map<CategoryModel>(category);

            return Ok(view);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            category = _mapper.Map(model, category);

            category = await _categoryService.Update(category);

            var view = _mapper.Map<CategoryModel>(category);

            return Ok(view);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.SoftDelete(category);

            return Ok();
        }
    }
}
