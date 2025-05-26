using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using booking_ticket.Controller;
using booking_ticket.Model;

namespace booking_ticket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nama = textBox1.Text;
            string pass = textBox2.Text;
            User user = new User(nama, pass);
            userController userController = new userController();

            try
            {
                bool berhasil = userController.Login(user);

                if (berhasil)
                {
                    MessageBox.Show("Login Berhasil!");
                    utama2 formBooking = new utama2();
                    formBooking.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login gagal! Coba Lagi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
