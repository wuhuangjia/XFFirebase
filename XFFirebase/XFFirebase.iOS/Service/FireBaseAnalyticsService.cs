using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using XFFirebase.Interface;
using XFFirebase.iOS.Service;
using Firebase.Analytics;

[assembly: Xamarin.Forms.Dependency(typeof(FireBaseAnalyticsService))]
namespace XFFirebase.iOS.Service
{
    class FireBaseAnalyticsService : IFireBaseAnalyticsService
    {
        public FireBaseAnalyticsService() { }

        public void LogEvent(string name, Dictionary<string, object> boundle)
        {
            // [START custom_event]
            List<NSString> Listkeys = new List<NSString>();
            List<NSObject> Listvalues = new List<NSObject>();

            foreach (var item in boundle)
            {
                Listkeys.Add(new NSString(item.Key));
                Listvalues.Add(NSObject.FromObject(item.Value));
            }
            var p = NSDictionary<NSString, NSObject>.FromObjectsAndKeys(Listkeys.ToArray(), Listvalues.ToArray(), Listkeys.Count);

            Analytics.LogEvent(name, p);
            // [END custom_event]
        }

    }
}
