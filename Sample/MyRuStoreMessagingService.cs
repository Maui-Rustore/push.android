using Android.App;
using Android.Util;
using Microsoft.Maui.Controls.Internals;
using RU.Rustore.Sdk.Pushclient.Messaging.Exception;
using RU.Rustore.Sdk.Pushclient.Messaging.Model;
using RU.Rustore.Sdk.Pushclient.Messaging.Service;
using Sample.Wrapper;

namespace Sample.Platforms.Android;

[Preserve(AllMembers = true)]
[Service(Exported = true)]
[IntentFilter(new[] { "ru.rustore.sdk.pushclient.MESSAGING_EVENT" })]
public class PushListenerService : RuStoreMessagingService
{
    private const string LogTag = "PushListenerService";
    private NotificationManagerWrapper? _notificationManagerWrapper;

    public override void OnCreate()
    {
        base.OnCreate();
        _notificationManagerWrapper = NotificationManagerWrapper.GetInstance(this);
    }

    public override void OnNewToken(string token)
    {
        Log.Debug(LogTag, $"OnNewToken token = {token}");
    }

    public override void OnMessageReceived(RemoteMessage message)
    {
        base.OnMessageReceived(message);

        var channelInfo = GetChannelInfo();

        var notification = new AppNotification(
            message.GetHashCode(),
            message.Notification?.Title,
            message.Notification?.Body,
            channelInfo.Item1,
            channelInfo.Item2
        );

        _notificationManagerWrapper.ShowNotification(this, notification);
    }

    private (string, string) GetChannelInfo()
    {
        string channelId = GetString(Resource.String.notifications_data_push_channel_id);
        string channelName = GetString(Resource.String.notifications_data_push_channel_name);
        return (channelId, channelName);
    }

    public override unsafe void OnError(IList<RuStorePushClientException> errors)
    {
        base.OnError(errors);
    }
}