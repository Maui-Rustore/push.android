namespace RU.Rustore.Sdk.Pushclient.Common.Logger;

public partial class DefaultLogger
{
    Com.VK.Push.Common.ILogger Com.VK.Push.Common.ILogger.CreateLogger(string tag)
    {
        return CreateLogger(tag);
    }
}