using System;
using projekt;
using System.Collections.Generic;
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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace projekcik
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Deklaracja zmiennej lot z klasy Podroze
        /// </summary>
        Podroze lot;

        /// <summary>
        /// Konstruktor nieparametryczny MainWindow inicjalizujący komponenty, przypisujący godzinę oraz datę w GUI, oraz zaznaczający pole z ubezpieczeniem
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            DateTime nowTime = DateTime.Now;
            lblTime.Content = nowTime.ToLongTimeString();

            DateTime nowDate = DateTime.Now;
            lblDate.Content = nowTime.ToLongDateString();

            chbUbezpieczenie.IsChecked = true;
        }

        /// <summary>
        /// Konstruktor parametryczny ustawiający wartość pola lot
        /// </summary>
        /// <param name="t">Podróż</param>
        public MainWindow(Podroze t) : this()
        {
            lot = t;
        }

        /// <summary>
        /// Metoda pozwalająca na wyjście z GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWyjście_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz wyjść ?", "System Biura Podróży", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Metoda pozwalająca na resetująca dane wprowadzone do formularza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetuj_Click(object sender, RoutedEventArgs e)
        {
            rtxtPodsumowanie.Document.Blocks.Clear();
            txtImie.Clear();
            txtNazwisko.Clear();
            txtAdres.Clear();
            txtKodPocztowy.Clear();
            txtTelefon.Clear();
            txtEmail.Clear();
            txtPESEL.Clear();

            lblSumaCzęściowa1.Content = "";
            lblPodatek1.Content = "";
            lblSuma1.Content = "";

            cmbWylot.Text = "";
            txtOsobyDorosle.Text = "";
            cmbCel.Text = "";
            txtIloscDzieci.Text = "";
            cmbBilet.Text = "";
            cmbKlasa.Text = "";

            chbBagaz.IsChecked = false;
            chbPrzelecianeMile.IsChecked = false;
            chbSpecjalnePotrzeby.IsChecked = false;
            chbUbezpieczenie.IsChecked = true;
        }

        /// <summary>
        /// Metoda umożliwiająca pobranie danych z formularza
        /// </summary>
        public void Dane()
        {
            lot.PESEL = txtPESEL.Text;
            lot.Imie = txtImie.Text;
            lot.Nazwisko = txtNazwisko.Text;
            lot.Adres = txtAdres.Text;
            lot.Email = txtEmail.Text;
            switch (cmbWylot.Text)
            {
                case "Okęcie(Warszawa)":
                    lot.Wylot = Lotniska.OkęcieWarszawa;
                    break;
                case "Balice (Kraków)":
                    lot.Wylot = Lotniska.BaliceKraków;
                    break;
                case "Rębiechowo (Gdańsk)":
                    lot.Wylot = Lotniska.RębiechowoGdańsk;
                    break;
                case "Pyrzowice (Katowice)":
                    lot.Wylot = Lotniska.PyrzowiceKatowice;
                    break;
                case "Strachowice (Wrocław)":
                    lot.Wylot = Lotniska.StrachowiceWrocław;
                    break;
                case "Modlin (Warszawa)":
                    lot.Wylot = Lotniska.ModlinWarszawa;
                    break;
                case "Ławica (Poznań)":
                    lot.Wylot = Lotniska.ŁawicaPoznań;
                    break;
                case "Jasionka (Rzeszów)":
                    lot.Wylot = Lotniska.JasionkaRzeszów;
                    break;
                case "Goleniów (Szczecin)":
                    lot.Wylot = Lotniska.GoleniówSzczecin;
                    break;
                case "Świdnik (Lublin)":
                    lot.Wylot = Lotniska.ŚwidnikLublin;
                    break;
                case "Szwederowo (Bydgoszcz)":
                    lot.Wylot = Lotniska.SzwederowoBydgoszcz;
                    break;
                case "Lublinek (Łódź)":
                    lot.Wylot = Lotniska.LublinekŁódź;
                    break;
                case "Szymany (Olsztyn)":
                    lot.Wylot = Lotniska.SzymanyOlsztyn;
                    break;
                case "Babimost (Zielona Góra)":
                    lot.Wylot = Lotniska.BabimostZielonaGóra;
                    break;
                case "Sadków (Radom)":
                    lot.Wylot = Lotniska.SadkówRadom;
                    break;
            }

            switch (cmbCel.Text)
            {
                case "Włochy - 7 dni na Krecie":
                    lot.CelPodrozy = cele.Włochy_Kreta;
                    break;
                case "Grecja - 5 dni na Zakynthos":
                    lot.CelPodrozy = cele.Grecja_Zakynthos;
                    break;
                case "Tunezja - 6 dni w Tunisie ":
                    lot.CelPodrozy = cele.Tunezja_Tunisie;
                    break;
                case "Wyspy Zielonego Przylądka - 4 dni w Praia-i ":
                    lot.CelPodrozy = cele.Wyspy_Zielonego_Przylądka_Praia;
                    break;
                case "Portugalia - 7 dni w Maderze ":
                    lot.CelPodrozy = cele.Portugalia_Maderze;
                    break;
                case "Egipt - 4 dni w Kairze ":
                    lot.CelPodrozy = cele.Egipt_Kairze;
                    break;
                case "Gruzja - 7 dni w Tbilisi ":
                    lot.CelPodrozy = cele.Gruzja_Tbilisi;
                    break;
                case "Tajlandia - 5 dni w Bangkoku ":
                    lot.CelPodrozy = cele.Tajlandia_Bangkoku;
                    break;
                case "Bułgaria - 7 dni w Sofii ":
                    lot.CelPodrozy = cele.Bułgaria_Sofia;
                    break;
            }
            

            switch (cmbKlasa.Text)
            {
                case "Ekonomiczna":
                    lot.Klasa = Klasy.ekonomiczna;
                    break;
                case "Biznesowa":
                    lot.Klasa = Klasy.biznesowa;
                    break;
                case "Pierwsza klasa":
                    lot.Klasa = Klasy.pierwszaKlasa;
                    break;
            }

            switch (cmbBilet.Text)
            {
                case "W jedną stronę":
                    lot.Bilet = Bilety.jednaStrona;
                    break;
                case "W obie strony":
                    lot.Bilet = Bilety.powrot;
                    break;
            }

            if ((bool)chbSpecjalnePotrzeby.IsChecked)
            {
                lot.SpecjalnePotrzeby = true;
            }
            else
            {
                lot.SpecjalnePotrzeby = false;
            }

            if ((bool)chbUbezpieczenie.IsChecked)
            {
                lot.Ubezpieczenie = true;
            }
            else
            {
                lot.Ubezpieczenie = false;
            }

            if ((bool)chbBagaz.IsChecked)
            {
                lot.DodatkowyBagaz = true;
            }
            else
            {
                lot.DodatkowyBagaz = false;
            }

            if ((bool)chbPrzelecianeMile.IsChecked)
            {
                lot.PrzelecianeKilometry = true;
            }
            else
            {
                lot.PrzelecianeKilometry = false;
            }
            
        }

        /// <summary>
        /// Metoda sprawdzająca poprawność wpisanych danych i wyrzucająca informacje o poprawie danych jeśli któraś z danych nie została wpisana poprawnie lub nie została wpisana wcale
        /// </summary>
        /// <returns>true jeśli dane zostały wprowadzone prawidłowo albo false jeśli zostały wprowadzone nieprawidłowo</returns>
        private bool SprawdzaniePoprawnosci()
        {
            if (txtImie.Text == "" || txtNazwisko.Text == "" || txtAdres.Text == "" || txtKodPocztowy.Text == "" || txtTelefon.Text == "" || txtEmail.Text == "" || cmbWylot.Text == "" || cmbCel.Text == "" || txtIloscDzieci.Text == "" || txtOsobyDorosle.Text == "" || cmbBilet.Text == "" || cmbKlasa.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("Wprowadź poprawnie wszystkie dane", "System Biura Podróży", MessageBoxButton.OK);
                if (result == MessageBoxResult.OK)
                {
                    return false;
                }
            }
            try
            {
                lot.KodPocztowy = txtKodPocztowy.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Podaj poprawny kod pocztowy", "Błąd wprowadzania", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            try
            {
                lot.Telefon = txtTelefon.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Podaj poprawny numer telefonu", "Błąd wprowadzania", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            try
            {
                lot.PESEL = txtPESEL.Text;
            }
            catch (Exception)
            {
                MessageBox.Show("Podaj poprawny PESEL", "Błąd wprowadzania", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            try
            {
                int dorosli = int.Parse(txtOsobyDorosle.Text);
                lot.Ilosc = dorosli;
                int dzieci = int.Parse(txtIloscDzieci.Text);
                lot.IloscDzieci = dzieci;
            }
            catch (Exception)
            {
                MessageBox.Show("Wprowadz ilosc osob", "Błąd wprowadzania", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda Podliczająca ceny
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPodlicz_Click(object sender, RoutedEventArgs e)
        {
            //Najpierw sprawdza poprawność
            if (SprawdzaniePoprawnosci())
            {
                Dane();
            }
            else
            {
                return;
            }

            lblSuma1.Content = lot.PoliczKoszt().ToString("C2");
            lblSumaCzęściowa1.Content = lot.PoliczSumeCzesciowa().ToString("C2");
            lblPodatek1.Content = (lot.PoliczKoszt() - lot.PoliczSumeCzesciowa()).ToString("C2");
        }

        /// <summary>
        /// Metoda która wyświetla rachunek w GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrukuj_Click(object sender, RoutedEventArgs e)
        {
            rtxtPodsumowanie.Document.Blocks.Clear();

            //Najpierw sprawdza poprawność
            if (SprawdzaniePoprawnosci())
            {
                Dane();
            }
            else
            {
                return;
            }
            
            rtxtPodsumowanie.AppendText($"System biura podróży:\n" +
                $"Numer:  {lot.Sygnatura}" +
                $"\n-----------------------------" +
                $"\nImię:   {txtImie.Text}" +
                $"\nNazwisko:   {txtNazwisko.Text}" +
                $"\nPESEL:   {txtPESEL.Text}" +
                $"\nAdres:   {txtAdres.Text}" +
                $"\nKod pocztowy:   {txtKodPocztowy.Text}" +
                $"\nTelefon:   {txtTelefon.Text}" +
                $"\nE-mail:   {txtEmail.Text}" +
                $"\nCel podróży:   {cmbCel.Text}" +
                $"\nIlość osób dorosłych:   {txtOsobyDorosle.Text}" +
                $"\nIlość dzieci:   {txtIloscDzieci.Text}" +
                $"\n-----------------------------" +
                $"\nKlasa:   {lot.Klasa}" +
                $"\nBilet:   {lot.Bilet}" +
                $"\nSpecjalne potrzeby:   {lot.SpecjalnePotrzeby}" +
                $"\nUbezpieczenie:   {lot.Ubezpieczenie}" +
                $"\nDodatkowy bagaż:   {lot.DodatkowyBagaz}" +
                $"\nBonus za przeleciane kilometry:   {lot.PrzelecianeKilometry}" +
                $"\n-----------------------------" +
                $"\nPodatek:   {(lot.PoliczKoszt() - lot.PoliczSumeCzesciowa()).ToString("C2")}" +
                $"\nSuma częściowa:   {lot.PoliczSumeCzesciowa().ToString("C2")}" +
                $"\nSuma:   {lot.PoliczKoszt().ToString("C2")}" +
                $"\n-----------------------------" +
                $"\n{lblDate.Content}   {lblTime.Content}"+
                $"\n-----------------------------" +
                $"\nDziękujemy za skorzystanie z naszego biura podróży\n"
                );
        }


        /// <summary>
        /// Metoda pozwalająca na wpisanie tylko cyfr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Metoda pozwalająca na wpisanie tylko liter 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LetterInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        /// <summary>
        /// Metoda dodająca podróże do listy z GUI głównego
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dodaj(object sender, RoutedEventArgs e)
        {
            //Najpierw sprawdza poprawność
            if (SprawdzaniePoprawnosci())
            {
                Dane();
            }
            else
            {
                return;
            }

            DialogResult = true;

            MessageBox.Show("Dodano lot", "Dodawanie lotu", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
