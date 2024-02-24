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
    /// Interaction logic for FrmPredstava.xaml
    /// </summary>
    public partial class FrmPredstava : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmPredstava()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivPredstave.Focus();
            PopuniPadajuceListe();
        }

        public FrmPredstava(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivPredstave.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

                string vratiŽanr = @"select ŽanrID, NazivŽanra as Žanr from tblŽanrPredstave";
                SqlDataAdapter daŽanr = new SqlDataAdapter(vratiŽanr, konekcija);
                DataTable dtŽanr = new DataTable();
                daŽanr.Fill(dtŽanr);
                cbZanr.ItemsSource = dtŽanr.DefaultView;
                daŽanr.Dispose();
                dtŽanr.Dispose();

                string vratiProducenta = @"select ProducentID, ImeProducenta as Producent from tblProducent";
                SqlDataAdapter daProducent = new SqlDataAdapter(vratiProducenta, konekcija);
                DataTable dtProducent = new DataTable();
                daProducent.Fill(dtProducent);
                cbProducent.ItemsSource = dtProducent.DefaultView;
                daProducent.Dispose();
                dtProducent.Dispose();

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
                DateTime date = (DateTime)dpDatumPrikazivanja.SelectedDate;
                string datumPrikazivanja = date.ToString("yyyy-MM-dd");
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@Naziv", SqlDbType.NVarChar).Value = txtNazivPredstave.Text;
                cmd.Parameters.Add("@DatumPrikazivanja", SqlDbType.DateTime).Value = datumPrikazivanja;
                cmd.Parameters.Add("@VrijemeTrajanja", SqlDbType.NVarChar).Value = txtVrijemeTrajanja.Text;
                cmd.Parameters.Add("@ŽanrID", SqlDbType.Int).Value = cbZanr.SelectedValue;
                cmd.Parameters.Add("@ProducentID", SqlDbType.Int).Value = cbProducent.SelectedValue;
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblPredstava
                                        set Naziv=@Naziv, DatumPrikazivanja=@DatumPrikazivanja, VrijemeTrajanja=@VrijemeTrajanja,
                                        ŽanrID=@ŽanrID, ProducentID=@ProducentID
                                            where PredstavaID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblPredstava(Naziv, DatumPrikazivanja, VrijemeTrajanja, ŽanrID, ProducentID)
                                    values(@Naziv, @DatumPrikazivanja, @VrijemeTrajanja, @ŽanrID, @ProducentID)";
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
