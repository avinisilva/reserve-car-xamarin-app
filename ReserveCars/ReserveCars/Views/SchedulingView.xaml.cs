using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReserveCars.Views
{

    public class Schedule
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public TimeSpan Hour { get; set; }

        DateTime dateSchedule = DateTime.Today;
        public DateTime DateSchedule
        {
            get
            {
                return dateSchedule;
            }
            set
            {
                dateSchedule = value;
            }
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SchedulingView : ContentPage
    {
        public Vehicle Vehicle { get;  }
        public Schedule Schedule { get; set; }
        
        public SchedulingView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Vehicle = vehicle;
            this.Schedule = new Schedule();

            this.BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert(
                "Scheduling", 
                string.Format("Name: {0}, Phone: {1}, E-mail: {2}, Hour: {3}", this.Schedule.Name, 
                    this.Schedule.Phone, this.Schedule.DateSchedule.ToString("dd/MM/yyyy"), this.Schedule.Hour),
                "ok");
        }
    }
}