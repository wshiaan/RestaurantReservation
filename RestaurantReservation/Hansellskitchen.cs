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
    [Activity(Label = "My Activity")]
    public class Hansellskitchen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.hansells);
            var menu = FindViewById(Resource.Id.hansellsmenu);
            // Create your application here
        }
    }
}