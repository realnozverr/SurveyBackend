using CSharpFunctionalExtensions;

namespace Domain.SharedKernel
{
    public class Aggregate<TId> : Entity<TId>, IAggregateRoot where TId : IComparable<TId>
    {
        protected Aggregate(TId id) : base(id){}
        protected Aggregate(){}
        private readonly List<DomainEvent> _domainEvents = [];
        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public void ClearDomainEvents() => _domainEvents.Clear();
        protected void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}
