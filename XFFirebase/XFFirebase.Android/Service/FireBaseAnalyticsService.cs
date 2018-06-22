using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XFFirebase.Droid.Service;
using XFFirebase.Interface;
using Firebase.Analytics;
using Xamarin.Forms;

//Xamarin 相依性注入的語法
[assembly: Xamarin.Forms.Dependency(typeof(FireBaseAnalyticsService))]
namespace XFFirebase.Droid.Service
{
    //繼承核心專案中的介面，並依照原生平台的寫法實作
    class FireBaseAnalyticsService : IFireBaseAnalyticsService
    {
        private FirebaseAnalytics _firebaseAnalytics;

        public FirebaseAnalytics firebaseAnalytics
        {
            get
            {
                if (_firebaseAnalytics == null)
                {
                    firebaseAnalytics = FirebaseAnalytics.GetInstance(MainActivity.Instance);
                }
                return _firebaseAnalytics;
            }
            set { _firebaseAnalytics = value; }
        }

        public FireBaseAnalyticsService() { }

        public void LogEvent(string name, Dictionary<string, object> boundle)
        {
            //將由 PCL 專案傳過來的參數重新用 Android 版 Firebase 所需要的格式填回去
            var p = new Bundle();
            foreach (var item in boundle)
            {
                p.PutString(item.Key, Convert.ToString(item.Value));
            }

            firebaseAnalytics.LogEvent(name, p);
        }

    }
}