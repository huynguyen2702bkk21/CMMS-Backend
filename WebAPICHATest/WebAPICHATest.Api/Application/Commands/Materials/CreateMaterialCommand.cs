using System.Runtime.Serialization;
using static WebAPICHATest.Domain.AggregateModels.MaterialAggregate.Material;
using WebAPICHATest.Domain.AggregateModels.MaterialInforAggregate;

namespace WebAPICHATest.Api.Application.Commands.Materials
{
    [DataContract]
    public class CreateMaterialCommand : IRequest<bool>
    {
        public string Sku { get; set; }
        public string? MaterialInfor { get; set; }

        public CreateMaterialCommand(string sku, string? materialInfor)
        {
            Sku = sku;
            MaterialInfor = materialInfor;
        }
    }
}
