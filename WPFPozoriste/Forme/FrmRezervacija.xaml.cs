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
    /// Interaction logic for FrmRezervacija.xaml
    /// </summary>
    public partial class FrmRezervacija : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmRezervacija()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            dpDatumRezervacije.Focus();
            PopuniPadajuceListe();
        }
        public FrmRezervacija(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            dpDatumRezervacije.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();


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
                CbPredstava.ItemsSource = dtPredstava.DefaultView;
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
                DateTime date = (DateTime)dpDatumRezervacije.SelectedDate;
                string DatumRezervacije = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
             
                cmd.Parameters.Add("@DatumRezervacije", SqlDbType.DateTime).Value = DatumRezervacije;
                cmd.Parameters.Add("@OtkazivanjeRezervacije", SqlDbType.Bit).Value = Convert.ToInt32(cbxOtkazivanje.IsChecked);
                cmd.Parameters.Add("@BlagajnikID", SqlDbType.Int).Value = cbBlagajnik.SelectedValue;
                cmd.Parameters.Add("@PredstavaID", SqlDbType.Int).Value = CbPredstava.SelectedValue;


                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblRezervacija
                                        set DatumRezervacije=@DatumRezervacije, OtkazivanjeRezervacije=@OtkazivanjeRezervacije, BlagajnikID=@BlagajnikID,
                                        PredstavaID=PredstavaID
                                            where RezervacijaID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblRezervacija(DatumRezervacije, OtkazivanjeRezervacije, BlagajnikID, PredstavaID)
                                    values(@DatumRezervacije, @OtkazivanjeRezervacije, @BlagajnikID, @PredstavaID)";
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
