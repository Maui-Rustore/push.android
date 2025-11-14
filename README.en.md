## Dotnet Android (MAUI) Sdk RuStore

Binding of the official SDK for receiving push notifications on Android.

## Build sample
1. In class MainPage.xaml.cs:
RuStorePushClient.Instance.Init(Platform.CurrentActivity.Application, "your projectId", new MyLogger());
Add your Project ID from the Push Notifications Settings interface.
2. Make sure to configure APK signing. It is important that the APK signature's fingerprint matches the one specified in the push notification settings.
3. Run the app. Press the button, obtain permissions for push notifications, open Logcat and search for !!!!success!!!, then copy the token.
4. Add the token to the test push notification sending interface.
5. Enjoy sound effects when the device receives push notifications.

