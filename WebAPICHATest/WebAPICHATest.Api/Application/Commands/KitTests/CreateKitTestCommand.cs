using static WebAPICHATest.Domain.AggregateModels.KitTestAggregate.KitTest;
using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.KitTests
{
    [DataContract]
    public class CreateKitTestCommand : IRequest<bool>
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public CreateKitTestCommand(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
