using Konferens_App_Deltagare.Handlers;
using Konferens_App_Deltagare.Models;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Konferens_App_Deltagare
{
    public partial class MainWindow : Window
    {
        /// <summary>
        /// locationTextFile är variabeln där pathen är sparad, just nu
        /// hamnar WriteLines.txt filen i root katalogen Konferens_App_Deltagare
        /// </summary>
        private string locationTextfile= @"..\..\..\WriteLines.txt";
                       

        KontaktLista kontaktLista = new KontaktLista();
        GetContactsFromFile Contacts = new GetContactsFromFile();

        public string LocationTextfile
        {
            get { return locationTextfile; }
            set { }
        }

        public MainWindow()
        {
            InitializeComponent();
            GetContacts();
        }
        /// <summary>
        /// GetContacts() 
        /// Rensar först kontaktlistan i applicationen
        /// 
        /// Sen kollar den om det finns en textfil som den kan hämta
        /// nya kontakter ifrån. Om den inte finns så skapar den en tom txt fil
        /// 
        /// Contacts.TxtFile tar hand om txt filen som en array där den sedan
        /// delar upp varje rad i filen som en item där den även plockar ut rabattkoden
        /// och allergin som enskilda variablar men behåller förnamn, efternamn och email
        /// som en kontakt variabel.
        /// 
        /// Till slut så tar den varje item i kontaktlistan och lägger upp dem i kontatklistan 
        /// i applicationen. 
        /// </summary>        
        public async void GetContacts()
        {
            lvContacts.Items.Clear();
            try
            {
                string[] lines = System.IO.File.ReadAllLines(LocationTextfile);                
                Contacts.TxtFile(lines, kontaktLista);

            }
            catch (Exception)
            {
                await File.WriteAllTextAsync(LocationTextfile, "");
            }
            foreach (var item in kontaktLista.KontaktPersoner)
                lvContacts.Items.Add(item);
        }

        /// <summary>
        /// btnAdd_Click lägger till en ny kontakt i kontaktlistan och spara den
        /// nya kontakten i txt filen direkt, om fälten för förnamn, efternamn 
        /// och email är ifyllda. Allergi är ett tillval för alla har inte det.
        /// 
        /// Rensar formuläret i applicationen och sen uppdaterar kontaktlistan i 
        /// applicationen genom en uppdaterad txt fil i GetContacts()
        /// 
        /// </summary>
        public async void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {
                string text = System.IO.File.ReadAllText(LocationTextfile);
                await File.WriteAllTextAsync(LocationTextfile, $"{$"{tbFirstName.Text} {tbLastName.Text} Email: {tbEmail.Text} Allergi:{tbAllergi.Text}"} Rabattkod:{Guid.NewGuid()}\n{text}");
                tbFirstName.Text = "";
                tbLastName.Text = "";
                tbEmail.Text = "";
                tbAllergi.Text = "";
                GetContacts();
            }
        }
        /// <summary>
        /// btndelete_Click tar bort en kontakt i kontaktlistan i applicationen
        /// Tar även bort den linen i txt- filen som är kontakten och uppdaterar
        /// txt- filen
        /// 
        /// </summary>
        private async void btndelete_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var item = (KontaktPerson)obj.DataContext;

            lvContacts.Items.Remove(item);
            string[] lines = System.IO.File.ReadAllLines(LocationTextfile);
            string nytext = Contacts.EraseLine(lines, item.Kontakt);            
            await File.WriteAllTextAsync(LocationTextfile, $"{nytext}");
            kontaktLista.RemoveFromKontaktList(item);

        }
        /// <summary>
        /// btnFood_Click Visar vilken allergi kontaktpersonen har både
        /// när muspekaren är på food symbolen men också i rutan som dyker
        /// upp när man klickar på food symbolen.
        /// 
        /// Har kontaktpersonen ingen allergi så visas ingen food symbol        
        /// </summary>
        private void btnFood_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var item = (KontaktPerson)obj.DataContext;
            MessageBox.Show($"Deltagaren har {item.Allergi}");            
        }
        /// <summary>
        /// btnRabatt_Click Visar rabatten som symbol och när man klickar på
        /// rabatten så skickas det en rabattkod till kontaktpersonens email, typ.
        /// </summary>
        private void btnRabatt_Click(object sender, RoutedEventArgs e)
        {
            var obj = (Button)sender;
            var item = (KontaktPerson)obj.DataContext;
            MessageBox.Show($"Skickar :{item.Rabattkod} till deltagaren {item.Kontakt}");

        }
    }
}
