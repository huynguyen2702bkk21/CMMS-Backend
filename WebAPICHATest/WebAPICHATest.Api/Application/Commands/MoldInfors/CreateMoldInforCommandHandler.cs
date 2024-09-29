using WebAPICHATest.Api.Application.Commands.MoldInfors;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldInforAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Api.Application.Commands.MoldInfors
{
    public class CreateMoldInforCommandHandler : IRequestHandler<CreateMoldInforCommand, bool>
    {
        private readonly IMoldInforRepository _moldInforRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStandardRepository _standardRepository;
        private readonly IImageRepository _imageRepository;

        public CreateMoldInforCommandHandler(IMoldInforRepository moldInforRepository,
                                             IProductRepository productRepository,
                                             IStandardRepository standardRepository,
                                             IImageRepository imageRepository)
        {
            _moldInforRepository = moldInforRepository;
            _productRepository= productRepository;
            _standardRepository= standardRepository;
            _imageRepository= imageRepository;
        }

        public async Task<bool> Handle(CreateMoldInforCommand request, CancellationToken cancellationToken)
        {
            var standard = await _standardRepository.GetById(request.Standard) ?? throw new NotFoundException();
            var listProduct = new List<Product>();
            foreach(string product in request.Products)
            {
                var temp = await _productRepository.GetById(product) ?? throw new NotFoundException();
                listProduct.Add(temp);
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
            var moldInforId = Guid.NewGuid().ToString();

            var moldInfor = new MoldInfor(moldInforId: moldInforId, 
                                          cavity: request.Cavity, 
                                          documentLink: request.DocumentLink, 
                                          images: listImage);

            _moldInforRepository.Add(moldInfor);

            return await _moldInforRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
