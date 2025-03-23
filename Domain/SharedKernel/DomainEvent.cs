using MediatR;

namespace Domain.SharedKernel
{
    public class DomainEvent : INotification
    {
        public Guid EventId { get; private set; } = Guid.NewGuid();
    }
}
