## Dotnet Android (MAUI) Sdk RuStore

Биндинг официального SDK для получения пуш уведомлений для андроид.

## Состав
1. **maui.rustore.push - dotnet android binding native library**
2. **Sample**

## Сборка
1. В классе MainPage.xaml.cs: 
<code>
   RuStorePushClient.Instance.Init(Platform.CurrentActivity.Application,"your projectId", new MyLogger());
</code> Добавьте свой Id проекта из интерфейса настройки пуш уведомлений.
2. Обязательно настройте подпись apk. Важно что бы fingerprint подписи apk совпадал с тем что указан в настройках пушей.
3. Запускаем. Жмём кнопку, получаем права на пуши, открываем Logcat ищем там !!!!success!!! копируем токен.
4. Добавляем токен в интерфейс отправки тестовых пуш уведомлений
5. Наслаждаемся звуковыми эффектами при получении устройством пуш уведомлений.
