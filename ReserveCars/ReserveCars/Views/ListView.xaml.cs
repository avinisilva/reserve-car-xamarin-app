using ReserveCars.Models;
using ReserveCars.ViewModels;

using Xamarin.Forms;

namespace ReserveCars.Views
{
    public partial class ListView : ContentPage
    {
        public ListViewModel ViewModel { get; set; }

        public ListView()
        {
            InitializeComponent();
            this.ViewModel = new ListViewModel();
            this.BindingContext = this.ViewModel;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Vehicle>(this, "VehicleSelected", 
                (vehicle => {
                    Navigation.PushAsync(new DetailView(vehicle));
                })
            );

            await this.ViewModel.GetVehicles();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Vehicle>(this, "VehicleSelected");
        }
    }
}
