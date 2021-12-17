using Konferens_App_Deltagare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konferens_App_Deltagare.Handlers
{
    public class KontaktLista 
    {
        public List<KontaktPerson> KontaktPersoner { get; private set; } = new List<KontaktPerson>();
                
        public KontaktPerson Create(Guid id, string kontakt, string allergi, string rabattkod, string foodVisibility )
        {
            return new KontaktPerson { Id = id, Kontakt = kontakt, Allergi = allergi, Rabattkod = rabattkod, FoodVisibility = foodVisibility };
        }

        public void AddToKontaktList(KontaktPerson item)
        {
            KontaktPersoner.Add(item);
        }

        public void RemoveFromKontaktList(KontaktPerson item)
        {
            KontaktPersoner.Remove(item);
        }
        public void ClearKontaktList()
        {
            KontaktPersoner.Clear();
        }

    }
}
