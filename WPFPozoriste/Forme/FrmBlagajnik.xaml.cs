using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFPozoriste.Forme
{
    /// <summary>
    /// Interaction logic for FrmBlagajnik.xaml
    /// </summary>
    public partial class FrmBlagajnik : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmBlagajnik()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIme.Focus();
        }
        public FrmBlagajnik(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtIme.Focus();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void BtnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@Ime", SqlDbType.NVarChar).Value = txtIme.Text;
                cmd.Parameters.Add("@Prezime", SqlDbType.NVarChar).Value = txtPrezime.Text;
                cmd.Parameters.Add("@JMBG", SqlDbType.NVarChar).Value = txtJMBG.Text;
                cmd.Parameters.Add("@Adresa", SqlDbType.NVarChar).Value = txtAdresa.Text;
                cmd.Parameters.Add("@Grad", SqlDbType.NVarChar).Value = txtGrad.Text;
                cmd.Parameters.Add("@Kontakt", SqlDbType.NVarChar).Value = txtKontakt.Text;
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = txtUsername.Text;
                cmd.Parameters.Add("@Lozinka", SqlDbType.NVarChar).Value = txtLozinka.Text;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblBlagajnik
                                        set Ime=@Ime, Prezime=@Prezime, JMBG=@JMBG, Adresa=@Adresa,
                                            Grad=@Grad, Kontakt=@Kontakt, Username=@Username, Lozinka=@Lozinka
                                            where BlagajnikID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblBlagajnik(Ime,Prezime, JMBG, Adresa, Grad, Kontakt, Username, Lozinka)
                                    values(@Ime, @Prezime, @JMBG, @Adresa, @Grad, @Kontakt, @Username, @Lozinka)";
                }



                cmd.ExecuteNonQuery();
                cmd.Dispose();
                this.Close();
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih vrednosti nije validan", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void BtnOtkazi_Click(object sender, RoutedEventArgs e)
        {
                this.Close();
        }
    }
    
}
