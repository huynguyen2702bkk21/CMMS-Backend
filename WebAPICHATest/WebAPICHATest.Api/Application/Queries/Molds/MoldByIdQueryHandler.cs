using WebAPICHATest.Api.Application.Queries.Molds;
using WebAPICHATest.Domain.AggregateModels.CauseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.JsonEquipmentAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using WebAPICHATest.Infrastructure;
using static WebAPICHATest.Domain.AggregateModels.MoldAggregate.Mold;

namespace WebAPICHATest.Api.Application.Queries.Molds
{
    public class MoldByIdQueryHandler : IRequestHandler<MoldByIdQuery, QueryResult<MoldViewModel>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IStandardRepository _standardRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly ICauseRepository _causeRepository;

        public MoldByIdQueryHandler(ApplicationDbContext context, IMapper mapper,
                                    IEquipmentMaterialRepository equipmentMaterialRepository,
                                    IProductRepository productRepository,
                                    IImageRepository imageRepository,
                                    IStandardRepository standardRepository,
                                    IMaintenanceResponseRepository maintenanceResponseRepository,
                                    ICauseRepository causeRepository)
        {
            _context = context;
            _mapper = mapper;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _standardRepository = standardRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _causeRepository = causeRepository;
        }

        public async Task<QueryResult<MoldViewModel>> Handle(MoldByIdQuery request, CancellationToken cancellationToken)
        {
            var queryable = _context.Molds
                .Include(x => x.Products)
                .Include(x => x.Standards)
                .ThenInclude(x => x.KitTest)
                .Include(x => x.Materials)
                .ThenInclude(x => x.MaterialInfor)
                .AsNoTracking();


            if (request.MoldId is not null)
            {
                queryable = queryable.Where(x => x.MoldId == request.MoldId);
            }

            int totalItems = await queryable.CountAsync();

            queryable = queryable
                .OrderBy(x => x.MoldId)
                .Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize);

            var requests = await queryable.ToListAsync();

            var listMoldGet = new List<MoldGetModel>();
            foreach (var mold in requests)
            {
                var moldGet = new MoldGetModel(mold.MoldId);
                moldGet.Code = mold.Code;
                moldGet.Name = mold.Name;
                moldGet.Cavity = mold.Cavity;
                moldGet.Products = mold.Products;
                moldGet.DocumentLink = mold.DocumentLink;
                List<string>? listImageString = null;
                if (string.IsNullOrEmpty(mold.Images) == false)
                {
                    listImageString = mold.Images.Split("|").ToList();
                    listImageString.RemoveAt(listImageString.Count - 1);
                }
                moldGet.Images = listImageString;
                moldGet.Standards = mold.Standards;
                moldGet.MTBF = mold.MTBF;
                moldGet.MTTF = mold.MTTF;
                moldGet.OEE = mold.OEE;

                moldGet.ScheduleWorkingTimes = null;
                if (mold.ScheduleWorkingTimes != null)
                {
                    moldGet.ScheduleWorkingTimes = JsonEquipmentInput.ConvertStringToObject(mold.ScheduleWorkingTimes);
                }

                if (mold.Status != null)
                {
                    moldGet.Status = Enum.GetName(typeof(EMaintenanceObjectStatus), mold.Status);

                }

                var listMaintenanceResponse = await _maintenanceResponseRepository.GetListByMoldId(mold.MoldId);

                moldGet.RecentMaintenanceResponses = listMaintenanceResponse;
                moldGet.Errors = _maintenanceResponseRepository.ConvertFromCauseToChartObj(listMaintenanceResponse);

                moldGet.Materials = mold.Materials;
                listMoldGet.Add(moldGet);
            }
            var queryResult = new QueryResult<MoldGetModel>(listMoldGet, totalItems);

            return _mapper.Map<QueryResult<MoldGetModel>, QueryResult<MoldViewModel>>(queryResult);
        }
    }
}
