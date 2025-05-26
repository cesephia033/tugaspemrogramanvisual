using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using booking_ticket.Model;
using MySql.Data.MySqlClient;

namespace booking_ticket
{
    public class UserManajemen
    {
        private Koneksi con = new Koneksi();

        public bool CekLogin(User user)
        {
            bool hasil = false;
            try
            {
                con.start();
                MySqlConnection conn = con.koneksi;

                string sql = "SELECT * FROM user WHERE username = @nama AND password = @pass";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nama", user.Username);
                cmd.Parameters.AddWithValue("@pass", user.Password);

                MySqlDataReader reader = cmd.ExecuteReader();
                hasil = reader.HasRows;
                reader.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                con.stop();
            }
            return hasil;
        }
    }
}
