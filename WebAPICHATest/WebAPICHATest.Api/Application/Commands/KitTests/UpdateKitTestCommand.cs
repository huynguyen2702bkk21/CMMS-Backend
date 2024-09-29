using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.KitTests
{
    [DataContract]
    public class UpdateKitTestCommand : IRequest<bool>
    {
        public string? KitTestId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public UpdateKitTestCommand(string? kitTestId, string code, string name)
        {
            KitTestId = kitTestId;
            Code = code;
            Name = name;
        }
    }
}
