using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Com.VK.Push.Common;
using Java.Lang;
using RU.Rustore.Sdk.Pushclient;
using RU.Rustore.Sdk.Pushclient.Utils;
using Object = System.Object;

namespace Sample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
protected override void OnCreate(Bundle? savedInstanceState)
{
    base.OnCreate(savedInstanceState);
    const int requestNotification = 0;
    string[] notiPermission =
    {
        Manifest.Permission.PostNotifications
    };

    if (CheckSelfPermission(Manifest.Permission.PostNotifications) != Permission.Granted)
    {
        RequestPermissions(notiPermission, requestNotification);
    }
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

        public ILogger CreateLogger(Java.Lang.Object any)
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