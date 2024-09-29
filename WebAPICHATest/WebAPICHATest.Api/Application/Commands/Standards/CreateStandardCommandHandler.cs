using WebAPICHATest.Api.Application.Commands.Standards;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Api.Application.Commands.Standards
{
    public class CreateStandardCommandHandler : IRequestHandler<CreateStandardCommand, bool>
    {
        private readonly IStandardRepository _standardRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IKitTestRepository _kitTestRepository;

        public CreateStandardCommandHandler(IStandardRepository standardRepository,
                                            IImageRepository imageRepository,
                                            IKitTestRepository kitTestRepository)
        {
            _standardRepository = standardRepository;
            _imageRepository = imageRepository;
            _kitTestRepository = kitTestRepository;
        }

        public async Task<bool> Handle(CreateStandardCommand request, CancellationToken cancellationToken)
        {
            string? listImage = null;
            if (request.Images != null)
            {
                listImage = "";
                foreach (string imageTemp in request.Images)
                {
                    listImage += imageTemp + "|";
                }
            }

            var kitTest = await _kitTestRepository.GetById(request.KitTest) ?? throw new NotFoundException();

            var standardId = Guid.NewGuid().ToString();
            var standard = new Standard(standardId: standardId, 
                                        images: listImage, 
                                        measurements: request.Measurements,
                                        kitTest: kitTest);
            _standardRepository.Add(standard);

            return await _standardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
