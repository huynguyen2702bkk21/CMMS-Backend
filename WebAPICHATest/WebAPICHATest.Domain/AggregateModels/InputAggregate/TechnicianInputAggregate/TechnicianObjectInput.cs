using WebAPICHATest.Domain.AggregateModels.InputAggregate.Common;

namespace WebAPICHATest.Domain.AggregateModels.InputAggregate.TechnicianInputAggregate
{
    public class TechnicianObjectInput
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public WorkingTime[][]? workingTimes { get; set; }
        public double minimumSkillLevel { get; set; }
        public string specializedGroup { get; set; }
        public TechnicianObjectInput() { }

        public TechnicianObjectInput(string? id, string? name, WorkingTime[][]? workingTimes, double minimumSkillLevel, string specializedGroup)
        {
            this.id = id;
            this.name = name;
            this.workingTimes = workingTimes;
            this.minimumSkillLevel = minimumSkillLevel;
            this.specializedGroup = specializedGroup;
        }
    }

    public enum ESpecializedGroup
    {
        mechanics,
        electrics,
        multi
    }
}
