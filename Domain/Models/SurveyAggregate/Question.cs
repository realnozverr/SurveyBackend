using CSharpFunctionalExtensions;
using Domain.Exceptions.ArgumentException;

namespace Domain.Models.SurveyAggregate
{
    public class Question : Entity<Guid>
    {
        private Question(){}
        private Question(string text, List<Answer> answers) : this()
        {
            Id = Guid.NewGuid();
            Text = text;
            _answers = answers;
        }

        private readonly List<Answer> _answers = [];
        public IReadOnlyList<Answer> Answers => _answers.AsReadOnly();
        public string Text { get; private set; } = null!;
        public bool AllowMultipleAnswers { get; private set; } = false;

        public static Question Create(int id, string text, List<Answer> answers)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ValueIsNullException(nameof(text));
            if (answers == null || answers.Count == 0)
                throw new ValueIsRequiredException(nameof(answers));
            return new Question(text, answers);
        }


        public void SetText(string newText)
        {
            if (string.IsNullOrWhiteSpace(newText))
                throw new ValueIsNullException(nameof(newText));

            Text = newText.Trim();
        }

        public void AddAnswer(Answer answer)
        {
            if (answer == null)
                throw new ArgumentNullException(nameof(answer));
            if (_answers.Any(a => a.Text.Equals(answer.Text, StringComparison.OrdinalIgnoreCase)))
                throw new ValueDuplicateException(nameof(answer));

            _answers.Add(answer);
        }

        public void EnableMultipleAnswers()
        {
            if (_answers.Count < 2)
                throw new ValueOutOfRangeException(nameof(_answers));

            AllowMultipleAnswers = true;
        }
    }
}
