using Android.Content;
using Android.Content.PM;
using AndroidX.Core.App;
using AndroidX.Core.Content;

namespace Sample.Wrapper;

public record AppNotification(int Id, string Title, string Message, string ChannelId, string ChannelName);
public class NotificationManagerWrapper
{
    private readonly NotificationManagerCompat _notificationManager;
    private static NotificationManagerWrapper _instance;

    private NotificationManagerWrapper(NotificationManagerCompat notificationManager)
    {
        _notificationManager = notificationManager;
    }

    public static NotificationManagerWrapper GetInstance(Context context)
    {
        if (_instance == null)
        {
            _instance = new NotificationManagerWrapper(NotificationManagerCompat.From(context));
        }
        return _instance;
    }

    public void CreateNotificationChannel(string channelId, string channelName)
    {
        var builder = new NotificationChannelCompat.Builder(channelId, NotificationManagerCompat.ImportanceDefault)
            .SetName(channelName);

        _notificationManager.CreateNotificationChannel(builder.Build());
    }

    public void ShowNotification(Context context, AppNotification data)
    {
        // Создаём билдер уведомления
        var builder = new NotificationCompat.Builder(context, data.ChannelId)
            .SetContentTitle(data.Title)
            .SetContentText(data.Message)
            .SetSmallIcon(Resource.Drawable.dotnet_bot); // замените на свой значок

        // Проверяем наличие канала
        if (_notificationManager.GetNotificationChannel(data.ChannelId) == null)
        {
            CreateNotificationChannel(data.ChannelId, data.ChannelName);
        }

        // Проверка разрешения на уведомления (Android 13+)
        if (ContextCompat.CheckSelfPermission(context, Android.Manifest.Permission.PostNotifications) != Permission.Granted)
        {
            return;
        }

        _notificationManager.Notify(data.Id, builder.Build());
    }
}