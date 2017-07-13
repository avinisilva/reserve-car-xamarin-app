using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReserveCars.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        private const int ABS_BREAK = 80;
        private const int AIR = 150;
        private const int MP3_PLAYER = 50;

        private bool ABSBreak;
        private bool Air;
        private bool MP3Player;

        public Vehicle Vehicle { get; }

        public string ABSBreakText
        {
            get { return string.Format("ABS Break R$ {0}", ABS_BREAK); }
        }

        public string AirText
        {
            get { return string.Format("Air R$ {0}", AIR); }
        }

        public string MP3PlayerText
        {
            get { return string.Format("MP3 Player R$ {0}", MP3_PLAYER); }
        }

        public bool HasABSBreak
        {
            get
            {
                return ABSBreak;
            }
            set
            {
                ABSBreak = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public bool HasAir
        {
            get
            {
                return Air;
            }
            set
            {
                Air = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public bool HasMP3Player
        {
            get
            {
                return MP3Player;
            }
            set
            {
                MP3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Total));
            }
        }

        public string Total
        {
            get
            {
                return string.Format("Total R$ {0}",
                    this.Vehicle.Price 
                        + (HasABSBreak ? ABS_BREAK : 0)
                        + (HasAir ? AIR : 0)
                        + (HasMP3Player ? MP3_PLAYER : 0)
                    );
            }
        }

        public DetailView(Vehicle vehicle)
        {
            InitializeComponent();
            this.Vehicle = vehicle;

            this.BindingContext = this;
        }

        private void buttonNext_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SchedulingView(this.Vehicle));
        }
    }
}