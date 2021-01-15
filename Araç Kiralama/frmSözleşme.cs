using System;
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
    public partial class frmSözleşme : Form
    {
        public frmSözleşme()
        {
            InitializeComponent();
        }
        Araç_Kiralama arac = new Araç_Kiralama();

        private void frmSözleşme_Load(object sender, EventArgs e)
        {
            Boş_Araçlar();
            Yenile();
        }

        private void Boş_Araçlar()
        {
            string sorgu2 = " select *from araç where durumu ='BOS' ";
            arac.Boş_Araçlar(cbxAraclarSozlesme, sorgu2);
        }

        private void Yenile()
        {
            string sorgu3 = "select *from sözleşme";
            SqlDataAdapter adtr2 = new SqlDataAdapter();
            dataGridView1.DataSource = arac.listele(adtr2, sorgu3);
        }

        private void TxtTc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void cbxAraclarSozlesme_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select *from araç where plaka like '" + cbxAraclarSozlesme.SelectedItem + "'";
            arac.CombodanGetir(cbxAraclarSozlesme, txtMarkaSozlesme, txtSeriSozlesme, txtModelSozlesme, txtRenkSozlesme, sorgu2);
        }

        private void cbxKirasekli_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sorgu2 = "select *from araç where plaka like '" + cbxAraclarSozlesme.SelectedItem + "'";
            arac.Ucret_Hesapla(cbxKirasekli, txtKiras, sorgu2);
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            TimeSpan gun = DateTime.Parse(dateDonus.Text) - DateTime.Parse(dateCikis.Text);
            int gun2 = gun.Days;
            txtGuns.Text = gun2.ToString();
            txtTutars.Text = (gun2 * int.Parse(txtKiras.Text)).ToString();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();

        }

        private void Temizle()
        {
            dateCikis.Text = DateTime.Now.ToShortDateString();
            dateDonus.Text = DateTime.Now.ToShortTimeString();
            cbxAraclarSozlesme.Text = "";
            txtKiras.Text = "";
            txtGuns.Text = "";
            txtTutars.Text = "";
        }

        private void btnSozlesmeEkle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "insert into sözleşme(tc,adsoyad,telefon,ehliyetno,e_tarih,e_yer,plaka,marka,seri,yil,renk,kirasekli,kiraucreti,gun,tutar,ctarih,dtarih) values(@tc,@adsoyad,@telefon,@ehliyetno,@e_tarih,@e_yer,@plaka,@marka,@seri,@yil,@renk,@kirasekli,@kiraucreti,@gun,@tutar,@ctarih,@dtarih)";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc",txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad",txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno",txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih",txtE_tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer",txtE_Verilen.Text);
            komut2.Parameters.AddWithValue("@plaka",cbxAraclarSozlesme.Text);
            komut2.Parameters.AddWithValue("@marka",txtMarkaSozlesme.Text);
            komut2.Parameters.AddWithValue("@seri",txtSeriSozlesme.Text);
            komut2.Parameters.AddWithValue("@yil",txtModelSozlesme.Text);
            komut2.Parameters.AddWithValue("@renk",txtRenkSozlesme.Text);
            komut2.Parameters.AddWithValue("@kirasekli",cbxKirasekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiras.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGuns.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutars.Text));
            komut2.Parameters.AddWithValue("@ctarih",dateCikis.Text);
            komut2.Parameters.AddWithValue("@dtarih",dateDonus.Text);
            arac.ekle_sil_güncelle(komut2, sorgu2);
            
            string sorgu3 = "update araç set durumu ='DOLU' where plaka='" + cbxAraclarSozlesme.Text + "'";
            SqlCommand komut3 = new SqlCommand();
            arac.ekle_sil_güncelle(komut3, sorgu3);
            cbxAraclarSozlesme.Items.Clear();
            Boş_Araçlar();
            Yenile();

            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            cbxAraclarSozlesme.Text = " ";
            Temizle();
            MessageBox.Show("Sözleşme Eklendi");
            



        }

        private void btnSozlesmeGuncelle_Click(object sender, EventArgs e)
        {
            string sorgu2 = "update sözleşme set tc=@tc,adsoyad=@adsoyad ,telefon=@telefon,ehliyetno=@ehliyetno,e_tarih=@e_tarih,e_yer=@e_yer,marka=@marka,seri=@seri,yil=@yil,renk=@renk,kirasekli=@kirasekli,kiraucreti=@kiraucreti,gun=@gun,tutar=@tutar,ctarih=@ctarih,dtarih=@dtarih where plaka = @plaka";
            SqlCommand komut2 = new SqlCommand();
            komut2.Parameters.AddWithValue("@tc", txtTc.Text);
            komut2.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut2.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut2.Parameters.AddWithValue("@ehliyetno", txtE_No.Text);
            komut2.Parameters.AddWithValue("@e_tarih", txtE_tarih.Text);
            komut2.Parameters.AddWithValue("@e_yer", txtE_Verilen.Text);
            komut2.Parameters.AddWithValue("@plaka", cbxAraclarSozlesme.Text);
            komut2.Parameters.AddWithValue("@marka", txtMarkaSozlesme.Text);
            komut2.Parameters.AddWithValue("@seri", txtSeriSozlesme.Text);
            komut2.Parameters.AddWithValue("@yil", txtModelSozlesme.Text);
            komut2.Parameters.AddWithValue("@renk", txtRenkSozlesme.Text);
            komut2.Parameters.AddWithValue("@kirasekli", cbxKirasekli.Text);
            komut2.Parameters.AddWithValue("@kiraucreti", int.Parse(txtKiras.Text));
            komut2.Parameters.AddWithValue("@gun", int.Parse(txtGuns.Text));
            komut2.Parameters.AddWithValue("@tutar", int.Parse(txtTutars.Text));
            komut2.Parameters.AddWithValue("@ctarih", dateCikis.Text);
            komut2.Parameters.AddWithValue("@dtarih", dateDonus.Text);
            arac.ekle_sil_güncelle(komut2, sorgu2);
            cbxAraclarSozlesme.Items.Clear();
            Boş_Araçlar();
            Yenile();

            foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
            foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
            cbxAraclarSozlesme.Text = " ";
            Temizle();
            MessageBox.Show("Sözleşme Güncellendi");
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            if (txtTcAra.Text == " ") foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = " ";
            string sorgu2 = "select * from müşteri where tc like '" + txtTcAra.Text + "'";
            arac.Tc_Ara(txtTcAra,txtTc, txtAdSoyad, txtTelefon, sorgu2);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            txtTc.Text = satır.Cells[0].Value.ToString();
            txtAdSoyad.Text = satır.Cells[1].Value.ToString();
            txtTelefon.Text = satır.Cells[2].Value.ToString();
            txtE_No.Text = satır.Cells[3].Value.ToString();
            txtE_tarih.Text = satır.Cells[4].Value.ToString();
            txtE_Verilen.Text = satır.Cells[5].Value.ToString();
            cbxAraclarSozlesme.Text = satır.Cells[6].Value.ToString();
            txtMarkaSozlesme.Text = satır.Cells[7].Value.ToString();
            txtSeriSozlesme.Text = satır.Cells[8].Value.ToString();
            txtModelSozlesme.Text = satır.Cells[9].Value.ToString();
            txtRenkSozlesme.Text = satır.Cells[10].Value.ToString();
            cbxKirasekli.Text = satır.Cells[11].Value.ToString();
            txtKiras.Text = satır.Cells[12].Value.ToString();
            txtGuns.Text = satır.Cells[13].Value.ToString();
            txtTutars.Text = satır.Cells[14].Value.ToString();
            dateCikis.Text = satır.Cells[15].Value.ToString();
            dateDonus.Text = satır.Cells[16].Value.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satır = dataGridView1.CurrentRow;
            //Gün Farkı Hesapla
            DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime dönüş = DateTime.Parse(satır.Cells["dtarih"].Value.ToString());
            int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
            TimeSpan gunfarkı = bugün - dönüş;
            int _gunfarkı = gunfarkı.Days;
            int ucretfarkı;
            //Ücret Farkı Hesapla
            ucretfarkı = _gunfarkı * ucret;
            txtEkstra.Text = ucretfarkı.ToString();
            //Toplam Tutar Hesapla


        }

        private void btnAracTeslim_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtEkstra.Text)>=0 || int.Parse(txtEkstra.Text)<0)
            {
                DataGridViewRow satır = dataGridView1.CurrentRow;
                DateTime bugün = DateTime.Parse(DateTime.Now.ToShortDateString());
                int ucret = int.Parse(satır.Cells["kiraucreti"].Value.ToString());
                int tutar = int.Parse(satır.Cells["tutar"].Value.ToString());
                DateTime çıkış = DateTime.Parse(satır.Cells["ctarih"].Value.ToString());
                TimeSpan gun = bugün - çıkış;
                int _gun = gun.Days;
                int toplamtutar = _gun * ucret;
                //Toplam Tutar _gun ve ucret satış tablosuna aktarılacak
                string sorgu1 = "delete from sözleşme where plaka='" +satır.Cells["plaka"].Value.ToString()+"'";
                SqlCommand komut = new SqlCommand();
                arac.ekle_sil_güncelle(komut, sorgu1);
                string sorgu2 = "update araç set durumu = 'BOS' where plaka='" + satır.Cells["plaka"].Value.ToString() + "'";
                SqlCommand komut3 = new SqlCommand();
                arac.ekle_sil_güncelle(komut3, sorgu2);


                string sorgu3 = "insert into satış(tc,adsoyad,plaka,marka,seri,yil,renk,gun,fiyat,tutar,tarih1,tarih2) values(@tc,@adsoyad,@plaka,@marka,@seri,@yil,@renk,@gun,@fiyat,@tutar,@tarih1,@tarih2)";
                SqlCommand komut2 = new SqlCommand();
                komut2.Parameters.AddWithValue("@tc", satır.Cells["tc"].Value.ToString());
                komut2.Parameters.AddWithValue("@adsoyad", satır.Cells["adsoyad"].Value.ToString());

                komut2.Parameters.AddWithValue("@plaka", satır.Cells["plaka"].Value.ToString());
                komut2.Parameters.AddWithValue("@marka", satır.Cells["marka"].Value.ToString());
                komut2.Parameters.AddWithValue("@seri", satır.Cells["seri"].Value.ToString());
                komut2.Parameters.AddWithValue("@yil", satır.Cells["yil"].Value.ToString());
                komut2.Parameters.AddWithValue("@renk", satır.Cells["renk"].Value.ToString());
                komut2.Parameters.AddWithValue("@gun", _gun);
                komut2.Parameters.AddWithValue("@tutar", toplamtutar);
                komut2.Parameters.AddWithValue("@tarih1", satır.Cells["ctarih"].Value.ToString());
                komut2.Parameters.AddWithValue("@tarih2", DateTime.Now.ToShortDateString());
                komut2.Parameters.AddWithValue("@fiyat", ucret);
                arac.ekle_sil_güncelle(komut2, sorgu3);

                MessageBox.Show("Araç Teslim Edildi");
                cbxAraclarSozlesme.Text = "";
                cbxAraclarSozlesme.Items.Clear();
                Boş_Araçlar();
                Yenile();
                foreach (Control item in groupBox1.Controls) if (item is TextBox) item.Text = "";
                foreach (Control item in groupBox2.Controls) if (item is TextBox) item.Text = "";
                cbxAraclarSozlesme.Text = "";
                Temizle();

                txtEkstra.Text = " ";
            }
            else
            {
                MessageBox.Show("Lütfen Seçim Yapınız", "Uyarı");
            }
        }
    }

}