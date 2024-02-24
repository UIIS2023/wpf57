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
    /// Interaction logic for FrmProducent.xaml
    /// </summary>
    public partial class FrmProducent : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmProducent()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeProducenta.Focus();
        }

        public FrmProducent(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImeProducenta.Focus();
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
                cmd.Parameters.Add("@ImeProducenta", SqlDbType.NVarChar).Value = txtImeProducenta.Text;
                cmd.Parameters.Add("@PrezimeProducenta", SqlDbType.NVarChar).Value = txtPrezimeProducenta.Text;
                cmd.Parameters.Add("@KontaktProducenta", SqlDbType.NVarChar).Value = txtKontaktProducenta.Text;
                
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblProducent
                                        set ImeProducenta=@ImeProducenta, PrezimeProducenta=@PrezimeProducenta,
                                             KontaktProducenta=@KontaktProducenta, 
                                            where ProducentID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblProducent(ImeProducenta, PrezimeProducenta, KontaktProducenta)
                                    values(@ImeProducenta, @PrezimeProducenta, @KontaktProducenta)";
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
