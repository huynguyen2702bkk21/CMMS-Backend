using WebAPICHATest.Api.Application.Commands.Images;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;

namespace WebAPICHATest.Api.Application.Commands.Images
{
    public class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, bool>
    {
        private readonly IImageRepository _imageRepository;

        public CreateImageCommandHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<bool> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var image = new Image(request.ImageId, request.Value);
            _imageRepository.Add(image);

            return await _imageRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
