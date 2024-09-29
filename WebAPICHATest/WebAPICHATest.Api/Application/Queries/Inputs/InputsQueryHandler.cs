using WebAPICHATest.Api.Application.Queries.Inputs;
using WebAPICHATest.Domain.AggregateModels.InputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Infrastructure;

namespace WebAPICHATest.Api.Application.Queries.Inputs
{
    public class InputsQueryHandler : IRequestHandler<InputsQuery, ListMaintenanceResponseReturn>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IObjectInputRepository _objectInputRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;

        public InputsQueryHandler(ApplicationDbContext context, IMapper mapper,
                                  IObjectInputRepository objectInputRepository,
                                  IMaintenanceResponseRepository maintenanceResponseRepository)
        {
            _context = context;
            _mapper = mapper;
            _objectInputRepository = objectInputRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
        }

        public async Task<ListMaintenanceResponseReturn> Handle(InputsQuery request, CancellationToken cancellationToken)
        {
            ListMaintenanceResponseReturn listMaintenanceResponseReturn = new ListMaintenanceResponseReturn(scheduled: new List<MaintenanceResponseGetReturn>(),
                                                                                                            rejected: new List<MaintenanceResponseGetReturn>());
            List<MaintenanceResponse> listMaintenanceResponse = await _maintenanceResponseRepository.GetAll();
            ListMaintenanceResponseReturn? listMaintenanceResponseFromTabuSearch = await _objectInputRepository.GetListMaintenanceResponseReturn();

            Console.WriteLine($"InputsQueryHandler: {listMaintenanceResponseFromTabuSearch.Scheduled.Count} - {listMaintenanceResponseFromTabuSearch.Rejected.Count}");
            if (listMaintenanceResponseFromTabuSearch != null)
            {
                int i = 0;
                if (listMaintenanceResponseFromTabuSearch.Scheduled != null)
                {
                    foreach (MaintenanceResponseGetReturn maintenanceResponse in listMaintenanceResponseFromTabuSearch.Scheduled)
                    {
                        var code = $"MRES-23{(listMaintenanceResponse.Count + 1 + i).ToString().PadLeft(4, '0')}";
                        maintenanceResponse.Code = code;
                        listMaintenanceResponseReturn.Scheduled.Add(maintenanceResponse);
                        i++;
                    }
                }

                if (listMaintenanceResponseFromTabuSearch.Rejected != null)
                {
                    foreach (MaintenanceResponseGetReturn maintenanceResponse in listMaintenanceResponseFromTabuSearch.Rejected)
                    {
                        var code = $"MRES-23{(listMaintenanceResponse.Count + 1 + i).ToString().PadLeft(4, '0')}";
                        maintenanceResponse.Code = code;
                        listMaintenanceResponseReturn.Rejected.Add(maintenanceResponse);
                        i++;
                    }
                }
            }

            return await Task.FromResult(listMaintenanceResponseReturn);
        }
    }
}
