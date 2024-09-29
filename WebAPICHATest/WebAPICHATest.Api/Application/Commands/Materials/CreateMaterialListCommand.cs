using System.Runtime.Serialization;

namespace WebAPICHATest.Api.Application.Commands.Materials
{
    [DataContract]
    public class CreateMaterialListCommand : IRequest<bool>
    {
        public CreateMaterialListCommand(CreateMaterialModel[] items)
        {
            this.items = items;
        }

        public CreateMaterialModel[] items { get; set; }

    }
}
