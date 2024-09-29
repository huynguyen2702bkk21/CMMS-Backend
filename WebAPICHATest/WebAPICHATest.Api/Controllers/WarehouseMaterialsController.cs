using WebAPICHATest.Api.Application.Queries.WarehouseMaterials;
using WebAPICHATest.Domain.AggregateModels.WarehouseMaterialAggregate;

namespace WebAPICHATest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseMaterialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseMaterialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<WarehouseMaterial>> GetWarehouseMaterials()
        {
            var command = new WarehouseMaterialsQuery();
            return await _mediator.Send(command);
        }
    }
}
