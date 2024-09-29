using WebAPICHATest.Api.Application.Commands.Images;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;

namespace WebAPICHATest.Api.Application.Commands.Images
{
    public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, bool>
    {
        private readonly IImageRepository _imageRepository;

        public UpdateImageCommandHandler(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<bool> Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _imageRepository.GetById(request.ImageId) ?? throw new NotFoundException();
            image.Update(request.Value);
            _imageRepository.Update(image);

            return await _imageRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
