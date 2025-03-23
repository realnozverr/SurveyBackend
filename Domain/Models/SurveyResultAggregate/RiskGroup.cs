using CSharpFunctionalExtensions;
using Domain.Exceptions.ArgumentException;


namespace Domain.Models.SurveyResultAggregate
{
    public class RiskGroup : Entity<int>
    {
        public static readonly RiskGroup VeryLow = new(1, nameof(VeryLow).ToLowerInvariant());
        public static readonly RiskGroup Medium = new(2, nameof(Medium).ToLowerInvariant());
        public static readonly RiskGroup VeryHigh = new(3, nameof(VeryHigh).ToLowerInvariant());
        private RiskGroup(){}

        private RiskGroup(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValueIsNullException($"{nameof(name)} cannot be empty");
            Id = id;
            Name = name;
        }
        public string Name { get; } = null!;

        public static IEnumerable<RiskGroup> GetAll()
        {
            return
        [
            VeryLow,
            Medium,
            VeryHigh
        ];

        }
    }
}
