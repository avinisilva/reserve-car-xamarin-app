using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveCars.Models
{
    public class Vehicle
    {
        public const int ABS_BREAK = 80;
        public const int AIR = 150;
        public const int MP3_PLAYER = 50;

        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool HasABSBreak { get; set; }
        public bool HasAir { get; set; }
        public bool HasMP3Player { get; set; }

        public string FormatedPrice
        {
            get { return string.Format("R$ {0}", this.Price); }
        }

        public string TotalFormatedPrice
        {
            get
            {
                return string.Format("Total R$ {0}",
                    this.Price
                        + (HasABSBreak ? Vehicle.ABS_BREAK : 0)
                        + (HasAir ? Vehicle.AIR : 0)
                        + (HasMP3Player ? Vehicle.MP3_PLAYER : 0)
                    );
            }
        }
    }
}
