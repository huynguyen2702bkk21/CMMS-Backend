using static WebAPICHATest.Domain.AggregateModels.MoldAggregate.Mold;
using System.Runtime.Serialization;
using static WebAPICHATest.Domain.AggregateModels.EquipmentAggregate.Equipment;
using WebAPICHATest.Domain.AggregateModels.EquipmentMaterialAggregate;
using WebAPICHATest.Domain.AggregateModels.ProductAggregate;
using WebAPICHATest.Domain.AggregateModels.StandardAggregate;

namespace WebAPICHATest.Api.Application.Commands.Molds
{
    [DataContract]
    public class CreateMoldCommand : IRequest<bool>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int? Cavity { get; set; }
        public string? DocumentLink { get; set; }

        public CreateMoldCommand(string? code, string? name, int? cavity, string? documentLink)
        {
            Code = code;
            Name = name;
            Cavity = cavity;
            DocumentLink = documentLink;
        }
    }
}
