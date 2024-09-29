using WebAPICHATest.Api.Application.Commands.MaintenanceRequests;
using WebAPICHATest.Api.Application.Exceptions;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.ChartObjAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.PerformanceIndexAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.TimeSeriesObjectAggregate;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;

namespace WebAPICHATest.Api.Application.Commands.Equipments
{
    public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, bool>
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IEquipmentMaterialRepository _equipmentMaterialRepository;
        private readonly IPerformanceIndexRepository _performanceIndexRepository;

        public CreateEquipmentCommandHandler(IEquipmentRepository equipmentRepository,
                                             IEquipmentMaterialRepository equipmentMaterialRepository,
                                             IPerformanceIndexRepository performanceIndexRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentMaterialRepository = equipmentMaterialRepository;
            _performanceIndexRepository = performanceIndexRepository;
        }

        public async Task<bool> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
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

            EEquipmentType type;
            Enum.TryParse<EEquipmentType>(request.Type, out type);

            var equipmentId = Guid.NewGuid().ToString();
            var equipment = new Equipment(equipmentId: equipmentId, 
                                          code: request.Code, 
                                          name: request.Name, 
                                          scheduleWorkingTimes: null, 
                                          type: type,
                                          mTBF: MTBF, 
                                          mTTF: MTTF, 
                                          oEE: OEE,
                                          updatedAt: DateTime.UtcNow,
                                          status: null, 
                                          material: null);
            _equipmentRepository.Add(equipment);

            //Console.WriteLine(equipment.Materials.Count.ToString());

            return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
