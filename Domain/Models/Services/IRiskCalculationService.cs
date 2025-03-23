using Domain.Models.SurveyResultAggregate;
using FluentResults;

namespace Domain.Models.Services
{
    public interface IRiskCalculationService
    {
        Result<RiskGroup> CalculateRisk(double score);
        Result<double> CalculateScore(IEnumerable<UserAnswer> answers);
    }
}
