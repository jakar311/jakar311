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
    public partial class SpisPodrozy : Window
    {

        /// <summary>
        /// Deklaracja zmiennej biuro z klasy BiuroPodrozy
        /// </summary>
        BiuroPodrozy biuro;

        /// <summary>
        /// Konstruktor nieparametryczny ustawiający datę i godzinę oraz tworzący nowe puste biuro podróży jeśli  nie wgramy włąsnego pliku XML (Opcja otwórz po wejściu w plik)
        /// </summary>
        //konstruktor nieparametryczny
        public SpisPodrozy()
        
        {
            InitializeComponent();

            biuro = new BiuroPodrozy();
            lisLoty.ItemsSource = new ObservableCollection<Podroze>(biuro.loty);
            txtNazwa1.Text = biuro.Nazwa;

            //Data i godzina
            DateTime nowTime = DateTime.Now;
            lblTime.Content = nowTime.ToLongTimeString();

            DateTime nowDate = DateTime.Now;
            lblDate.Content = nowTime.ToLongDateString();
        }


        /// <summary>
        /// Metoda tworząca przycisk otwierający okno do dodawania podróży
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (biuro != null)
            {
                Podroze l = new Podroze();
                MainWindow okno = new MainWindow(l);
                bool? result = okno.ShowDialog();
                if (result == true)
                {
                    biuro.DodajLot(l);
                    lisLoty.ItemsSource = new ObservableCollection<Podroze>(biuro.loty);
                }
            }
            else
            {
                MessageBox.Show("Wczytaj plik!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Metoda do otwierania formularza i dodawania podróży do głównej listy
        /// </summary>
        public void Otworz()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                biuro = BiuroPodrozy.OdczytajXML(filename);
                if (biuro is object)
                {
                    lisLoty.ItemsSource = new ObservableCollection<Podroze>(biuro.loty);
                    txtNazwa1.Text = biuro.Nazwa;
                }
            }
        }

        /// <summary>
        /// Przycisk otwórz w "plik", wgrywamy nasz wlasny plik XML
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuOtworz_Click(object sender, RoutedEventArgs e)
        {
            Otworz();
        }

        /// <summary>
        /// Przycisk zapisz w "plik", otwiera okno zapisu pliku XML z naszym biurem podróży
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuZapisz_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string filename = dlg.FileName;
                biuro.Nazwa = txtNazwa1.Text.ToString();
                BiuroPodrozy.ZapiszXML(filename,biuro);
            }
        }

        /// <summary>
        /// Przycisk wyjdź w "plik". Wychodzi z GUI (wcześniej pyta czy napewno)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuWyjdz_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz wyjść ?", "System Biura Podróży", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void BtlCzlonkowie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txtNazwa1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Przycisk usuń, usuwa wczesniej zaznaczone przez nas podróże z listy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (lisLoty.SelectedIndex > -1)
            {
                foreach(Podroze l in lisLoty.SelectedItems)
                {
                    biuro.UsunLot(l);
                }
                lisLoty.ItemsSource = new
                ObservableCollection<Podroze>(biuro.loty);
            }
        }

        /// <summary>
        /// Srtowanie podróży w liście
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (biuro is object)
            {
                biuro.Sortuj();
                lisLoty.ItemsSource = new
                ObservableCollection<Podroze>(biuro.loty);
            }
        }

        /// <summary>
        /// Wyświetlanie listy podróży z wylotem z podanego miejsca
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSzukanieWylotu_Click(object sender, RoutedEventArgs e)
        {

            lisLoty.ItemsSource = new ObservableCollection<Podroze>(biuro.WyszukajPodroze(txtSzukanieWylotu.Text)); 


        }

        /// <summary>
        /// Resetowanie listy do stanu początkowego, po wyszukiwaniu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            lisLoty.ItemsSource = new ObservableCollection<Podroze>(biuro.loty);
        }

        /// <summary>
        /// Sortowanie po PESELU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (biuro is object)
            {
                biuro.SortujPoPESEL();
                lisLoty.ItemsSource = new
                ObservableCollection<Podroze>(biuro.loty);
            }
        }

        /// <summary>
        /// Okienko: Czy napewno chcesz wyjść ?
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //Okienko: Czy napewno chcesz wyjść ?
            MessageBoxResult result = MessageBox.Show("Czy napewno chcesz wyjść ?", "System Biura Podróży", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Zapisywanie do bazy danych
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (biuro is object)
            {
                biuro.ZapiszDoBazy();
                MessageBoxResult result = MessageBox.Show("Zapisano do bazy danych", "System Biura Podróży", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Dodaj podróże, aby móc zapisać", "System Biura Podróży", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

    }
}
