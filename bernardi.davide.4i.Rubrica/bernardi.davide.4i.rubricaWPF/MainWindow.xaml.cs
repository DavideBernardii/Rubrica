using System;
using System.Collections.Generic;
using System.IO;
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

namespace bernardi.davide._4i.rubricaWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contatto> Contatti = new List<Contatto>();
        List<Persona> Persone = new List<Persona>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            try
            {
                StreamReader fin = new StreamReader("Persone.csv");
                fin.ReadLine();

                while (!fin.EndOfStream)
                {
                    Persone.Add(new Persona(fin.ReadLine()));
                }
                dgPersone.ItemsSource = Persone;
                    statusBar.Text = $"Ho letto dal file {Persone.Count} righe";

                fin = new StreamReader("Contatti.csv");
                fin.ReadLine();

                while (!fin.EndOfStream)                
                    Contatti.Add(new Contatto(fin.ReadLine( ) ) );
                
                dgContatti.ItemsSource = Contatti;

                statusBar.Text = $"Ho letto dal file {Contatti.Count} righe";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No No!!\n\n{ex.Message}");
            }
        }

        private void dgPersone_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Persona persona = e.Row.Item as Persona;

            /* if (c != null)
             {
                 if (c.Numero == 0)
                 {
                     e.Row.Background = Brushes.Red;
                     e.Row.Foreground = Brushes.White;
                 }

                 if (c.Telefono != null && c.Telefono.StartsWith("3"))
                 {
                     e.Row.Background = Brushes.Yellow;
                 }
             }*/
        }


        private void dgDati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Persona p = e.AddedItems[0] as Persona;

            if (p != null)
            {
                statusBar.Text = $"Contatto selezionato: {p.Cognome} ";
            
                List<Contatto> contattiFiltrati = new List<Contatto>();
                foreach (var item in Contatti)
                    if (item.idPersona == p.idPersona)
                        contattiFiltrati.Add(item);

                     dgContatti.ItemsSource = contattiFiltrati;   
                }
            else
            {
                statusBar.Text = "Contatto non valido";
            }
        }
    

        private void dgContatti_LoadingRow(object sender, DataGridRowEventArgs e)
        { 
            Contatto c = e.Row.Item as Contatto;
        }

        private void dgContatti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}