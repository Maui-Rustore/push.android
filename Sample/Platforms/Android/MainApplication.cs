using Android.App;
using Android.Runtime;
using RU.Rustore.Sdk.Pushclient;

namespace Sample;

[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr handle, JniHandleOwnership ownership)
        : base(handle, ownership)
    {
    }

    protected override MauiApp CreateMauiApp()
    {
        var app = MauiProgram.CreateMauiApp();
        return app;
    }
    
    public override void OnCreate()
    {
        base.OnCreate();
        RuStorePushClient.Instance.Init(this,
            "project id", new MainActivity.MyLogger());
    }
}