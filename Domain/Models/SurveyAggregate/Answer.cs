using CSharpFunctionalExtensions;
using Domain.Exceptions.ArgumentException;

namespace Domain.Models.SurveyAggregate
{
    public class Answer : Entity<int>
    {
        private Answer(){}
        private Answer(int id, string text, int diagnosticCoefficient) : this()
        {
            Id = id;
            Text = text;
            DiagnosticCoefficient = diagnosticCoefficient;
        }
        public string Text { get; private set; } = null!;
        public double DiagnosticCoefficient { get; private set; }

        public static Answer Create(int id, string text, int diagnosticCoefficient)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ValueIsNullException(nameof(text));
            if (diagnosticCoefficient < -50 || diagnosticCoefficient > 50)
                throw new ValueOutOfRangeException(nameof(diagnosticCoefficient));
            return new Answer(id, text, diagnosticCoefficient);
        }
    }
}
