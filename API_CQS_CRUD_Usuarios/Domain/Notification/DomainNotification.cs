using MediatR;

namespace API_CQS_CRUD_Usuarios.Domain.Notification
{
    public class DomainNotification : INotification
    {
        public DomainNotificationType Type { get; protected set; }
        public string Value { get; protected set; }

        public DomainNotification(DomainNotificationType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}
