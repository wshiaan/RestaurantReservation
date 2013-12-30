using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RestaurantReservation.WebService;


namespace RestaurantReservation
{
    [Activity(Label = "Select Restaurant:", MainLauncher = true, Icon = "@drawable/icon")]
    public class Main : ListActivity
    {
        // string[] rlist;
        ReservationWebService reservationWebService = new ReservationWebService();
        List<RestaurantName> rlist = new List<RestaurantName>();

        List<String> reslist = new List<string>();
        // private FormulaFinderWebService formulaFinderWebService;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            try
            {
                // Set our view from the "main" layout resource
                var layout = new LinearLayout(this);
                layout.Orientation = Orientation.Vertical;


                //Display restaurant list
                var selectrest = FindViewById(Resource.Id.selectrest);

                var rlistview = FindViewById(Resource.Id.List);

                // View v = FindViewById(Resource.Layout.Main);
                //v.SetBackgroundColor(Android.Graphics.Color.White);
            }
            catch (Exception ex)
            {
            }
            rlist = reservationWebService.GetRestaurantName();
            for (int i = 0; i < rlist.Count; i++)
            {
                reslist.Add(rlist[i].Resname);

            }

            ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, reslist);




        }

        // Choose a restaurant and link to Details page
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var details = new Intent(this, typeof(Details));
            details.PutExtra("resid", rlist[position].Resid.ToString());
            // v.SetBackgroundColor(Android.Graphics.Color.White);
            StartActivity(details);
        }

    }
}

