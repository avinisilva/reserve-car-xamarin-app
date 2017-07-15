using ReserveCars.Models;
using ReserveCars.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReserveCars.Views
{
    public partial class DetailView : ContentPage
    {
        public Vehicle Vehicle { get; set; }

        public DetailView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Vehicle = vehicle;
            this.BindingContext = new DetailViewModel(vehicle);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "Next", (vehicle)  => {
                Navigation.PushAsync(new SchedulingView(this.Vehicle));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "Next");
        }

    }
}