using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using RU.Rustore.Sdk.Pushclient;
using RU.Rustore.Sdk.Pushclient.Utils;

namespace Sample;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                           ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    public MainActivity() : base()
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironment_UnhandledExceptionRaiser;
        TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
    }

    private void TaskScheduler_UnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {

    }

    private void AndroidEnvironment_UnhandledExceptionRaiser(object? sender, RaiseThrowableEventArgs e)
    {

    }

    private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {

    }

    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    }
}