using System.Collections.Generic;
using System.Linq;

namespace API_CQS_CRUD_Usuarios.Domain.Notification
{
    public class DomainNotificationContext : IDomainNotificationContext
    {
        private readonly List<DomainNotification> _notifications;

        public DomainNotificationContext()
        {
            _notifications = new List<DomainNotification>();
        }

        public bool HasErrorNotifications
            => _notifications.Any(x => x.Type == DomainNotificationType.Erro);

        public void NotifySuccess(string message)
            => Notify(message, DomainNotificationType.Sucesso);

        public void NotifyError(string message)
            => Notify(message, DomainNotificationType.Erro);

        private void Notify(string message, DomainNotificationType type)
            => _notifications.Add(new DomainNotification(type, message));

        public List<DomainNotification> GetErrorNotifications()
            => _notifications.Where(x => x.Type == DomainNotificationType.Erro).ToList();
    }
}
