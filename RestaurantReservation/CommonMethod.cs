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

namespace RestaurantReservation
{
    class CommonMethod
    {
        public static void displayToast(Context caller, String toastMsg)
        {
            LayoutInflater inflater = LayoutInflater.From(caller);
            View mainLayout = inflater.Inflate(Resource.Layout.toast_layout, null);
            View rootLayout = mainLayout.FindViewById(Resource.Id.toast_layout_root);
            TextView text = (TextView)mainLayout.FindViewById(Resource.Id.text);
            text.Text = toastMsg;
            Toast toast = new Toast(caller);
            toast.SetGravity(GravityFlags.Center, 0, 0);
            toast.Duration = ToastLength.Long;
            toast.View = rootLayout;
            toast.Show();
        }
    }
}