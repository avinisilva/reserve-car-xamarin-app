﻿using Newtonsoft.Json;
using ReserveCars.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReserveCars.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        public const string URL = "http://aluracar.herokuapp.com/";

        public ObservableCollection<Vehicle> Vehicles { get; set; }

        private bool waitVehicles;

        public bool WaitVechiles
        {
            get
            {
                return waitVehicles;
                
            }
            set
            {
                waitVehicles = value;
                OnPropertyChanged();
            }
        }

        private Vehicle vehicleSelected;

        public Vehicle VehicleSelected
        {
            get
            {
                return vehicleSelected;
            }
            set
            {
                vehicleSelected = value;
                if(value != null)
                    MessagingCenter.Send(vehicleSelected, "VehicleSelected");
            }
        }

        public ListViewModel()
        {
            this.Vehicles = new ObservableCollection<Vehicle>();
        }

        public async Task GetVehicles()
        {
            this.Vehicles.Clear();
            WaitVechiles = true;
            HttpClient http = new HttpClient();

            var result = await http.GetStringAsync(URL);
            var vehiclesJson = JsonConvert.DeserializeObject<VehicleDTO[]>(result);

            foreach (var vehicleJson in vehiclesJson)
            {
                this.Vehicles.Add(new Vehicle { Name = vehicleJson.nome, Price = vehicleJson.preco});
            }

            WaitVechiles = false;
        }

        class VehicleDTO
        {
            public string nome { get; set; }
            public int preco { get; set; }
        }
    }
}
