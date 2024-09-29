using Newtonsoft.Json;
using System.Data;
using System.Threading;
using WebAPICHATest.Domain.AggregateModels.InputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.DeviceInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.TechnicianInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.WareHouseMaterialInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.WorkInputAggregate;
using WebAPICHATest.Domain.AggregateModels.MaintenanceResponseAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;
using WebAPICHATest.Domain.AggregateModels.MaterialRequestAggregate;
using WebAPICHATest.Domain.AggregateModels.NotificationAggregate;
using WebAPICHATest.Infrastructure;
using WebAPICHATest.Infrastructure.Repositories;

namespace WebAPICHATest.Repository
{
    public class ObjectInputRepository : IObjectInputRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMaterialRepository _materialRepository;
        private readonly IMaterialRequestRepository _materialRequestRepository;
        private readonly IInputTabuSearchRepository _inputTabuSearchRepository;
        public static ListMaintenanceResponseReturn? ListMaintenanceResponsesReturn { get; set; }

        public ObjectInputRepository(ApplicationDbContext context, IMaterialRepository materialRepository, IInputTabuSearchRepository inputTabuSearchRepository, IMaterialRequestRepository materialRequestRepository)
        {
            _context = context;
            _materialRepository = materialRepository;
            _inputTabuSearchRepository = inputTabuSearchRepository;
            _materialRequestRepository = materialRequestRepository;
        }

        public async Task<ListJobInforReturn> Implement(ObjectPostInput input)
        {
            WareHouseMaterialInputs? wareHouseMaterialInputs = new WareHouseMaterialInputs();
            var materials = await _context.Materials.Include(x => x.MaterialInfor).AsNoTracking().ToListAsync();
            var materialRequests = await _context.MaterialRequests.Include(x => x.MaterialInfor).AsNoTracking().ToListAsync();

            var mondayOfThisWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
            var saturdayOfThisWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Saturday);

            List<WareHouseMaterialObjectInput> wareHouseMaterialObjectInputs = new List<WareHouseMaterialObjectInput>();
            if (materials != null)
            {
                foreach (Material material in materials)
                {
                    WareHouseMaterialObjectInput wareHouseMaterialObject = new WareHouseMaterialObjectInput();
                    wareHouseMaterialObject.id = material.MaterialId;
                    Materialinfo materialinfo = new Materialinfo();
                    materialinfo.code = material.MaterialInfor.Code;
                    materialinfo.name = material.MaterialInfor.Name;
                    materialinfo.unit = material.MaterialInfor.Unit;
                    materialinfo.minimumQuantity = (int)material.MaterialInfor.MinimumQuantity;
                    materialinfo.expectedDate = "";
                    Console.WriteLine($"The material infor code: {material.MaterialInfor.Code}");
                    var listMaterialRequest = await _materialRequestRepository.GetByMaterialInforCode(material.MaterialInfor.Code);
                    Console.WriteLine($"The length of material request: {listMaterialRequest.Count}");
                    if (listMaterialRequest != null)
                    {
                        int numberOfRequest = listMaterialRequest.Count;
                        if (numberOfRequest > 1)
                        {
                            materialinfo.expectedDate = listMaterialRequest[numberOfRequest - 1].ExpectedDate.ToString("dd/MM/yyyy HH:mm");
                            Console.WriteLine($"The expected date of code {material.MaterialInfor.Code}: {materialinfo.expectedDate}");
                        }
                    }

                    wareHouseMaterialObject.materialInfo = materialinfo;
                    wareHouseMaterialObjectInputs.Add(wareHouseMaterialObject);
                }
            }

            wareHouseMaterialInputs.JsonInput = wareHouseMaterialObjectInputs.ToArray();
            ObjectInput objectInput = new ObjectInput();
            objectInput.Update(works: input.works,
                               devices: input.devices,
                               technicians: input.technicians,
                               wareHouseMaterials: wareHouseMaterialInputs,
                               firstDateStart: input.firstDateStart);

            ListJobInforReturn listJobInforReturn = await ObjectInput.postMethodAsync(objectInput, "https://webapichaalgorithmservice.azurewebsites.net/api/Inputs");
            //ListJobInforReturn listJobInforReturn = await ObjectInput.postMethodAsync(objectInput, "https://localhost:7048/api/Inputs");
            Console.WriteLine("Post successful");
            return listJobInforReturn;
        }

        public async Task<string> UpdateListMaintenanceReponseReturn(ListMaintenanceResponseReturn listMaintenanceResponsesReturn, CancellationToken cancellationToken)
        {
            ListMaintenanceResponsesReturn = listMaintenanceResponsesReturn;
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ListMaintenanceResponsesReturn);
            //string filePath = "./JsonStringTabuSearchResult.txt";

            //// Write the string to a file.
            //System.IO.StreamWriter file = new System.IO.StreamWriter(filePath);
            //file.WriteLine(jsonString);
            //file.Close();

            string inputTabuSearchId = "26bc2a39-ada2-4f3a-b403-daf3acd0a223";
            var inputTabuSearch = await _inputTabuSearchRepository.GetById(inputTabuSearchId);
            inputTabuSearch.Update(jsonString);
            _inputTabuSearchRepository.Update(inputTabuSearch);
            await _inputTabuSearchRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            Console.WriteLine($"UpdateListMaintenanceReponseReturn: {ListMaintenanceResponsesReturn.Scheduled.Count} - {ListMaintenanceResponsesReturn.Rejected.Count}");

            return "Store success"; 
        }

        public async Task<ListMaintenanceResponseReturn>? GetListMaintenanceResponseReturn()
        {
            ListMaintenanceResponseReturn? listMaintenanceResponsesReturn = new ListMaintenanceResponseReturn(scheduled: new List<MaintenanceResponseGetReturn>(),
                                                                                                              rejected: new List<MaintenanceResponseGetReturn>());

            string inputTabuSearchId = "26bc2a39-ada2-4f3a-b403-daf3acd0a223";
            InputTabuSearch? inputTabuSearch = await _inputTabuSearchRepository.GetById(inputTabuSearchId);
            string? jsonString = inputTabuSearch.JsonString;
            listMaintenanceResponsesReturn = JsonConvert.DeserializeObject<ListMaintenanceResponseReturn>(jsonString);

            //string filePath = "./JsonStringTabuSearchResult.txt";
            //using (StreamReader r = new StreamReader(filePath))
            //{
            //    string json = r.ReadToEnd();
            //    listMaintenanceResponsesReturn = JsonConvert.DeserializeObject<ListMaintenanceResponseReturn>(json);
            //}

            Console.WriteLine($"GetListMaintenanceResponseReturn: {listMaintenanceResponsesReturn.Scheduled.Count} - {listMaintenanceResponsesReturn.Rejected.Count}");
            if (listMaintenanceResponsesReturn != null)
            {
                Console.WriteLine("ListMaintenanceResponsesReturn is not null");
                return listMaintenanceResponsesReturn;
            }

            return null;
        }
    }
}
