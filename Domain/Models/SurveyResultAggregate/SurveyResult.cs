using Domain.SharedKernel;

namespace Domain.Models.SurveyResultAggregate
{
    public class SurveyResult : Aggregate<Guid>
    {
        private SurveyResult(){}
        private SurveyResult(
            Guid userId,
            Guid surveyId,
            List<UserAnswer> answers,
            double totalScore
            ) : this()
        {
            Id = Guid.NewGuid();
            UserId = userId;
            SurveyId = surveyId;
            Answers = answers.AsReadOnly();
            TotalScore = totalScore;
        }
        public Guid UserId { get; } 
        public Guid SurveyId { get; } 
        public IReadOnlyList<UserAnswer> Answers { get; }
        public double TotalScore { get; private set; } = 0;
        public RiskGroup RiskGroup { get; private set; }

        public static SurveyResult Create
            (
            Guid userId,
            Guid surveyId,
            List<UserAnswer> answers,
            double totalScore
            )
        {
            return new SurveyResult(userId, surveyId, answers, totalScore);
        }
    }

}
