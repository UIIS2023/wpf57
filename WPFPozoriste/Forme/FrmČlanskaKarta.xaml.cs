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
    /// Interaction logic for FrmČlanskaKarta.xaml
    /// </summary>
    public partial class FrmČlanskaKarta : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmČlanskaKarta()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtPopust.Focus();
            PopuniPadajuceListe();
        }

        public FrmČlanskaKarta(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtPopust.Focus();
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
                DataTable dtPosjetilac = new DataTable();
                daPosjetilac.Fill(dtPosjetilac);
                cbPosjetilac.ItemsSource = dtPosjetilac.DefaultView;
                daPosjetilac.Dispose();
                dtPosjetilac.Dispose();

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
                DateTime date = (DateTime)dpDatumPreuzimanja.SelectedDate;
                string datumPreuzimanja = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@Popust", SqlDbType.Decimal).Value = txtPopust.Text;
                cmd.Parameters.Add("@DatumPreuzimanja", SqlDbType.DateTime).Value = datumPreuzimanja;
                cmd.Parameters.Add("@PosjetilacID", SqlDbType.Int).Value = cbPosjetilac.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblČlanskaKarta
                                        set Popust=@Popust, DatumPreuzimanja=@DatumPreuzimanja, PosjetilacID=@PosjetilacID
                                            where ČlanskaKartaID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblČlanskaKarta(Popust, DatumPreuzimanja, PosjetilacID)
                                    values(@Popust, @DatumPreuzimanja, @PosjetilacID)";
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
