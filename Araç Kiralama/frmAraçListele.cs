﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Araç_Kiralama
{
    public partial class frmAraçListele : Form
    {
        Araç_Kiralama arackiralama = new Araç_Kiralama();
        public frmAraçListele()
        {
            InitializeComponent();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtPlaka.Text = satır.Cells["plaka"].Value.ToString();
            comboBox1.Text = satır.Cells["marka"].Value.ToString();
            comboBox2.Text = satır.Cells["seri"].Value.ToString();
            txtModely.Text = satır.Cells["yil"].Value.ToString();
            txtRenk.Text = satır.Cells["renk"].Value.ToString();
            txtKm.Text = satır.Cells["km"].Value.ToString();
            comboBox3.Text = satır.Cells["yakit"].Value.ToString();
            txtKira.Text = satır.Cells["kiraucreti"].Value.ToString();
            pictureBox2.ImageLocation = satır.Cells["resim"].Value.ToString();

        }

        private void frmAraçListele_Load(object sender, EventArgs e)
        {
            YenileAraçlarListesi();
            
                comboAraçlar.SelectedIndex = 0;
            
        }

        private void YenileAraçlarListesi()
        {
            string cümle = "select *from araç";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox2.ImageLocation = openFileDialog1.FileName;
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            string cümle = "update araç set marka=@marka,seri=@seri,yil=@yil,renk=@renk,km=@km,yakit=@yakit,kiraucreti=@kiraucreti,resim=@resim,tarih=@tarih where plaka=@plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@plaka", txtPlaka.Text);
            komut2.Parameters.AddWithValue("@marka", comboBox1.Text);
            komut2.Parameters.AddWithValue("@seri", comboBox2.Text);
            komut2.Parameters.AddWithValue("@yil", txtModely.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenk.Text);
            komut2.Parameters.AddWithValue("@km", txtKm.Text);
            komut2.Parameters.AddWithValue("@yakit", comboBox3.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKira.Text));
            komut2.Parameters.AddWithValue("@resim", pictureBox2.ImageLocation);
            komut2.Parameters.AddWithValue("@durumu", " BOŞ ");
            komut2.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
            YenileAraçlarListesi();
            MessageBox.Show("Araç Bilgileri Güncellendi.");


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            string cümle = "delete from araç where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
            SqlCommand komut2 = new SqlCommand();
            arackiralama.ekle_sil_güncelle(komut2, cümle);
            comboBox2.Items.Clear();
            foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in Controls) if (item is ComboBox) item.Text = "";
            pictureBox2.ImageLocation = "";
            YenileAraçlarListesi();
            MessageBox.Show("Araç Bilgileri Silindi.");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox2.Items.Clear();
                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox2.Items.Add("Astra");
                    comboBox2.Items.Add("Adam");
                    comboBox2.Items.Add("Agila");
                    comboBox2.Items.Add("Ampera");
                    comboBox2.Items.Add("Ascona");
                    comboBox2.Items.Add("Calibra");
                    comboBox2.Items.Add("Cascada");
                    comboBox2.Items.Add("Corsa");
                    comboBox2.Items.Add("GT (Roadster)");
                    comboBox2.Items.Add("Insignia");
                    comboBox2.Items.Add("Tigra");
                    comboBox2.Items.Add("Vectra");
                    comboBox2.Items.Add("Zafira");
                    comboBox2.Items.Add("Meriva");
                    comboBox2.Items.Add("Senator");


                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    comboBox2.Items.Add("Clio");
                    comboBox2.Items.Add("Fluence");
                    comboBox2.Items.Add("Grand Espace");
                    comboBox2.Items.Add("Laguna");
                    comboBox2.Items.Add("Latitude");
                    comboBox2.Items.Add("Megane");
                    comboBox2.Items.Add("Scenic");
                    comboBox2.Items.Add("Symbol");
                    comboBox2.Items.Add("Talisman");
                    comboBox2.Items.Add("Twingo");
                    comboBox2.Items.Add("Twizy");
                    comboBox2.Items.Add("Vel Satis");
                    comboBox2.Items.Add("ZOE");


                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    comboBox2.Items.Add("Micra");
                    comboBox2.Items.Add("GT-R");
                    comboBox2.Items.Add("350 Z ");
                    comboBox2.Items.Add("Almera");
                    comboBox2.Items.Add("Altima");
                    comboBox2.Items.Add("Bluebird");
                    comboBox2.Items.Add("Note");
                    comboBox2.Items.Add("Primera");
                    comboBox2.Items.Add("Talisman");
                    comboBox2.Items.Add("Twingo");
                    comboBox2.Items.Add("Twizy");
                    comboBox2.Items.Add("Vel Satis");
                    comboBox2.Items.Add("ZOE");
                }
                else if (comboBox1.SelectedIndex == 3)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }
                else if (comboBox1.SelectedIndex == 1)
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void comboAraçlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboAraçlar.SelectedIndex==0)
                {
                    YenileAraçlarListesi();
                }
                if (comboAraçlar.SelectedIndex==1)
                {
                    string cümle = "select *from araç where durumu = 'BOS' ";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                    
                }
                if (comboAraçlar.SelectedIndex == 2)
                {
                    string cümle = "select *from araç where durumu = 'DOLU' ";
                    SqlDataAdapter adtr2 = new SqlDataAdapter();
                    dataGridView1.DataSource = arackiralama.listele(adtr2, cümle);
                    
                }
                
            }
            catch 
            {

                ;
            }
        }
    }
}
