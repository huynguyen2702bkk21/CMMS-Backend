using RestSharp;
using System.Net;
using System.Text;
using System;
using System.Text.Json;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.WareHouseMaterialInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.WorkInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.DeviceInputAggregate;
using WebAPICHATest.Domain.AggregateModels.InputAggregate.TechnicianInputAggregate;
using System.Text.Json.Nodes;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.ObjectInputAggregate
{
    public class ObjectInput
    {
        public WorkInputs? works { get; set; }
        public DeviceInputs? devices { get; set; }
        public TechnicianInputs? technicians { get; set; }
        public WareHouseMaterialInputs? wareHouseMaterials { get; set; }
        public DateTime firstDateStart { get; set; }

        public ObjectInput()
        {

        }

        public ObjectInput(WorkInputs? works, DeviceInputs? devices, TechnicianInputs? technicians, WareHouseMaterialInputs? wareHouseMaterials, DateTime firstDateStart)
        {
            this.works = works;
            this.devices = devices;
            this.technicians = technicians;
            this.wareHouseMaterials = wareHouseMaterials;
            this.firstDateStart = firstDateStart;
        }

        public void Update(WorkInputs? works, DeviceInputs? devices, TechnicianInputs? technicians, WareHouseMaterialInputs? wareHouseMaterials, DateTime firstDateStart)
        {
            this.works = works;
            this.devices = devices;
            this.technicians = technicians;
            this.wareHouseMaterials = wareHouseMaterials;
            this.firstDateStart = firstDateStart;
        }

        public static async Task<dynamic> postMethodAsync(ObjectInput body, string URL)
        {
            var options = new RestClientOptions(URL)
            {
                ThrowOnAnyError = true,
                MaxTimeout = 600000  // 1 second
            };

            var client = new RestClient(URL);
            var request = new RestRequest();

            request.AddJsonBody(body);
            Console.WriteLine("AddJsonBody done!");
            var response = client.Post<ListJobInforReturn>(request);
            Console.WriteLine("success");

            //var client = new RestClient(URL);
            //var request = new RestRequest(Method.POST);

            //request.AddJsonBody(body);

            //IRestResponse response = client.Execute(request);
            //var data = JsonSerializer.Deserialize<ListJobInforReturn>(response.Content!)!;

            return response;
        }
    }
}
