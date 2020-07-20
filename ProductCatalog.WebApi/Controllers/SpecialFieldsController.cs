using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.DAL.Entities;
using ProductCatalog.DAL.Models.SpecialFields;
using ProductCatalog.Services.Abstract;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductCatalog.WebApi.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialFieldsController : ControllerBase
    {
        private readonly ISpecificationFieldService _specFieldService;
        private readonly IMapper _mapper;

        public SpecialFieldsController(ISpecificationFieldService specFieldService, IMapper mapper)
        {
            _specFieldService = specFieldService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _specFieldService.SelectAsync(c => _mapper.Map<SpecFieldModel>(c), c => c.Deleted != true);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _specFieldService.SingleOrDefaultAsync(c => _mapper.Map<SpecFieldModel>(c), c => c.Id == id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddSpecFieldModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specField = _mapper.Map<SpecField>(model);

            specField = await _specFieldService.Create(specField);

            var view = _mapper.Map<SpecFieldModel>(specField);

            return Ok(view);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddSpecFieldModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specField = await _specFieldService.GetByIdAsync(id);

            if (specField == null)
            {
                return NotFound();
            }

            specField = _mapper.Map(model, specField);

            specField = await _specFieldService.Update(specField);

            var view = _mapper.Map<SpecFieldModel>(specField);

            return Ok(view);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var specField = await _specFieldService.GetByIdAsync(id);

            if (specField == null)
            {
                return NotFound();
            }

            await _specFieldService.SoftDelete(specField);

            return Ok();
        }
    }
}
