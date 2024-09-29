using System.Runtime.Serialization;
using static WebAPICHATest.Domain.AggregateModels.MaterialAggregate.Material;

namespace WebAPICHATest.Api.Application.Commands.Materials
{
    [DataContract]
    public class UpdateMaterialCommand : IRequest<bool>
    {
        public string? MaterialId { get; set; }
        public string? MaterialInfor { get; set; }
        public string Status { get; set; } //Enum

        public UpdateMaterialCommand(string materialId, string materialInfor, string status)
        {
            MaterialId = materialId;
            MaterialInfor = materialInfor;
            Status = status;
        }
    }
}
