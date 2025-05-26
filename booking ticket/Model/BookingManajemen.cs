using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;
using booking_ticket.Model;


namespace booking_ticket
{
    public class BookingManajemen
    {
        private Koneksi con = new Koneksi();

        public bool Tambah(Booking b)
        {
            con.start();
            string sql = "INSERT INTO booking (id, movie, tickets, seattype, total) VALUES (@id, @movie, @tickets, @seat_type, @total)";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@id", b.ID);
            cmd.Parameters.AddWithValue("@movie", b.Movie);
            cmd.Parameters.AddWithValue("@tickets", b.Tickets);
            cmd.Parameters.AddWithValue("@seat_type", b.SeatType);
            cmd.Parameters.AddWithValue("@total", b.Total);
            int result = cmd.ExecuteNonQuery();
            con.stop();
            return result > 0;
        }

        public bool Update(Booking b)
        {
            con.start();
            string sql = "UPDATE booking SET movie = @movie, tickets = @tickets, seattype = @seat_type, total = @total WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@id", b.ID);
            cmd.Parameters.AddWithValue("@movie", b.Movie);
            cmd.Parameters.AddWithValue("@tickets", b.Tickets);
            cmd.Parameters.AddWithValue("@seat_type", b.SeatType);
            cmd.Parameters.AddWithValue("@total", b.Total);
            int result = cmd.ExecuteNonQuery();
            con.stop();
            return result > 0;
        }

        public bool Hapus(int id)
        {
            con.start();
            string sql = "DELETE FROM booking WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();
            con.stop();
            return result > 0;
        }

        public DataTable TampilSemua()
        {
            con.start();
            string sql = "SELECT * FROM booking";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, con.koneksi);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.stop();
            return ds.Tables[0];
        }

        public DataTable Cari(string keyword)
        {
            con.start();
            string sql = "SELECT * FROM booking WHERE movie LIKE @keyword OR seattype LIKE @keyword";
            MySqlCommand cmd = new MySqlCommand(sql, con.koneksi);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.stop();
            return ds.Tables[0];
        }
    }
}
