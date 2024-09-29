//using WebAPICHATest.Api.Application.Commands.ChartObjs;
//using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;

//namespace WebAPICHATest.Api.Application.Commands.ChartObjs
//{
//    public class CreateChartObjCommandHandler : IRequestHandler<CreateChartObjCommand, bool>
//    {
//        private readonly IChartObjRepository _chartObjRepository;

//        public CreateChartObjCommandHandler(IChartObjRepository chartObjRepository)
//        {
//            _chartObjRepository = chartObjRepository;
//        }

//        public async Task<bool> Handle(CreateChartObjCommand request, CancellationToken cancellationToken)
//        {
//            //var chartObj = await _chartObjRepository.GetAsync(request.ChartObj) ?? throw new NotFoundException();
//            //var person = await _personRepository.GetAsync(request.Requestor) ?? throw new NotFoundException();

//            var chartObj = new ChartObj(request.ChartObjId, request.Name, request.Value);

//            _chartObjRepository.Add(chartObj);

//            return await _chartObjRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
//        }
//    }
//}
