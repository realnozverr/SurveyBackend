using CSharpFunctionalExtensions;
using Domain.Exceptions.ArgumentException;

namespace Domain.Models.SurveyResultAggregate
{
    public class UserAnswer : ValueObject
    {
        private UserAnswer(){}
        private UserAnswer(int diagnosticCoefficient, Guid questionId, int answerId) : this()
        {
            DiagnosticCoefficient = diagnosticCoefficient;
            QuestionId = questionId;
            AnswerId = answerId;
        }
        public Guid QuestionId { get; }
        public int AnswerId { get; }
        public double DiagnosticCoefficient { get; }

        public static UserAnswer Create(int diagnosticCoefficient, Guid questionId, int answerId)
        {
            if (diagnosticCoefficient < -50 || diagnosticCoefficient > 50)
                throw new ValueOutOfRangeException(nameof(diagnosticCoefficient));

            return new UserAnswer(diagnosticCoefficient, questionId, answerId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return DiagnosticCoefficient;
        }
    }
}
