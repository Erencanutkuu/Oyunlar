using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace adamasmacayeni1
{
    public partial class Form1 : Form
    {
        private List<string> sehirler;
        private string secilenSehir;
        private int kalanHak;
        private List<char> tahminEdilenHarfler;
        private List<Label> labelHarfler;
        private PictureBox pbResim; // Resim göstermek için PictureBox

        public Form1()
        {
            InitializeComponent();
            labelHarfler = new List<Label>();
            pbResim = new PictureBox
            {
                Location = new System.Drawing.Point(50, 150), // Resim için yer
                Size = new System.Drawing.Size(200, 200), // Resim boyutu
                SizeMode = PictureBoxSizeMode.StretchImage // Resmi boyutlandırma
            };
            this.Controls.Add(pbResim); // Form'a PictureBox ekle
            YeniOyun();
        }

        private void YeniOyun()
        {
            sehirler = new List<string>
            {
                "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray",
                "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin",
                "Balıkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu",
                "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum",
                "Denizli", "Diyarbakır", "Edirne", "Elazığ", "Erzincan",
                "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
                "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul",
                "İzmir", "Kars", "Kastamonu", "Kayseri", "Kırıkkale",
                "Kırklareli", "Kırşehir", "Kocaeli", "Konya", "Kütahya",
                "Malatya", "Manisa", "Mardin", "Mersin", "Muğla",
                "Muş", "Nevşehir", "Niğde", "Ordu", "Rize",
                "Sakarya", "Samsun", "Sinop", "Sivas", "Tekirdağ",
                "Tokat", "Trabzon", "Tunceli", "Şanlıurfa", "Uşak",
                "Van", "Yalova", "Yozgat", "Zonguldak"
            };

            Random random = new Random();
            int rastgeleIndex = random.Next(sehirler.Count);
            secilenSehir = sehirler[rastgeleIndex].ToUpper();

            for (int i = 0; i < labelHarfler.Count; i++)
            {
                this.Controls.Remove(labelHarfler[i]);
            }
            labelHarfler.Clear();

            for (int i = 0; i < secilenSehir.Length; i++)
            {
                Label labelHarf = new Label
                {
                    Text = "_",
                    AutoSize = true,
                    Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold),
                    Location = new System.Drawing.Point(50 + (i * 30), 100)
                };
                labelHarfler.Add(labelHarf);
                this.Controls.Add(labelHarf);
            }

            kalanHak = 6;
            tahminEdilenHarfler = new List<char>();
            lblKalanHak.Text = "Kalan Hak: " + kalanHak;
            lblMesaj.Text = "Oyuna başlamak için bir harf tahmin edin.";
            txtHarf.Clear();
            btnTahminEt.Enabled = true;

            // İlk resim gösterimi
         
        }

        private void btnTahminEt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHarf.Text) || txtHarf.Text.Length > 1)
            {
                lblMesaj.Text = "Lütfen sadece bir harf girin.";
                return;
            }

            char tahmin = txtHarf.Text.ToUpper()[0];

            if (tahminEdilenHarfler.Contains(tahmin))
            {
                lblMesaj.Text = "Bu harfi zaten tahmin ettiniz!";
                return;
            }

            tahminEdilenHarfler.Add(tahmin);

            if (secilenSehir.Contains(tahmin))
            {
                lblMesaj.Text = "Doğru tahmin!";

                for (int i = 0; i < secilenSehir.Length; i++)
                {
                    if (secilenSehir[i] == tahmin)
                    {
                        labelHarfler[i].Text = tahmin.ToString();
                    }
                }

                if (!labelHarfler.Any(lbl => lbl.Text == "_"))
                {
                    lblMesaj.Text = "Tebrikler, şehri doğru tahmin ettiniz: " + secilenSehir;
                    btnTahminEt.Enabled = false;
                }
            }
            else
            {
                kalanHak--;
                lblKalanHak.Text = "Kalan Hak: " + kalanHak;
                lblMesaj.Text = "Yanlış tahmin!";
                GüncelleResim(); // Resmi güncelle

                if (kalanHak == 0)
                {
                    lblMesaj.Text = "Kaybettiniz! Doğru şehir: " + secilenSehir;
                    btnTahminEt.Enabled = false;
                }
            }

            txtHarf.Clear();
        }

        private void GüncelleResim()
        {
            // Kalan hak sayısına göre resmi güncelle
            switch (kalanHak)
            {
                case 5:
                    pbResim.Image = Properties.Resources.adam1;
                    break;
                case 4:
                    pbResim.Image = Properties.Resources.adam2;
                    break;
                case 3:
                    pbResim.Image = Properties.Resources.adam3;
                    break;
                case 2:
                    pbResim.Image = Properties.Resources.adam4;
                    break;
                case 1:
                    pbResim.Image = Properties.Resources.adam5;
                    break;
                case 0:
                    pbResim.Image = Properties.Resources.adam6;
                    break;
            }
        }
    }
}
