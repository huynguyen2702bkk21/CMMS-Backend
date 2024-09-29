using WebAPICHATest.Api.Application.Commands.Molds;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using static WebAPICHATest.Domain.AggregateModels.MoldAggregate.Mold;

namespace WebAPICHATest.Api.Application.Commands.Molds
{
    public class UpdateMoldCommandHandler : IRequestHandler<UpdateMoldCommand, bool>
    {
        private readonly IMoldRepository _moldRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IProductRepository _productRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IStandardRepository _standardRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public UpdateMoldCommandHandler(IMoldRepository moldRepository,
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

        public async Task<bool> Handle(UpdateMoldCommand request, CancellationToken cancellationToken)
        {
            var mold = await _moldRepository.GetById(request.MoldId) ?? throw new NotFoundException();

            List<Product>? listProduct = null;
            if (request.Products != null)
            {
                listProduct = new List<Product>();
                foreach (string productTemp in request.Products)
                {
                    var product = await _productRepository.GetById(productTemp) ?? throw new NotFoundException();
                    listProduct.Add(product);
                }
            }

            string? listImage = null;
            if (request.Images != null)
            {
                listImage = "";
                foreach (string imageTemp in request.Images)
                {
                    listImage += imageTemp + "|";
                }
            }

            List<Standard>? listStandard = null;
            if (request.Standards != null)
            {
                listStandard = new List<Standard>();
                foreach (string standardTemp in request.Standards)
                {
                    var standard = await _standardRepository.GetById(standardTemp) ?? throw new NotFoundException();
                    listStandard.Add(standard);
                }
            }

            List<EquipmentMaterial>? listEquipmentMaterial = null;
            if (request.Materials != null)
            {
                listEquipmentMaterial = new List<EquipmentMaterial>();
                foreach (string equipmentMaterialTemp in request.Materials)
                {
                    var equipmentMaterial = await _equipmentMaterialRepository.GetById(equipmentMaterialTemp) ?? throw new NotFoundException();
                    listEquipmentMaterial.Add(equipmentMaterial);
                }
            }

            EMaintenanceObjectStatus status;
            Enum.TryParse<EMaintenanceObjectStatus>(request.Status, out status);

            mold.Update(code: request.Code,
                        name: request.Name,
                        cavity: request.Cavity,
                        products: listProduct,
                        documentLink: request.DocumentLink,
                        images: listImage,
                        standards: listStandard,
                        updatedAt: DateTime.UtcNow,
                        status: status,
                        materials: listEquipmentMaterial);
            _moldRepository.Update(mold);

            return await _moldRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
