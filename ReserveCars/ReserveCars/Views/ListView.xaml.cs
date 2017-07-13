using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReserveCars.Views
{
    public class Vehicle
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public string FormatedPrice
        {
            get { return string.Format("R$ {0}", this.Price); }
        }
    }

    public partial class ListView : ContentPage
    {
        public List<Vehicle> Vehicles { get; set; }

        public ListView()
        {
            InitializeComponent();
            loadVehicles();

            this.BindingContext = this;
            //listViewCars.ItemsSource = loadVehicles();
        }

        private void loadVehicles()
        {
            this.Vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Name = "Azera V6",
                    Price = 60000
                },
                new Vehicle
                {
                    Name = "HB20 S",
                    Price = 58000
                },
                new Vehicle
                {
                    Name = "Astra 2.0",
                    Price = 45000
                }
            };
        }

        private void listViewCars_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var vehicle = (Vehicle) e.Item;
            Navigation.PushAsync(new DetailView(vehicle));
        }
    }
}
