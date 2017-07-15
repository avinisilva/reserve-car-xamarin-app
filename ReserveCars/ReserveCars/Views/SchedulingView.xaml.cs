using ReserveCars.Models;
using ReserveCars.ViewModels;
using System;

using Xamarin.Forms;

namespace ReserveCars.Views
{
    public partial class SchedulingView : ContentPage
    {
        public SchedulingViewModel ViewModel { get; set; }

        public SchedulingView(Vehicle vehicle)
        {
            InitializeComponent();
            this.ViewModel = new SchedulingViewModel(vehicle);
            this.BindingContext = this.ViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Schedule>(this, "Schedule", async (message) =>
            {
                var confirm = await DisplayAlert("Save Schedule", "Want to schedule?", "Ok", "Cancel");

                if(confirm)
                {
                    this.ViewModel.SaveSchedule();
                }
            });

            MessagingCenter.Subscribe<Schedule>(this, "ScheduleSaved", 
                (schedule) => {
                    DisplayAlert("Saved Success", "Scheduled", "Ok");
                });

            MessagingCenter.Subscribe<ArgumentException>(this, "ScheduleError", 
                (error) => {
                    DisplayAlert("Saved Error", "Not Scheduled", "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Schedule>(this, "Schedule");
            MessagingCenter.Unsubscribe<Schedule>(this, "ScheduleSaved");
            MessagingCenter.Unsubscribe<ArgumentException>(this, "ScheduleError");
        }
    }
}