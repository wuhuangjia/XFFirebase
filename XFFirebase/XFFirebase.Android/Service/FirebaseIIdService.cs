using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Iid;

namespace XFFirebase.Droid.Service
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    class FirebaseIIdService: FirebaseInstanceIdService
    {
        const string TAG = "taolecardFirebaseIIDService";

        /**
         * Called if InstanceID token is updated. This may occur if the security of
         * the previous token had been compromised. Note that this is called when the InstanceID token
         * is initially generated so this is where you would retrieve the token.
         */
        // [START refresh_token]
        public override void OnTokenRefresh()
        {
            // Get updated InstanceID token.
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Android.Util.Log.Debug(TAG, $"Refreshed token:{refreshedToken}");

            // TODO: Implement this method to send any registration to your app's servers.
            SendRegistrationToServerAsync(refreshedToken);
        }
        // [END refresh_token]

        /**
         * Persist token to third-party servers.
         *
         * Modify this method to associate the user's FCM InstanceID token with any server-side account
         * maintained by your application.
         */
        async void SendRegistrationToServerAsync(string token)
        {
            // Add custom implementation, as needed.
            try
            {
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}