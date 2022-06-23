using Sween.Core.Entities;
using System.Threading.Tasks;

namespace Sween.Core.Interfaces
{
    public interface INotificationService
    {
        Task<ResponseModel> SendNotification(NotificationModel notificationModel);
    }
}
