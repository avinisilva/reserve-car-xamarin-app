using ReserveCars.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReserveCars.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        public Vehicle Vehicle { get; set; }
        public ICommand NextCommand { get; set; }


        public string ABSBreakText
        {
            get { return string.Format("ABS Break R$ {0}", Vehicle.ABS_BREAK); }
        }

        public string AirText
        {
            get { return string.Format("Air R$ {0}", Vehicle.AIR); }
        }

        public string MP3PlayerText
        {
            get { return string.Format("MP3 Player R$ {0}", Vehicle.MP3_PLAYER); }
        }

        public bool HasABSBreak
        {
            get
            {
                return Vehicle.HasABSBreak;
            }
            set
            {
                Vehicle.HasABSBreak = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public bool HasAir
        {
            get
            {
                return Vehicle.HasAir;
            }
            set
            {
                Vehicle.HasAir = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public bool HasMP3Player
        {
            get
            {
                return Vehicle.HasMP3Player;
            }
            set
            {
                Vehicle.HasMP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public string Total
        {
            get
            {
                return Vehicle.TotalFormatedPrice;
            }
        }

        public DetailViewModel(Vehicle vehicle)
        {
            this.Vehicle = vehicle;
            NextCommand = new Command(() => {
                MessagingCenter.Send<Vehicle>(vehicle, "Next");
            });
        }
    }
}
