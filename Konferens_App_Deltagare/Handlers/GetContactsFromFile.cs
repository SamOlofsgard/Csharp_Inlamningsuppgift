using Konferens_App_Deltagare.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konferens_App_Deltagare.Models
{
    public class GetContactsFromFile
    {
        /// <summary>
        /// TxtFile tar hand om lines array:en som är hämtad från txt filen.
        /// Varje line är ett item som delas upp i foreach loopen i:
        /// kontakt, allergi och rabattkod. Kollar även om det finns
        /// någon allergi och finns det ingen så görs food symbolen osynlig.
        /// </summary>
        public void TxtFile(string[] lines, KontaktLista kontaktLista)
        {
            kontaktLista.ClearKontaktList();
            foreach (string line in lines)
            {

                int rabattkodPos = line.IndexOf("Rabattkod:");
                string rabattKod = line.Substring(rabattkodPos);
                string kontaktUtanRabattkod = line.Remove(rabattkodPos);

                int allergiPos = kontaktUtanRabattkod.IndexOf("Allergi:");
                string allergi = kontaktUtanRabattkod.Substring(allergiPos);
                string kontakt = kontaktUtanRabattkod.Remove(allergiPos);

                string foodVisibility = "";
                if (allergi.Length > 9)
                    foodVisibility = "Visible";
                
                else
                    foodVisibility = "Hidden";
                                                
                var item = kontaktLista.Create(Guid.NewGuid(), kontakt, allergi, rabattKod, foodVisibility);
                kontaktLista.AddToKontaktList(item);
            }

        }
        /// <summary>
        /// EraseLine letar rätt på den line som stämmer överens i
        /// line array:en som ska tas bort. 
        /// Skapar en ny string variabel som returneras och blir den
        /// uppdaterade txt filen.
        /// </summary>
        public string EraseLine (string[] lines, string Kontakt)
        {
            foreach (string line in lines)
            {
                int rabattkodPos = line.IndexOf("Rabattkod:");
                string kontaktUtanRabattkod = line.Remove(rabattkodPos);

                int allergiPos = kontaktUtanRabattkod.IndexOf("Allergi:");
                string allergi = kontaktUtanRabattkod.Substring(allergiPos);
                string kontakt = kontaktUtanRabattkod.Remove(allergiPos);

                if (kontakt == Kontakt)
                {
                    lines = lines.Where(o => o != line).ToArray();
                }
            }
            string nytext = "";
            foreach (string line in lines)
            {
                nytext = $"{line}\n{nytext}";
            }
            return nytext;
            
        }

        
    }
}
