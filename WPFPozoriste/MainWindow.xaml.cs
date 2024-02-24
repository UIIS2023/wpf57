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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFPozoriste.Forme;

namespace WPFPozoriste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string ucitanaTabela;

        Konekcija kon = new Konekcija();
        SqlConnection konekcija = new SqlConnection();
        private bool azuriraj;
        private DataRowView red;
        #region Select upiti
        private static string blagajnikSelect = @"select BlagajnikID as ID, Ime as ime, Prezime as prezime, JMBG, Adresa, Grad, Kontakt, Username, Lozinka from tblBlagajnik";
        private static string činSelect = @"select ČinID as ID, NazivČina as 'Naziv čina', Naziv as 'Naziv predstave' from tblČin join tblPredstava on tblČin.PredstavaID=tblPredstava.PredstavaID";
        private static string članskaKartaSelect = @"select ČlanskaKartaID as ID, Popust, DatumPreuzimanja as 'Datum preuzimanja', ImePosjetioca as Posjetilac from tblČlanskaKarta join tblPosjetilac on tblČlanskaKarta.PosjetilacID=tblPosjetilac.PosjetilacID";
        private static string kartaSelect = @"select KartaID as ID, DatumKupovine as 'Datum kupovine', BrojSjedišta as 'Broj sjedišta', CijenaKarte as 'Cijena karte', ImePosjetioca as Posjetilac, Ime as Blagajnik,
                                            Naziv as predstava from tblKarta join tblPosjetilac on tblKarta.PosjetilacID=tblPosjetilac.PosjetilacID
                                            join tblBlagajnik on tblKarta.BlagajnikID=tblBlagajnik.BlagajnikID
                                            join tblPredstava on tblKarta.PredstavaID=tblPredstava.PredstavaID";
        private static string posjetilacSelect = @"select PosjetilacID as ID, ImePosjetioca as Ime, PrezimePosjetioca as Prezime, GradPosjetioca as Grad, 
                                                AdresaPosjetioca as Adresa, KontaktPosjetioca as Kontakt from tblPosjetilac";
        private static string predstavaSelect = @"select predstavaID as ID, Naziv as 'Naziv predstave', DatumPrikazivanja as 'Datum prikazivanja', VrijemeTrajanja as 'Vrijeme trajanja', NazivŽanra as Žanr,
                                                ImeProducenta as Producent from tblPredstava join tblŽanrPredstave on tblPredstava.ŽanrID=tblŽanrPredstave.ŽanrID
                                                join tblProducent on tblPredstava.ProducentID=tblProducent.ProducentID";
        private static string producentSelect = @"select ProducentID as ID, ImeProducenta as Ime, PrezimeProducenta as Prezime, KontaktProducenta as Kontakt from tblProducent";
        private static string rezervacijaSelect = @"select RezervacijaID as ID, DatumRezervacije as 'Datum Rezervacije', OtkazivanjeRezervacije as Otkazivanje, Ime as Blagajnik, Naziv as Predstava from tblRezervacija
                                                join tblBlagajnik on tblRezervacija.BlagajnikID=tblBlagajnik.BlagajnikID
                                                join tblPredstava on tblRezervacija.PredstavaID=tblPredstava.PredstavaID";
        private static string žanrSelect = @"select ŽanrID as ID, NazivŽanra as Naziv from tblŽanrPredstave";
        #endregion

        #region Select sa uslovom
        private static string selectUslovBlagajnik = @"select * from tblBlagajnik where BlagajnikID=";
        private static string selectUslovČin = @"select * from tblČin where ČinID=";
        private static string selectUslovČlanskaKarta = @"select * from tblČlanskaKarta where ČlanskaKartaID=";
        private static string selectUslovKarta = @"select * from tblKarta where KartaID=";
        private static string selectUslovPosjetilac = @"select * from tblPosjetilac where PosjetilacID=";
        private static string selectUslovPredstava= @"select * from tblPredstava where PredstavaID=";
        private static string selectUslovProducent= @"select * from tblProducent where ProducentID=";
        private static string selectUslovRezervacija = @"select * from tblRezervacija where RezervacijaID=";
        private static string selectUslovŽanr = @"select * from tblŽanrPredstave where ŽanrID=";
        #endregion

        #region Delete upiti
        private static string blagajnikDelete = @"delete from tblBlagajnik where BlagajnikID=";
        private static string činDelete = @"delete from tblČin where ČinID=";
        private static string članskaKartaDelete = @"delete from tblČlanskaKarta where ČlanskaKartaID=";
        private static string kartaDelete = @"delete from tblKarta where KartaID=";
        private static string posjetilacDelete = @"delete from tblPosjetilac where PosjetilacID=";
        private static string predstavaDelete = @"delete from tblPredstava where PredstavaID=";
        private static string producentDelete = @"delete from tblProducent where ProducentID=";
        private static string rezervacijaDelete = @"delete from tblRezervacija where RezervacijaID=";
        private static string žanrDelete = @"delete from tblŽanrPredstave where ŽanrID=";
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            konekcija = kon.KreirajKonekciju();
            UcitajPodatke(blagajnikSelect);
        }

        private void UcitajPodatke(string selectUpit)
        {
            try
            {
                konekcija.Open();
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectUpit, konekcija);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataGridCentralni != null)
                {
                    dataGridCentralni.ItemsSource = dataTable.DefaultView;
                }
                ucitanaTabela = selectUpit;
                dataAdapter.Dispose();
                dataTable.Dispose();
            }
            catch (SqlException)
            {
                MessageBox.Show("Neuspešno učitani podaci", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
            }
        }

        private void BtnBlagajnik_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(blagajnikSelect);
        }

        private void BtnCin_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(činSelect);
        }

        private void BtnClanskaKarta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(članskaKartaSelect);
        }

        private void BtnKarta_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(kartaSelect);
        }

        private void BtnPosjetilac_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(posjetilacSelect);
        }

        private void BtnPredstava_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(predstavaSelect);
        }

        private void BtnProducent_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(producentSelect);
        }

        private void BtnRezervacija_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(rezervacijaSelect);
        }

        private void BtnZanrPredstave_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatke(žanrSelect);
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            {
                Window prozor;
                if (ucitanaTabela.Equals(blagajnikSelect))
                {
                    prozor = new FrmBlagajnik();
                    prozor.ShowDialog();
                    UcitajPodatke(blagajnikSelect);
                }
                else if (ucitanaTabela.Equals(činSelect))
                {
                    prozor = new FrmČin();
                    prozor.ShowDialog();
                    UcitajPodatke(činSelect);
                }
                else if (ucitanaTabela.Equals(članskaKartaSelect))
                {
                    prozor = new FrmČlanskaKarta();
                    prozor.ShowDialog();
                    UcitajPodatke(članskaKartaSelect);
                }
                else if (ucitanaTabela.Equals(kartaSelect))
                {
                    prozor = new FrmKarta();
                    prozor.ShowDialog();
                    UcitajPodatke(kartaSelect);
                }
                else if (ucitanaTabela.Equals(posjetilacSelect))
                {
                    prozor = new FrmPosjetilac();
                    prozor.ShowDialog();
                    UcitajPodatke(posjetilacSelect);
                }
                else if (ucitanaTabela.Equals(predstavaSelect))
                {
                    prozor = new FrmPredstava();
                    prozor.ShowDialog();
                    UcitajPodatke(predstavaSelect);
                }
                else if (ucitanaTabela.Equals(producentSelect))
                {
                    prozor = new FrmProducent();
                    prozor.ShowDialog();
                    UcitajPodatke(producentSelect);
                }
                else if (ucitanaTabela.Equals(rezervacijaSelect))
                {
                    prozor = new FrmRezervacija();
                    prozor.ShowDialog();
                    UcitajPodatke(rezervacijaSelect);
                }
                else if (ucitanaTabela.Equals(žanrSelect))
                {
                    prozor = new FrmŽanrPredstave();
                    prozor.ShowDialog();
                    UcitajPodatke(žanrSelect);
                }
            }
        }

        private void BtnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (ucitanaTabela.Equals(blagajnikSelect))
            {
                PopuniFormu(selectUslovBlagajnik);
                UcitajPodatke(blagajnikSelect);
            }
            else if (ucitanaTabela.Equals(činSelect))
            {
                PopuniFormu(selectUslovČin);
                UcitajPodatke(činSelect);
            }
            else if (ucitanaTabela.Equals(članskaKartaSelect))
            {
                PopuniFormu(selectUslovČlanskaKarta);
                UcitajPodatke(članskaKartaSelect);
            }
            else if (ucitanaTabela.Equals(kartaSelect))
            {
                PopuniFormu(selectUslovKarta); ;
                UcitajPodatke(kartaSelect);
            }
            else if (ucitanaTabela.Equals(posjetilacSelect))
            {
                PopuniFormu(selectUslovPosjetilac);
                UcitajPodatke(posjetilacSelect);
            }
            else if (ucitanaTabela.Equals(predstavaSelect))
            {
                PopuniFormu(selectUslovPredstava);
                UcitajPodatke(predstavaSelect);
            }
            else if (ucitanaTabela.Equals(producentSelect))
            {
                PopuniFormu(selectUslovProducent);
                UcitajPodatke(producentSelect);
            }
            else if (ucitanaTabela.Equals(rezervacijaSelect))
            {
                PopuniFormu(selectUslovRezervacija);
                UcitajPodatke(rezervacijaSelect);
            }
            else if (ucitanaTabela.Equals(žanrSelect))
            {
                PopuniFormu(selectUslovŽanr);
                UcitajPodatke(žanrSelect);
            }
        }

        private void PopuniFormu(string selectUslov)
        {
            try
            {
                konekcija.Open();
                azuriraj = true;
                red = (DataRowView)dataGridCentralni.SelectedItems[0];
                SqlCommand cmd = new SqlCommand
                {
                    Connection = konekcija
                };
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                cmd.CommandText = selectUslov + "@id";
                SqlDataReader citac = cmd.ExecuteReader();
                if (citac.Read())
                {
                    if (ucitanaTabela.Equals(blagajnikSelect))
                    {
                        FrmBlagajnik prozorBlagajnik = new FrmBlagajnik(azuriraj, red);
                        prozorBlagajnik.txtIme.Text = citac["Ime"].ToString();
                        prozorBlagajnik.txtPrezime.Text = citac["Prezime"].ToString();
                        prozorBlagajnik.txtJMBG.Text = citac["JMBG"].ToString();
                        prozorBlagajnik.txtAdresa.Text = citac["Adresa"].ToString();
                        prozorBlagajnik.txtGrad.Text = citac["Grad"].ToString();
                        prozorBlagajnik.txtKontakt.Text = citac["Kontakt"].ToString();
                        prozorBlagajnik.txtUsername.Text = citac["Username"].ToString();
                        prozorBlagajnik.txtLozinka.Text = citac["Lozinka"].ToString();
                        prozorBlagajnik.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(činSelect))
                    {
                        FrmČin prozorČin = new FrmČin(azuriraj, red);
                        prozorČin.txtNazivCina.Text = citac["NazivČina"].ToString();
                        prozorČin.cbPredstava.SelectedValue = citac["PredstavaID"].ToString();
                        prozorČin.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(članskaKartaSelect))
                    {
                        FrmČlanskaKarta prozorČlanskaKarta = new FrmČlanskaKarta(azuriraj, red);
                        prozorČlanskaKarta.txtPopust.Text = citac["Popust"].ToString();
                        prozorČlanskaKarta.dpDatumPreuzimanja.SelectedDate = (DateTime)citac["DatumPreuzimanja"];
                        prozorČlanskaKarta.cbPosjetilac.SelectedValue = citac["PosjetilacID"].ToString();
                        prozorČlanskaKarta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(kartaSelect))
                    {
                        FrmKarta prozorKarta = new FrmKarta(azuriraj, red);
                        prozorKarta.dpDatumKupovine.SelectedDate = (DateTime)citac["DatumKupovine"];
                        prozorKarta.txtBrojSjedišta.Text = citac["BrojSjedišta"].ToString();
                        prozorKarta.txtCijenaKarte.Text = citac["CijenaKarte"].ToString();
                        prozorKarta.cbPosjetilac.SelectedValue = citac["PosjetilacID"].ToString();
                        prozorKarta.cbBlagajnik.SelectedValue = citac["BlagajnikID"].ToString();
                        prozorKarta.cbPredstava.SelectedValue = citac["PredstavaID"].ToString();
                        prozorKarta.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(posjetilacSelect))
                    {
                        FrmPosjetilac prozorPosjetilac = new FrmPosjetilac(azuriraj, red);
                        prozorPosjetilac.txtImePosjetioca.Text = citac["ImePosjetioca"].ToString();
                        prozorPosjetilac.txtPrezimePosjetioca.Text = citac["PrezimePosjetioca"].ToString();
                        prozorPosjetilac.txtGradPosjetioca.Text = citac["GradPosjetioca"].ToString();
                        prozorPosjetilac.txtAdresaPosjetioca.Text = citac["AdresaPosjetioca"].ToString();
                        prozorPosjetilac.txtKontaktPosjetioca.Text = citac["KontaktPosjetioca"].ToString();
                        prozorPosjetilac.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(predstavaSelect))
                    {
                        FrmPredstava prozorPredstava = new FrmPredstava(azuriraj, red);
                        prozorPredstava.txtNazivPredstave.Text = citac["Naziv"].ToString();
                        prozorPredstava.dpDatumPrikazivanja.SelectedDate = (DateTime)citac["DatumPrikazivanja"];
                        prozorPredstava.txtVrijemeTrajanja.Text = citac["VrijemeTrajanja"].ToString();
                        prozorPredstava.cbZanr.SelectedValue = citac["ŽanrID"].ToString();
                        prozorPredstava.cbProducent.SelectedValue = citac["ProducentID"].ToString();
                        prozorPredstava.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(producentSelect))
                    {
                        FrmProducent prozorProducent = new FrmProducent(azuriraj, red);
                        prozorProducent.txtImeProducenta.Text = citac["ImeProducenta"].ToString();
                        prozorProducent.txtPrezimeProducenta.Text = citac["PrezimeProducenta"].ToString();
                        prozorProducent.txtKontaktProducenta.Text = citac["KontaktProducenta"].ToString();
                        prozorProducent.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(rezervacijaSelect))
                    {
                        FrmRezervacija prozorRezervacija = new FrmRezervacija(azuriraj, red);
                        prozorRezervacija.dpDatumRezervacije.SelectedDate = (DateTime)citac["DatumRezervacije"];
                        prozorRezervacija.cbxOtkazivanje.IsChecked = (bool)citac["OtkazivanjeRezervacije"];
                        prozorRezervacija.cbBlagajnik.SelectedValue = citac["BlagajnikID"].ToString();
                        prozorRezervacija.CbPredstava.SelectedValue = citac["PredstavaID"].ToString();
                        prozorRezervacija.ShowDialog();
                    }
                    else if (ucitanaTabela.Equals(žanrSelect))
                    {
                        FrmŽanrPredstave prozorŽanr = new FrmŽanrPredstave(azuriraj, red);
                        prozorŽanr.txtNazivZanra.Text = citac["NazivŽanra"].ToString();
                        prozorŽanr.ShowDialog();
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali red!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();
                }
                azuriraj = false;
            }
        }

        private void BtnObrisi_Click(object sender, RoutedEventArgs e)
        {
            
                if (ucitanaTabela.Equals(blagajnikSelect))
                {
                    ObrisiZapis(blagajnikDelete);
                    UcitajPodatke(blagajnikSelect);
                }
                else if (ucitanaTabela.Equals(činSelect))
                {
                    ObrisiZapis(činDelete);
                    UcitajPodatke(činSelect);
                }
                else if (ucitanaTabela.Equals(članskaKartaSelect))
                {
                    ObrisiZapis(članskaKartaDelete);
                    UcitajPodatke(članskaKartaSelect);
                }
                else if (ucitanaTabela.Equals(kartaSelect))
                {
                    ObrisiZapis(kartaDelete); ;
                    UcitajPodatke(kartaSelect);
                }
                else if (ucitanaTabela.Equals(posjetilacSelect))
                {
                    ObrisiZapis(posjetilacDelete); ;
                    UcitajPodatke(posjetilacSelect);
                }
                else if (ucitanaTabela.Equals(predstavaSelect))
                {
                    ObrisiZapis(predstavaDelete);
                    UcitajPodatke(predstavaSelect);
                }
                else if (ucitanaTabela.Equals(producentSelect))
                {
                    ObrisiZapis(producentDelete);
                    UcitajPodatke(producentSelect);
                }
                else if (ucitanaTabela.Equals(rezervacijaSelect))
                {
                    ObrisiZapis(rezervacijaDelete);
                    UcitajPodatke(rezervacijaSelect);
                }
                else if (ucitanaTabela.Equals(žanrSelect))
                {
                    ObrisiZapis(žanrDelete);
                    UcitajPodatke(žanrSelect);
                }
        }

          private  void ObrisiZapis(string deleteUpit)
          {
                try
                {
                    konekcija.Open();
                    red = (DataRowView)dataGridCentralni.SelectedItems[0];
                    MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni?", "Upozorenje", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (rezultat == MessageBoxResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand
                        {
                            Connection = konekcija
                        };
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = red["ID"];
                        cmd.CommandText = deleteUpit + "@id";
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Niste selektovali red!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (SqlException)
                {
                    MessageBox.Show("Postoje povezani podaci u drugim tabelama!", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    if (konekcija != null)
                    {
                        konekcija.Close();
                    }
                }
          }
    }
}
    

