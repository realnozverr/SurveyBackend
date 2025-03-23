using Domain.Exceptions.ArgumentException;
using Domain.Models.SurveyResultAggregate;
using FluentResults;

namespace Domain.Models.Services
{
    public class RiskCalculationService : IRiskCalculationService
    {
        public Result<RiskGroup> CalculateRisk(double score)
        {
            return score switch
            {
                < -13.0 => RiskGroup.VeryLow,
                >= -13.0 and <= 13.0 => RiskGroup.Medium,
                > 13.0 => RiskGroup.VeryHigh,
                _ => throw new ValueIsInvalidException("Invalid risk group calculation")
            };
        }
        public Result<double> CalculateScore(IEnumerable<UserAnswer> answers)
        {
            double total = answers.Sum(a => a.DiagnosticCoefficient);
            return Result.Ok(total);
        }
    }
}
