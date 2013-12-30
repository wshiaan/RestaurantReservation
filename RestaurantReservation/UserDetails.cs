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
using System.Text.RegularExpressions;

namespace RestaurantReservation
{
    [Activity(Label = "User Details")]
    public class UserDetails : Activity
    {
        private ReservationWebService reservationWebService = new ReservationWebService();
        private int error;
        private string errormsg = "";
        private int length;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.UserDetails);
            int tableid = Convert.ToInt32(Intent.GetStringExtra("tableid") ?? "No tableid");


            //Get the book start from previous page
            var bookStartView = FindViewById<TextView>(Resource.Id.bookStartView);
            var bookStart = FindViewById<TextView>(Resource.Id.bookStart);
            bookStart.Text = Intent.GetStringExtra("bookstart") ?? "No Book Start Date and Time";

            //Get the book end from previous page
            var bookEndView = FindViewById<TextView>(Resource.Id.bookEndView);
            var bookEnd = FindViewById<TextView>(Resource.Id.bookEnd);
            bookEnd.Text = Intent.GetStringExtra("bookend") ?? "No Book End Date and Time";

            //Display Table number selected
            var tablenumnView = FindViewById(Resource.Id.tablenumView);
            var tablenum = FindViewById<TextView>(Resource.Id.tablenum);
            tablenum.Text = Intent.GetStringExtra("tablenum") ?? "No Table Number";


            //Display Headcount selected
            var headcountView = FindViewById(Resource.Id.headcountView);
            var headcount = FindViewById<TextView>(Resource.Id.headcount);
            headcount.Text = Intent.GetStringExtra("headcount") ?? "No Headcount";


            //Enter name
            var name = FindViewById(Resource.Id.name);
            var editnameView = FindViewById<TextView>(Resource.Id.editnameView);
            var editName = FindViewById<EditText>(Resource.Id.editName);

            //Enter phone number
            var phone = FindViewById(Resource.Id.phone);
            var editphoneView = FindViewById<TextView>(Resource.Id.editphoneView);
            var editPhone = FindViewById<EditText>(Resource.Id.editPhone);

            //Enter email
            var email = FindViewById(Resource.Id.email);
            var editemailView = FindViewById<TextView>(Resource.Id.editemailView);
            var editEmail = FindViewById<EditText>(Resource.Id.editEmail);

            //Confirm button, enter the details into database
            var confirmButton = FindViewById(Resource.Id.confirmButton);


            confirmButton.Click += (sender, e) =>
            {
                if (CheckName(editName.Text) && CheckPhome(editPhone.Text) && CheckEmail(editEmail.Text))
                {
                    reservationWebService.InsertDetails(editName.Text, editPhone.Text, editEmail.Text, bookStart.Text, bookEnd.Text, Convert.ToInt32(headcount.Text));
                    reservationWebService.InsertBooking(tableid, DateTime.Now, "booked");
                    string toast = string.Format("Table Reserved.");
                    // Toast.MakeText(this, toast, ToastLength.Long).Show();
                    CommonMethod.displayToast(ApplicationContext, toast);
                }

            };

            editName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {

                editnameView.Text = e.Text.ToString();

            };

            editPhone.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {

                editphoneView.Text = e.Text.ToString();

            };

            editEmail.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {

                editemailView.Text = e.Text.ToString();
            };
        }

        private bool CheckName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                length = name.Length;
                for (int i = 0; i < length; i++)
                {

                    Regex alphabet = new Regex("[a-zA-Z]| ");

                    Match namematch = alphabet.Match(name.Substring(i, 1));
                    if (!namematch.Success || name.StartsWith(" ") || name.EndsWith(" "))
                    {
                        errormsg = string.Format("Invalid name. Note: Special character is not accepted. Name starts with or ends with space is not allowed.");
                        // Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                        CommonMethod.displayToast(ApplicationContext, errormsg);
                        return false;
                    }

                }
            }
            else
            {
                errormsg = "Please enter name.";
                //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                CommonMethod.displayToast(ApplicationContext, errormsg);
                return false;
            }
            return true;


        }

        private bool CheckEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Regex endwith = new Regex("com$|co$");
                Match endwithmatch = endwith.Match(email);

                if (!endwithmatch.Success || email.EndsWith(" ") || email.StartsWith(" "))
                {
                    errormsg = "Invalid email.";
                    //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                    CommonMethod.displayToast(ApplicationContext, errormsg);
                    return false;
                }
                else if (email.IndexOf("@") == -1)
                {
                    errormsg = "Email must have a '@' character.";
                    //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                    CommonMethod.displayToast(ApplicationContext, errormsg);
                    return false;
                }
                else if (email.IndexOf(".") == -1)
                {
                    errormsg = "Email must have at least one '.' ";
                    //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                    CommonMethod.displayToast(ApplicationContext, errormsg);
                    return false;
                }
            }

            else
            {
                errormsg = "Please enter email.";
                //Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                CommonMethod.displayToast(ApplicationContext, errormsg);
                return false;
            }

            return true;
        }

        private bool CheckPhome(string phone)
        {

            if (!string.IsNullOrEmpty(phone))
            {
                length = phone.Length;
                // for (int i = 0; i < length; i++)
                //  {

                Regex phonepattern = new Regex("[0-9]{10}");

                Match phonematch = phonepattern.Match(phone);
                if (!phonematch.Success || phone.StartsWith(" ") || phone.EndsWith(" "))
                {
                    errormsg = string.Format("Invalid phone number.");
                    // Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                    CommonMethod.displayToast(ApplicationContext, errormsg);
                    return false;
                }

                //}
            }
            else
            {
                errormsg = "Please enter phone number.";
                // Toast.MakeText(this, errormsg, ToastLength.Long).Show();
                CommonMethod.displayToast(ApplicationContext, errormsg);
                return false;
            }
            return true;
        }
    }
}