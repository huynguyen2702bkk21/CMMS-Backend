namespace WebAPICHATest.Api.Application.Exceptions;

public class EntityNotFoundException: Exception
{
    public string EntityType { get; set; }
    public string EntityId { get; set; }

    public EntityNotFoundException(string entityType, string entityId) : base("The entity cannot be found.")
    {
        EntityType = entityType;
        EntityId = entityId;
    }
}
