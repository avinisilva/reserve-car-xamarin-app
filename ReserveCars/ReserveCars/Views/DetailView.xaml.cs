using ReserveCars.Models;
using ReserveCars.ViewModels;

using Xamarin.Forms;

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
            Subscriber();
        }

        private void Subscriber()
        {
            MessagingCenter.Subscribe<Vehicle>(this, "Next", (vehicle) =>
            {
                Navigation.PushAsync(new SchedulingView(this.Vehicle));
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Unsubscriber();
        }

        private void Unsubscriber()
        {
            MessagingCenter.Unsubscribe<Vehicle>(this, "Next");
        }
    }
}