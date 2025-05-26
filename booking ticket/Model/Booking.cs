using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booking_ticket.Model
{
    public class Booking
    {
        public int ID { get; set; }
        public string Movie { get; set; }
        public int Tickets { get; set; }
        public string SeatType { get; set; }
        public decimal Total { get; set; }
    }
}
