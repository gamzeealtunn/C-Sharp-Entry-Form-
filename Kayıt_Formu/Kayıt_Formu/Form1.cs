using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kayıt_Formu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //listView1.Columns.Add("TC Kimlik No", 150);
            //listView1.Columns.Add("Adı Soyadı", 200);
            //listView1.Columns.Add("Yaşı", 50);
            //listView1.Columns.Add("Mezuniyet Bilgisi", 150);
            //listView1.Columns.Add("Cinsiyeti", 125);
            //listView1.Columns.Add("Doğum Yeri", 125);
            //listView1.Columns.Add("Telefon No", 130);

            string[] mezuniyet = { "İlköğretim", "Ortaöğretim", "Lise", "Lisans", "Yüksek Lisans", "Doktora" };
            comboBox1.Items.AddRange(mezuniyet);

            kayitsayisiyaz();

        }

        private void kayitsayisiyaz()
        {
            int kayitsayisi = listView1.Items.Count;
            label8.Text = Convert.ToString(kayitsayisi);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string tc = "", adsoyad = "", yas = "", mezuniyet = "", cinsiyet = "", dogumyeri = "", telno = "";
            tc = textBox1.Text;
            adsoyad = textBox2.Text;
            yas = textBox3.Text;
            mezuniyet = comboBox1.Text;
            dogumyeri = textBox4.Text;
            telno = textBox5.Text;

            if (radioButton1.Checked == true)
            {
                cinsiyet = radioButton1.Text;
            }
            else if (radioButton2.Checked == true)
            {
                cinsiyet = radioButton2.Text;
            }

            string[] bilgiler = { tc, adsoyad, yas, mezuniyet, cinsiyet, dogumyeri, telno };
            bool aranankayitkontrolu = false;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    aranankayitkontrolu = true;
                    MessageBox.Show(textBox1.Text + "TC Kimlik Numarası Kayıtlarda Mevcut");
                }
            }

            if (aranankayitkontrolu == false)
            {
                ListViewItem list = new ListViewItem(bilgiler);
                if (tc != "" && adsoyad != "" && mezuniyet != "" && cinsiyet != "" && yas != "" && dogumyeri != "" && telno != "")
                {
                    listView1.Items.Add(list);
                }
                else
                {
                    MessageBox.Show("Kayıt Bilgilerinde Eksiklik Var");
                    kayitsayisiyaz();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int secilen_sayisi = listView1.CheckedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.CheckedItems)
            {
                secilikayitbilgisi.Remove();
            }
            MessageBox.Show(secilen_sayisi.ToString() + "Adet Kayıt Silindi");
            kayitsayisiyaz();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int secilen_sayisi = listView1.SelectedItems.Count;
            foreach (ListViewItem secilikayitbilgisi in listView1.SelectedItems)
            {
                secilikayitbilgisi.Remove();
            }

            MessageBox.Show(secilen_sayisi.ToString() + "Adet Kayıt Silindi");
            kayitsayisiyaz();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            kayitsayisiyaz();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool aranankayitkontrol = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    aranankayitkontrol = true;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text = listView1.Items[i].SubItems[2].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[3].Text;

                    if (listView1.Items[i].SubItems[4].Text == "Kadın")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[4].Text == "Erkek")
                    {
                        radioButton2.Checked = true;
                    }
                    textBox4.Text = listView1.Items[i].SubItems[5].Text;
                    textBox5.Text = listView1.Items[i].SubItems[6].Text;

                }
            }
            if (aranankayitkontrol == false)
            {
                MessageBox.Show(textBox1.Text + "TC Kimlik Numaralı Kayıt Bulunamadı");
            }
        }
    }
}

