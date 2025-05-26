using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking_ticket.Model;

namespace booking_ticket.Controller
{
    public class bookingController
    {
        private BookingManajemen manajemen = new BookingManajemen();

        public bool TambahBooking(Booking b) => manajemen.Tambah(b);
        public bool UpdateBooking(Booking b) => manajemen.Update(b);
        public bool HapusBooking(int id) => manajemen.Hapus(id);
        public DataTable GetAllBooking() => manajemen.TampilSemua();
        public DataTable CariBooking(string keyword) => manajemen.Cari(keyword);
    }
}
