using WebAPICHATest.Domain.AggregateModels.EquipmentAggregate;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate.MaintenanceResponse;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceWorkOrderAggregate.MaintenanceWorkOrder;
using WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MoldAggregate;
using WebAPICHATest.Domain.AggregateModels.PersonAggregate;
using System;
using WebAPICHATest.Infrastructure.Repositories;
using static WebAPICHATest.Domain.AggregateModels.MaintenanceRequestAggregate.MaintenanceRequest;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;
using static WebAPICHATest.Domain.AggregateModels.InputAggregate.Common.MaintenanceResponseGetReturn;

namespace WebAPICHATest.Api.Application.Commands.Inputs
{
    public class AddInputHandler : IRequestHandler<AddInputCommand, ListMaintenanceResponseReturn>
    {
        private readonly IObjectInputRepository _objectInputRepository;
        private readonly IMaintenanceResponseRepository _maintenanceResponseRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IMoldRepository _moldRepository;

        public AddInputHandler(IObjectInputRepository objectInputRepository, 
                               IMaintenanceResponseRepository maintenanceResponseRepository,
                               IPersonRepository personRepository,
                               IEquipmentRepository equipmentRepository,
                               IMoldRepository moldRepository)
        {
            _objectInputRepository = objectInputRepository;
            _maintenanceResponseRepository = maintenanceResponseRepository;
            _personRepository = personRepository;
            _equipmentRepository = equipmentRepository;
            _moldRepository = moldRepository;
        }

        public async Task<ListMaintenanceResponseReturn> Handle(AddInputCommand request, CancellationToken cancellationToken)
        {
            ListJobInforReturn newListJobInfor = await _objectInputRepository.Implement(request.input);
            var listEquipment = await _equipmentRepository.GetAll();
            var listMold = await _moldRepository.GetAll();
            var listPerson = await _personRepository.GetAll();
            ListMaintenanceResponseReturn listMaintenanceResponseReturn = new ListMaintenanceResponseReturn(scheduled: new List<MaintenanceResponseGetReturn>(),
                                                                                                            rejected: new List<MaintenanceResponseGetReturn>());

            listMaintenanceResponseReturn.Scheduled = ReturnListMainetanceResponse(newListJobInfor: newListJobInfor.scheduled.ToList(),
                                                                                   listEquipment: listEquipment,
                                                                                   listMold: listMold,
                                                                                   listPerson: listPerson,
                                                                                   rejected: false);

            listMaintenanceResponseReturn.Rejected = ReturnListMainetanceResponse(newListJobInfor: newListJobInfor.rejected.ToList(),
                                                                                  listEquipment: listEquipment,
                                                                                  listMold: listMold,
                                                                                  listPerson: listPerson,
                                                                                  rejected: true);
            var result = await _objectInputRepository.UpdateListMaintenanceReponseReturn(listMaintenanceResponseReturn, cancellationToken);

            Console.WriteLine(result.ToString());
            return await Task.FromResult(listMaintenanceResponseReturn);
        }
    }
}
