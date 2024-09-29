using WebAPICHATest.Api.Application.Commands.Molds;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Api.Application.Commands.Molds
{
    public class CreateMoldCommandHandler : IRequestHandler<CreateMoldCommand, bool>
    {
        private readonly IMoldRepository _moldRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IStandardRepository _standardRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public CreateMoldCommandHandler(IMoldRepository moldRepository,
                                        IEquipmentMaterialRepository equipmentMaterialRepository,
                                        IProductRepository productRepository,
                                        IImageRepository imageRepository,
                                        IStandardRepository standardRepository,
                                        IPerformanceIndexRepository performanceIndexRepository)
        {
            _moldRepository = moldRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _productRepository = productRepository;
            _imageRepository = imageRepository;
            _standardRepository = standardRepository;
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<bool> Handle(CreateMoldCommand request, CancellationToken cancellationToken)
        {
            string MTBFString = Guid.NewGuid().ToString();
            var MTBF = new PerformanceIndex(MTBFString);
            _performanceIndexRepository.Add(MTBF);

            string MTTFString = Guid.NewGuid().ToString();
            var MTTF = new PerformanceIndex(MTTFString);
            _performanceIndexRepository.Add(MTTF);

            string OEEString = Guid.NewGuid().ToString();
            var OEE = new PerformanceIndex(OEEString);
            _performanceIndexRepository.Add(OEE);

            var moldId = Guid.NewGuid().ToString();
            var mold = new Mold(moldId: moldId, 
                                code: request.Code, 
                                name: request.Name, 
                                cavity: request.Cavity, 
                                products: null, 
                                documentLink: request.DocumentLink, 
                                images: null, 
                                standards: null, 
                                mTBF: MTBF, 
                                mTTF: MTTF, 
                                oEE: OEE, 
                                usedTime: 0,
                                updatedAt: DateTime.UtcNow,
                                scheduleWorkingTimes: null, 
                                status: null,
                                materials: null);
            _moldRepository.Add(mold);
            return await _moldRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
