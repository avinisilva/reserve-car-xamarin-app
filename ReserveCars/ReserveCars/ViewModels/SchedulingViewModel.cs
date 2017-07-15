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

        public Vehicle Vehicle
        {
            get
            {
                return Schedule.Vehicle;
            }
            set
            {
                Schedule.Vehicle = value;
            }
        }

        public string Name
        {
            get
            {
                return Schedule.Name;
            }
            set
            {
                Schedule.Name = value;
                OnPropertyChanged();
                ((Command)ScheduleCommand).ChangeCanExecute();
            }
        }

        public string Phone
        {
            get
            {
                return Schedule.Phone;
            }
            set
            {
                Schedule.Phone = value;
            }
        }

        public string Email
        {
            get
            {
                return Schedule.Email;
            }
            set
            {
                Schedule.Email = value;
            }
        }

        public TimeSpan Hour
        {
            get
            {
                return Schedule.Hour;
            }
            set
            {
                Schedule.Hour = value;
            }
        }

        public DateTime DateSchedule
        {
            get
            {
                return Schedule.DateSchedule;
            }
            set
            {
                Schedule.DateSchedule = value;
               
            }
        }

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

        private bool IsValidSchedule()
        {
            return !string.IsNullOrEmpty(this.Name);
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
