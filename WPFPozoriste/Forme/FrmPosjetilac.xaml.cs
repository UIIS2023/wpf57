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
    /// Interaction logic for FrmPosjetilac.xaml
    /// </summary>
    public partial class FrmPosjetilac : Window
    {
        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;

        public FrmPosjetilac()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImePosjetioca.Focus();
        }
        public FrmPosjetilac(bool azuriraj, DataRowView red)
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            txtImePosjetioca.Focus();
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
                cmd.Parameters.Add("@ImePosjetioca", SqlDbType.NVarChar).Value = txtImePosjetioca.Text;
                cmd.Parameters.Add("@PrezimePosjetioca", SqlDbType.NVarChar).Value = txtPrezimePosjetioca.Text;
                cmd.Parameters.Add("@GradPosjetioca", SqlDbType.NVarChar).Value = txtGradPosjetioca.Text;
                cmd.Parameters.Add("@AdresaPosjetioca", SqlDbType.NVarChar).Value = txtAdresaPosjetioca.Text;
                cmd.Parameters.Add("@KontaktPosjetioca", SqlDbType.NVarChar).Value = txtKontaktPosjetioca.Text;
                
                if (azuriraj)
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];

                    cmd.CommandText = @"update tblPosjetilac
                                        set ImePosjetioca=@ImePosjetioca, PrezimePosjetioca=@PrezimePosjetioca, 
                                            GradPosjetioca=@GradPosjetioca, AdresaPosjetioca=@AdresaPosjetioca, KontaktPosjetioca=@KontaktPosjetioca
                                            where PosjetilacID=@id";

                    red = null;
                }
                else
                {
                    cmd.CommandText = @"insert into tblPosjetilac(ImePosjetioca, PrezimePosjetioca, GradPosjetioca, AdresaPosjetioca, KontaktPosjetioca,)
                                    values(@ImePosjetioca, @PrezimePosjetioca, @GradPosjetioca, @AdresaPosjetioca, @KontaktPosjetioca)";
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
