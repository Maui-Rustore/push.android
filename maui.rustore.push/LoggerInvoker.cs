namespace RU.Rustore.Sdk.Pushclient.Common.Logger;

internal partial class ILoggerInvoker
{
    Com.VK.Push.Common.ILogger Com.VK.Push.Common.ILogger.CreateLogger(string tag)
    {
        return CreateLogger(tag);
    }
}
