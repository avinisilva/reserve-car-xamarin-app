using System;

namespace ReserveCars.Models
{
    public class Schedule
    {
        public Vehicle Vehicle { get; set; }
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
}
