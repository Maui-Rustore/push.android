using Android;
using Android.Content.PM;
using IntelliJ.Lang.Annotations;
using Java.Lang;
using RU.Rustore.Sdk.Pushclient;
using RU.Rustore.Sdk.Pushclient.Common.Logger;
using Exception = System.Exception;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Object = Java.Lang.Object;

namespace Sample;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object? sender, EventArgs e)
    {
        RuStorePushClient.Instance.CheckPushAvailability()
        .AddOnSuccessListener(new SucessListener())
        .AddOnFailureListener(new FailureListener());
        const int requestNotification = 0;
        string[] notiPermission =
        {
            Manifest.Permission.PostNotifications
        };

        if (Platform.CurrentActivity.CheckSelfPermission(Manifest.Permission.PostNotifications) != Permission.Granted)
        {
            Platform.CurrentActivity.RequestPermissions(notiPermission, requestNotification);
        }

        RuStorePushClient.Instance.Init(
            Platform.CurrentActivity.Application,
            "<your projectId>", new MyLogger());
        RuStorePushClient.Instance.Token
            .AddOnFailureListener(new FailureListener())
            .AddOnSuccessListener(new SucessListener());
    }

    public class FailureListener : Java.Lang.Object, RU.Rustore.Sdk.Core.Tasks.IOnFailureListener
    {
        public void OnFailure(Throwable throwable)
        {

        }
    }

    public class SucessListener : Java.Lang.Object, RU.Rustore.Sdk.Core.Tasks.IOnSuccessListener
    {
        public void OnSuccess(Java.Lang.Object? result)
        {
            Console.WriteLine($"!!!!success!!! {result?.ToString()}");
        }
    }

    public class MyLogger : Java.Lang.Object, RU.Rustore.Sdk.Pushclient.Common.Logger.ILogger
    {
        public Com.VK.Push.Common.ILogger CreateLogger(Object any)
        {
            return new MyLogger();
        }

        public RU.Rustore.Sdk.Pushclient.Common.Logger.ILogger CreateLogger(string tag)
        {
            return new MyLogger();
        }

        Com.VK.Push.Common.ILogger Com.VK.Push.Common.ILogger.CreateLogger(string tag)
        {
            return new MyLogger();
        }

        public void Debug(string message, Throwable? throwable)
        {
            Console.WriteLine($"[DEBUG] {message} {throwable}");
        }

        public void Error(string message, Throwable? throwable)
        {
            Console.WriteLine($"[ERROR] {message} {throwable}");
        }

        public void Info(string message, Throwable? throwable)
        {
            Console.WriteLine($"[INFO] {message} {throwable}");
        }

        public void Verbose(string message, Throwable? throwable)
        {
            Console.WriteLine($"[VERBOSE] {message} {throwable}");
        }

        public void Warn(string message, Throwable? throwable)
        {
            Console.WriteLine($"[WARN] {message} {throwable}");
        }
    }
}