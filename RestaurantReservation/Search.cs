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
    [Activity(Label = "Search for tables")]
    public class Search : Activity
    {
        private int tableposition;
        private string tablenum;
        private string tableID;
        private string errormsg;
        IList<string> tablenumlist;
        private readonly IList<string> tablenumber = new List<string>();
        private readonly IList<string> tableid = new List<string>();
        private bool error;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Search);
            int resid = Convert.ToInt32(Intent.GetStringExtra("resid") ?? "No restid");

            //Get the book start from previous page
            var bookStartView = FindViewById<TextView>(Resource.Id.bookStartView);
            var bookStart = FindViewById<TextView>(Resource.Id.bookStart);
            bookStart.Text = Intent.GetStringExtra("bookstart") ?? "No Book Start Time";

            //Get the book end time from previous page
            var bookEndView = FindViewById<TextView>(Resource.Id.bookEndView);
            var bookEnd = FindViewById<TextView>(Resource.Id.bookEnd);
            bookEnd.Text = Intent.GetStringExtra("bookend") ?? "No Book End Time";


            //Display Headcount selected

            var headcountView = FindViewById(Resource.Id.headcountView);
            var headcount = FindViewById<TextView>(Resource.Id.headcount);
            headcount.Text = Intent.GetStringExtra("headcount") ?? "No Headcount";

            //Display list of table num availables
            var tableNum = FindViewById(Resource.Id.tableNum);
            // add spinner here
            TablenumSpinner();

            //Menu button
            var menuButton = FindViewById(Resource.Id.menuButton);
            menuButton.Click += delegate(object sender, EventArgs e)
            {
                switch (resid)
                {
                    case 1:
                        {
                            var coffeeshop = new Intent(this, typeof(Coffeeshop));
                            StartActivity(coffeeshop);
                            return;
                        }
                    case 2:
                        {
                            var hansells = new Intent(this, typeof(Hansellskitchen));
                            StartActivity(hansells);
                            return;
                        }
                    case 3:
                        {
                            var andy = new Intent(this, typeof(Andysteakhouse));
                            StartActivity(andy);
                            return;
                        }
                    case 4:
                        {
                            var maple = new Intent(this, typeof(Maplepalace));
                            StartActivity(maple);
                            return;
                        }
                    case 5:
                        {
                            var garden = new Intent(this, typeof(Restaurantgarden));
                            StartActivity(garden);
                            return;
                        }
                    case 6:
                        {
                            var bbq = new Intent(this, typeof(RestaurantBBQ));
                            StartActivity(bbq);
                            return;
                        }
                }

            };

            //Next button to link to UserDetails page
            var nextButton = FindViewById(Resource.Id.nextButton);

            nextButton.Click += delegate(object sender, EventArgs e)
            {
                if (!error)
                {
                    var userdetails = new Intent(this, typeof(UserDetails));
                    userdetails.PutExtra("bookstart", bookStart.Text);
                    userdetails.PutExtra("bookend", bookEnd.Text);
                    userdetails.PutExtra("headcount", headcount.Text);
                    userdetails.PutExtra("tableid", tableID);
                    userdetails.PutExtra("tablenum", tablenum);
                    StartActivity(userdetails);
                }
                else
                {
                    errormsg = "No table available for this headcount. Please reselect headcount to proceed.";
                    //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                    CommonMethod.displayToast(ApplicationContext, errormsg);
                }
            };
            //Floor plan button to view the floor plan
            var floorplan = FindViewById(Resource.Id.floorplan);
            switch (resid)
            {
                case 1:
                    {
                        // var coffeeshop = new Intent(this, typeof(CoffeeShop));
                        //  StartActivity(coffeeshop);
                        var imageView =
                        FindViewById<ImageView>(Resource.Id.demoImageView);
                        imageView.SetImageResource(Resource.Drawable.coffeeshop);
                        return;
                    }
                case 2:
                    {
                        var imageView =
                       FindViewById<ImageView>(Resource.Id.demoImageView);
                        imageView.SetImageResource(Resource.Drawable.HansellsKitchen2);
                        return;
                    }
                case 3:
                    {
                        var imageView =
                       FindViewById<ImageView>(Resource.Id.demoImageView);
                        imageView.SetImageResource(Resource.Drawable.AndySteakHouse);
                        return;
                    }
                case 4:
                    {
                        var imageView =
                       FindViewById<ImageView>(Resource.Id.demoImageView);
                        imageView.SetImageResource(Resource.Drawable.MaplePalace);
                        return;
                    }
                case 5:
                    {
                        var imageView =
                       FindViewById<ImageView>(Resource.Id.demoImageView);
                        imageView.SetImageResource(Resource.Drawable.RestaurantGarden);
                        return;
                    }
                case 6:
                    {
                        var imageView =
                        FindViewById<ImageView>(Resource.Id.demoImageView);
                        imageView.SetImageResource(Resource.Drawable.OsakaSushi);
                        return;

                    }
            }




        }
        private Spinner TablenumSpinner()
        {

            tablenumlist = Intent.GetStringArrayListExtra("tableno");

            Spinner tablenumSpinner = FindViewById<Spinner>(Resource.Id.tablenumSpinner);
            tablenumSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(tablenumSpinner_ItemSelected);

            foreach (string tableno in tablenumlist)
            {
                tableid.Add(tableno.Split('|')[0]);
                tablenumber.Add(tableno.Split('|')[1]);
            }

            ArrayAdapter<string> tablenumAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, tablenumber);
            if (tablenumber.Count() == 0)
            {
                errormsg = "No table available for this headcount.";
                //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                CommonMethod.displayToast(ApplicationContext, errormsg);
                error = true;
            }
            else
            {
                tablenumAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                tablenumSpinner.Adapter = tablenumAdapter;
            }
            return tablenumSpinner;
        }

        private void tablenumSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner tablenumspinner = (Spinner)sender;
            tablenum = (string)tablenumspinner.GetItemAtPosition(e.Position);
            tableposition = (int)tablenumspinner.GetItemIdAtPosition(e.Position);
            tableID = tableid[tableposition];
        }

    }
}