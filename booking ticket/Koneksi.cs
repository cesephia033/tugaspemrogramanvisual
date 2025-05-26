using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace booking_ticket
{
    internal class Koneksi
    {
        string mysqlCon = "server=127.0.0.1;user=root;database=bookingticket;password=";
        public MySqlConnection koneksi;

        public void start()
        {
            koneksi = new MySqlConnection(mysqlCon);
            koneksi.Open();
        }

        public void stop()
        {
            koneksi = new MySqlConnection(mysqlCon);
            koneksi.Close();
        }
    }
}
