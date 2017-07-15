using Newtonsoft.Json;
using ReserveCars.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReserveCars.ViewModels
{
    public class SchedulingViewModel : BaseViewModel
    {
        public const string URL = "http://aluracar.herokuapp.com/salvaragendamento";

        public Schedule Schedule { get; set; }

        public ICommand ScheduleCommand { get; set; }

        public SchedulingViewModel(Vehicle vehicle)
        {
            this.Schedule = new Schedule();
            this.Schedule.Vehicle = vehicle;

            ScheduleCommand = new Command(() => {
                MessagingCenter.Send<Schedule>(this.Schedule, "Schedule");
            }, () => {
                return this.IsValidSchedule();
            });
        }

        private bool IsValidSchedule()
        {
            return true;
            //return !string.IsNullOrEmpty(this.Name);
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.Schedule.Vehicle;
            }
            set
            {
                this.Schedule.Vehicle = value;
            }
        }

        public string Name
        {
            get
            {
                return this.Schedule.Name;
            }
            set
            {
                this.Schedule.Name = value;
                OnPropertyChanged();
                ((Command)ScheduleCommand).ChangeCanExecute();
            }
        }

        public string Phone
        {
            get
            {
                return this.Schedule.Phone;
            }
            set
            {
                this.Schedule.Phone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.Schedule.Email;
            }
            set
            {
                this.Schedule.Email = value;
            }
        }

        public TimeSpan Hour
        {
            get
            {
                return this.Schedule.Hour;
            }
            set
            {
                this.Schedule.Hour = value;
            }
        }

        public DateTime DateSchedule
        {
            get
            {
                return this.Schedule.DateSchedule;
            }
            set
            {
                this.Schedule.DateSchedule = value;
               
            }
        }

        public async void SaveSchedule()
        {
            HttpClient http = new HttpClient();

            var json = JsonConvert.SerializeObject(new {
                nome = this.Name,
                fone = this.Phone,
                email = this.Email,
                preco = this.Vehicle.Price,
                carro = this.Vehicle.Name,
                dataAgendatmento = this.ScheduleDate
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response =  await http.PostAsync(URL, content);

            if (response.IsSuccessStatusCode)
                MessagingCenter.Send<Schedule>(this.Schedule, "ScheduleSaved");
            else
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "ScheduleError");
        }

        private DateTime ScheduleDate
        {
            get
            {
                return new DateTime(
                    DateSchedule.Year, DateSchedule.Month, DateSchedule.Day,
                    Hour.Hours, Hour.Minutes, Hour.Seconds
                );
            }
        }
    }
}
