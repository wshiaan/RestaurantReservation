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



using RestaurantReservation.WebService;


namespace RestaurantReservation
{
    [Activity(Label = "Details")]
    public class Details : Activity
    {
        private ReservationWebService reservationWebService = new ReservationWebService();
        //private Button pickDate;
        private DateTime date;
        private TextView dateDisplay;
        const int DATE_DIALOG_ID = 0;
        private string post;

        private TextView time_display;
        private TextView endtime_display;
        private Button pick_button;
        private Button pickendtime_button;
        private Context mContext;
        private int hour;
        private int minute;
        private int endhour;
        private int endminute;

        private string headcount;
        const int TIME_DIALOG_ID = 1;
        const int ENDTIME_DIALOG_ID = 2;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Details);

            //Pass restaurant id
            int resid = Convert.ToInt32(Intent.GetStringExtra("resid") ?? "No restid");

            //Select Booking Date
            var dateText = FindViewById(Resource.Id.dateText);
            dateDisplay = FindViewById<TextView>(Resource.Id.dateDisplay);
            var pickDate = FindViewById<Button>(Resource.Id.pickDateButton);

            pickDate.Click += (sender, e) =>
            {
                try
                {
                    ShowDialog(DATE_DIALOG_ID);
                }
                catch (Exception ex)
                {
                }


            };

            date = DateTime.Today;
            UpdateDate();

            //Select Booking Time
            var timeText = FindViewById(Resource.Id.timeText);
            time_display = FindViewById<TextView>(Resource.Id.timeDisplay);
            pick_button = FindViewById<Button>(Resource.Id.pickTimeButton);
            pick_button.Click += (o, e) => ShowDialog(TIME_DIALOG_ID);
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
            UpdateTime();

            //Select Headcount
            var headcountText = FindViewById(Resource.Id.headcountText);
            HeadcountSpinner();

            //Select Booking Endtime
            var endtimeText = FindViewById(Resource.Id.endtimeText);
            endtime_display = FindViewById<TextView>(Resource.Id.endtimeDisplay);
            pickendtime_button = FindViewById<Button>(Resource.Id.pickendtimeButton);
            pickendtime_button.Click += (sender, e) =>
            {
                ShowDialog(ENDTIME_DIALOG_ID);

            };
            endhour = DateTime.Now.Hour;
            endminute = DateTime.Now.Minute;
            UpdateEndTime();

            //Floorplan Buttom
            var floorPlan = FindViewById(Resource.Id.floorPlanButton);
            floorPlan.Click += (sender, e) =>
            {
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
            };
            //Search Button
            var search = FindViewById(Resource.Id.searchButton);

            search.Click += (sender, e) =>
            {
                var searchPage = new Intent(this, typeof(Search));
                string start = dateDisplay.Text + " " + string.Concat(time_display.Text);
                string end = dateDisplay.Text + " " + string.Concat(endtime_display.Text);

                searchPage.PutExtra("headcount", headcount);
                searchPage.PutExtra("bookstart", start);
                searchPage.PutExtra("bookend", end);
                searchPage.PutExtra("resid", resid.ToString());

                int hcount = Convert.ToInt32(headcount);
                bool IsWorkingTime = reservationWebService.CheckTime(resid, Convert.ToDateTime(start), Convert.ToDateTime(end));
                if (IsWorkingTime)
                {
                    List<TableNo> tablenum = reservationWebService.GetTableNo(resid, start, end, hcount);
                    IList<string> tablenumList = tablenum.Select(tableno => tableno.Tableid + "|" + tableno.TableNum).ToList();
                    searchPage.PutStringArrayListExtra("tableno", tablenumList);

                    StartActivity(searchPage);
                }
                else
                {
                    string errormsg = string.Format("The booking time is not within working hour. Please reselect the booking time.");
                    //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                    CommonMethod.displayToast(ApplicationContext, errormsg);
                }

            };
        }


        // Functions


        private Spinner HeadcountSpinner()
        {
            Spinner headcountSpinner = FindViewById<Spinner>(Resource.Id.headcountSpinner);

            headcountSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(headcountSpinner_ItemSelected);
            var headcountAdapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.headcountArray, Android.Resource.Layout.SimpleSpinnerItem);

            headcountAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            headcountSpinner.Adapter = headcountAdapter;
            return headcountSpinner;
        }


        //Update Date
        private void UpdateDate()
        {
            dateDisplay.Text = date.ToString("d");
        }


        //Set the date
        void OnDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            this.date = e.Date;
            UpdateDate();
        }

        //Update book time
        private void UpdateTime()
        {
            string time = string.Format("{0}:{1}", hour, minute.ToString().PadLeft(2, '0'));
            time_display.Text = time;
        }

        //Update book endtime
        private void UpdateEndTime()
        {
            string endtime = string.Format("{0}:{1}", endhour, endminute.ToString().PadLeft(2, '0'));
            endtime_display.Text = endtime;
        }

        //Create Dailog
        protected override Dialog OnCreateDialog(int id)
        {

            switch (id)
            {
                case DATE_DIALOG_ID:
                    return new DatePickerDialog(this, OnDateSet, date.Year, date.Month - 1, date.Day);
                case TIME_DIALOG_ID:
                    return new TimePickerDialog(this, TimePickerCallback, hour, minute, false);
                case ENDTIME_DIALOG_ID:
                    return new TimePickerDialog(this, EndTimePickerCallback, endhour, endminute, false);
            }

            return null;
        }

        private void TimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            hour = e.HourOfDay;
            minute = e.Minute;
            UpdateTime();
        }

        private void EndTimePickerCallback(object sender, TimePickerDialog.TimeSetEventArgs e)
        {
            endhour = e.HourOfDay;
            endminute = e.Minute;
            UpdateEndTime();
        }
        private void headcountSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner headcountspinner = (Spinner)sender;
            headcount = (string)headcountspinner.GetItemAtPosition(e.Position);
            // string toast = string.Format("The planet is {0}", spinner.GetItemAtPosition(e.Position));
            // Toast.MakeText(this, toast, ToastLength.Long).Show();
        }


    }
}