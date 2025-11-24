using Android.OS;
using Android.Runtime;

namespace Com.VK.Push.Common.Messaging
{
    partial class RemoteMessage
    {
        partial class CREATOR: global::Java.Lang.Object, IParcelableCreator
        {
            Java.Lang.Object global::Android.OS.IParcelableCreator.CreateFromParcel(global::Android.OS.Parcel parcel)
            {
                return CreateFromParcel(parcel);
            }

            Java.Lang.Object[] global::Android.OS.IParcelableCreator.NewArray(int size)
            {
                return NewArray(size);
            }

        }
    }
    partial class NotificationParams
    {
        partial class CREATOR
        {
            Java.Lang.Object global::Android.OS.IParcelableCreator.CreateFromParcel(global::Android.OS.Parcel parcel)
            {
                return CreateFromParcel(parcel);
            }

            Java.Lang.Object[] global::Android.OS.IParcelableCreator.NewArray(int size)
            {
                return NewArray(size);
            }
        }
    }
}