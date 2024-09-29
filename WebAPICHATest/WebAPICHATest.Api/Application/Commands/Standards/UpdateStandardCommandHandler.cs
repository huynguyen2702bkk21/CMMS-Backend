using WebAPICHATest.Api.Application.Commands.Standards;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.ImageAggregate;
using WebAPICHATest.Domain.AggregateModels.KitTestAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Api.Application.Commands.Standards
{
    public class UpdateStandardCommandHandler : IRequestHandler<UpdateStandardCommand, bool>
    {
        private readonly IStandardRepository _standardRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IKitTestRepository _kitTestRepository;

        public UpdateStandardCommandHandler(IStandardRepository standardRepository,
                                            IImageRepository imageRepository,
                                            IKitTestRepository kitTestRepository)
        {
            _standardRepository = standardRepository;
            _imageRepository = imageRepository;
            _kitTestRepository = kitTestRepository;
        }

        public async Task<bool> Handle(UpdateStandardCommand request, CancellationToken cancellationToken)
        {
            var standard = await _standardRepository.GetById(request.StandardId) ?? throw new NotFoundException();
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

            standard.Update(images: listImage, 
                            measurements: request.Measurements,
                            kitTest: kitTest);
            _standardRepository.Update(standard);

            return await _standardRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
