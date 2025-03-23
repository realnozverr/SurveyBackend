namespace Domain.SharedKernel
{
    public interface IAggregateRoot
    {
        IReadOnlyList<DomainEvent> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
