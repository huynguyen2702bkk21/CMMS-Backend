//using WebAPICHATest.Api.Application.Queries.MaintenanceRequests;
//using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
//using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
//using WebAPICHATest.Infrastructure;

//namespace WebAPICHATest.Api.Application.Queries.ChartObjs
//{
//    public class ChartObjsQueryHandler : IRequestHandler<ChartObjsQuery, List<ChartObjViewModel>>
//    {
//        private readonly ApplicationDbContext _context;
//        private readonly IMapper _mapper;

//        public ChartObjsQueryHandler(ApplicationDbContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        public async Task<List<ChartObjViewModel>> Handle(ChartObjsQuery request, CancellationToken cancellationToken)
//        {
//            var result = await _context.ChartObjs.AsNoTracking().ToListAsync();

//            return _mapper.Map<List<ChartObj>, List<ChartObjViewModel>>(result);
//        }
//    }
//}
