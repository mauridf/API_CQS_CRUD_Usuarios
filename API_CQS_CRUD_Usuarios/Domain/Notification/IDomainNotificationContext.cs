using System.Collections.Generic;

namespace API_CQS_CRUD_Usuarios.Domain.Notification
{
    public interface IDomainNotificationContext
    {
        bool HasErrorNotifications { get; }
        void NotifyError(string message);
        void NotifySuccess(string message);
        List<DomainNotification> GetErrorNotifications();
    }
}
