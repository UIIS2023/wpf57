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
    /// Interaction logic for FrmČin.xaml
    /// </summary>
    public partial class FrmČin : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmČin()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivCina.Focus();
            PopuniPadajuceListe();
        }
        public FrmČin(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtNazivCina.Focus();
            PopuniPadajuceListe();
            this.azuriraj = azuriraj;
            this.red = red;
        }

        private void PopuniPadajuceListe()
        {
            try
            {
                konekcija.Open();

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
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@NazivČina", SqlDbType.NVarChar).Value = txtNazivCina.Text;
                cmd.Parameters.Add("@PredstavaID", SqlDbType.Int).Value = cbPredstava.SelectedValue;

                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblČin
                                        set NazivČina=@NazivČina, PredstavaID=@PredstavaID
                                            where ČinID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblČin(NazivČina, PredstavaID)
                                    values(@NazivČina, @PredstavaID)";
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
