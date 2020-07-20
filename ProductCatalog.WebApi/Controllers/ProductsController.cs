using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Models.Products;
using ProductCatalog.DAL.Models.ProductSpecFields;
using ProductCatalog.Services.Abstract;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCatalog.WebApi.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productyService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productyService, IMapper mapper)
        {
            _productyService = productyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _productyService.SelectAsync(c => _mapper.Map<ProductModel>(c), c => c.Deleted != true, include: f => f.Include(s => s.SpecificationData).ThenInclude(d => d.SpecField));

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _productyService.SingleOrDefaultAsync(c => _mapper.Map<ProductModel>(c), c => c.Id == id, f => f.Include(s => s.SpecificationData).ThenInclude(d => d.SpecField));

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UpdateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<Product>(model);

            product = await _productyService.Create(product);

            var view = _mapper.Map<ProductModel>(product);

            return Ok(view);
        }

        [HttpPost("specfield")]
        public async Task<IActionResult> PostSpecField([FromBody] AddSpecFieldToProductModel model, [FromServices] IProductSpecialFieldService productSpecialFieldService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productSpField = _mapper.Map<ProductSpecField>(model);

            productSpField = await productSpecialFieldService.Create(productSpField);

            var view = await productSpecialFieldService.SingleOrDefaultAsync(sp => _mapper.Map<ProductSpecFieldModel>(sp), sp => sp.Id == productSpField.Id, sp => sp.Include(d => d.SpecField));

            return Ok(view);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productyService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            product = _mapper.Map(model, product);

            product = await _productyService.Update(product);

            var view = _mapper.Map<ProductModel>(product);

            return Ok(view);
        }

        [HttpPut("specfield")]
        public async Task<IActionResult> PutSpecField([FromBody] UpdateProductSpecFieldModel model, [FromServices] IProductSpecialFieldService productSpecialFieldService)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productSField = await productSpecialFieldService.GetByIdAsync(model.Id);

            if (productSField == null)
            {
                return NotFound();
            }

            productSField.Value = model.Value;

            productSField = await productSpecialFieldService.Update(productSField);

            var view = await productSpecialFieldService.SingleOrDefaultAsync(sp => _mapper.Map<ProductSpecFieldModel>(sp), sp => sp.Id == productSField.Id, sp => sp.Include(d => d.SpecField));

            return Ok(view);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productyService.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productyService.SoftDelete(product);

            return Ok();
        }

        [HttpDelete("specfield/{id}")]
        public async Task<IActionResult> DeleteSpecField(int id, [FromServices] IProductSpecialFieldService productSpecialFieldService)
        {
            var productSField = await productSpecialFieldService.GetByIdAsync(id);

            if (productSField == null)
            {
                return NotFound();
            }

            await productSpecialFieldService.Delete(id);

            return Ok();
        }
    }
}
