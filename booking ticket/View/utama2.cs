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
    public partial class utama2 : Form
    {
        bookingController controller = new bookingController();

        public utama2()
        {
            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label4.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            label6.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;

        }

        private Booking AmbilDataDariForm()
        {
            return new Booking
            {
                ID = int.Parse(textBoxID.Text),
                Movie = comboBoxMovie.Text,
                Tickets = int.Parse(textBoxTickets.Text),
                SeatType = textBoxSeatType.Text,
                Total = decimal.Parse(comboBoxTotal.Text)
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Booking b = AmbilDataDariForm();
                bool success = controller.TambahBooking(b);
                if (success)
                {
                    MessageBox.Show("Data booking berhasil disimpan.");
                    ResetForm();
                    dataGridView1.DataSource = controller.GetAllBooking();
                }
                else
                {
                    MessageBox.Show("Gagal menyimpan data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            textBoxID.ReadOnly= false;
            ResetForm();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Booking b = AmbilDataDariForm();
                bool success = controller.UpdateBooking(b);
                if (success)
                {
                    ResetForm();
                    dataGridView1.DataSource = controller.GetAllBooking();
                    MessageBox.Show("Data booking berhasil diperbarui.");
                }
                else
                {
                    MessageBox.Show("Gagal memperbarui data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = int.Parse(textBoxID.Text);
                    bool success = controller.HapusBooking(id);
                    if (success)
                    {
                        MessageBox.Show("Data booking berhasil dihapus.");
                        ResetForm();
                        dataGridView1.DataSource = controller.GetAllBooking();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus data.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message);
            }
        }

        private void utama2_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = controller.GetAllBooking();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Pastikan baris yang diklik valid
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                textBoxID.Text = row.Cells["ID"].Value.ToString();
                comboBoxMovie.Text = row.Cells["Movie"].Value.ToString();
                textBoxTickets.Text = row.Cells["Tickets"].Value.ToString();
                textBoxSeatType.Text = row.Cells["SeatType"].Value.ToString();
                comboBoxTotal.Text = row.Cells["Total"].Value.ToString();
            }
            textBoxID.ReadOnly = true;
        }

        private void ResetForm()
        {
            textBoxID.Clear();
            comboBoxMovie.SelectedIndex = -1; // Mengosongkan ComboBox
            textBoxTickets.Clear();
            textBoxSeatType.Clear();
            comboBoxTotal.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBox1.Text.Trim();
                if (!string.IsNullOrEmpty(keyword))
                {
                    dataGridView1.DataSource = controller.CariBooking(keyword);
                }
                else
                {
                    dataGridView1.DataSource = controller.GetAllBooking();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mencari: " + ex.Message);
            }
        }
    }
}

   
