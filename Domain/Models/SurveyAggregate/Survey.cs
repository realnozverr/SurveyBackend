using Domain.Exceptions.ArgumentException;
using Domain.SharedKernel;

namespace Domain.Models.SurveyAggregate
{
    public class Survey : Aggregate<Guid>
    {
        private Survey(){}
        private Survey(string title) : this()
        {
            Id = Guid.NewGuid();
            Title = title;
        }

        private readonly List<Question> _questions = [];
        public IReadOnlyList<Question> Questions => _questions.AsReadOnly();
        public string Title { get; private set; } = null!;

        public static Survey Create(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ValueIsNullException(nameof(title));
            return new Survey(title);
        }

        public void SetTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ValueIsNullException(nameof(newTitle));

            Title = newTitle.Trim();
        }

        public void AddQuestion(Question question)
        {
            if (_questions.Any(q => q.Text.Equals(question.Text, StringComparison.OrdinalIgnoreCase)))
                throw new ValueDuplicateException(nameof(question));

            _questions.Add(question);
        }

        public void RemoveQuestion(Guid questionId)
        {
            var question = _questions.FirstOrDefault(q => q.Id == questionId);
            if (question == null)
                throw new ValueIsNullException(nameof(question));

            _questions.Remove(question);
        }
    }
}
