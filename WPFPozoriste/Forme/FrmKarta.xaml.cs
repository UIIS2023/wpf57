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
    /// Interaction logic for FrmKarta.xaml
    /// </summary>
    public partial class FrmKarta : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmKarta()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtBrojSjedišta.Focus();
            PopuniPadajuceListe();
        }
        public FrmKarta(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtBrojSjedišta.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiPosjetioca = @"select PosjetilacID, ImePosjetioca as Posjetilac from tblPosjetilac";
                SqlDataAdapter daPosjetilac = new SqlDataAdapter(vratiPosjetioca, konekcija);
                DataTable dtPosjetilac= new DataTable();
                daPosjetilac.Fill(dtPosjetilac);
                cbPosjetilac.ItemsSource = dtPosjetilac.DefaultView;
                daPosjetilac.Dispose();
                dtPosjetilac.Dispose();

                string vratiBlagajnika = @"select BlagajnikID, Ime as Blagajnik from tblBlagajnik";
                SqlDataAdapter daBlagajnik = new SqlDataAdapter(vratiBlagajnika, konekcija);
                DataTable dtBlagajnik = new DataTable();
                daBlagajnik.Fill(dtBlagajnik);
                cbBlagajnik.ItemsSource = dtBlagajnik.DefaultView;
                daBlagajnik.Dispose();
                dtBlagajnik.Dispose();

                string vratiPredstavu = @"select PredstavaID, Naziv from tblPredstava";
                SqlDataAdapter daPredstava = new SqlDataAdapter(vratiPredstavu, konekcija);
                DataTable dtPredstava = new DataTable();
                daPredstava.Fill(dtPredstava);
                cbPredstava.ItemsSource = dtPredstava.DefaultView;
                daPredstava.Dispose();
                dtPredstava.Dispose();
              
            }
            catch (SqlException)
            {
                MessageBox.Show("Padajuce liste nisu popunjene", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }

        }

        private void BtnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();
                DateTime date = (DateTime)dpDatumKupovine.SelectedDate;
                string datumKupovine = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@BrojSjedišta", SqlDbType.Int).Value = txtBrojSjedišta.Text;
                cmd.Parameters.Add("@DatumKupovine", SqlDbType.DateTime).Value = datumKupovine;
                cmd.Parameters.Add("@CijenaKarte", SqlDbType.Int).Value = txtCijenaKarte.Text;
                cmd.Parameters.Add("@PosjetilacID", SqlDbType.Int).Value = cbPosjetilac.SelectedValue;
                cmd.Parameters.Add("@BlagajnikID", SqlDbType.Int).Value = cbBlagajnik.SelectedValue;
                cmd.Parameters.Add("@PredstavaID", SqlDbType.Int).Value = cbPredstava.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblKarta
                                        set BrojSjedišta=@BrojSjedišta, DatumKupovine=@DatumKupovine, CijenaKarte=@CijenaKarte,
                                        PosjetilacID=@PosjetilacID, BlagajnikID=@BlagajnikID, PredstavaID=@PredstavaID
                                            where KartaID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblKarta(BrojSjedišta, DatumKupovine, CijenaKarte, PosjetilacID, BlagajnikID, PredstavaID)
                                    values(@BrojSjedišta, @DatumKupovine, @CijenaKarte, @PosjetilacID, @BlagajnikID, @PredstavaID)";
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
