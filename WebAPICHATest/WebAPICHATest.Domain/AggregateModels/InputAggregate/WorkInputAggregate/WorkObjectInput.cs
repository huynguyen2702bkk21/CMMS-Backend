using WebAPICHATest.Domain.AggregateModels.InputAggregate.WareHouseMaterialInputAggregate;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.WorkInputAggregate
{
    public class WorkObjectInput
    {
        public string id { get; set; }
        public string priority { get; set; }
        public string deviceCode { get; set; }
        public string problem { get; set; }
        public DateTime dueDate { get; set; }
        public string estProcessTime { get; set; }
        public WorkGroup workGroup { get; set; }
        public MaterialOnWork[]? materials { get; set; }
        //public Tool[]? tools { get; set; }

        public WorkObjectInput()
        {

        }

        public WorkObjectInput(string id, string priority, string deviceCode, string problem, DateTime dueDate, string estProcessTime, WorkGroup workGroup, MaterialOnWork[]? materials)
        {
            this.id = id;
            this.priority = priority;
            this.deviceCode = deviceCode;
            this.problem = problem;
            this.dueDate = dueDate;
            this.estProcessTime = estProcessTime;
            this.workGroup = workGroup;
            this.materials = materials;
        }
    }

    public class WorkGroup
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public double minimumSkillLevel { get; set; }
        public string specializedGroup { get; set; }
    }

    public class Tool
    {
        public Tool(ToolInfo toolInfo, int quantity)
        {
            this.toolInfo = toolInfo;
            this.quantity = quantity;
        }

        public ToolInfo toolInfo { get; set; }
        public int quantity { get; set; }
    }

    public class ToolInfo
    {
        public string code { get; set; }
        public string name { get; set; }

        public ToolInfo(string code, string name)
        {
            this.code = code;
            this.name = name;
        }
    }
}
