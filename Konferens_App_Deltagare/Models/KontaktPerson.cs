using System;

namespace Konferens_App_Deltagare.Models
{
    public class KontaktPerson
    {
        public Guid Id { get; set; }
        public string Kontakt { get; set; } = "";
        public string Allergi { get; set; } = "";
        public string Rabattkod { get; set; } = "";

        public string FoodVisibility { get; set; } = "";


    }
}
