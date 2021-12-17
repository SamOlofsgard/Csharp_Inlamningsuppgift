using Konferens_App_Deltagare.Handlers;
using Konferens_App_Deltagare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Konferens_App.Tester
{
    public class KontaktListaSka
    {
        KontaktLista sut = new KontaktLista();
        /// <summary>
        /// Testar att skapa en ny kontakt via KontaktPerson och kollar s� att item inte �r tom
        /// </summary>
        [Fact]
        public void CreateKontakt()
        {
            //action
            KontaktPerson item = sut.Create(Guid.NewGuid(),"Sam Olofsg�rd","socker","12312323","Hidden" );
            //assert
            Assert.NotNull(item);


        }
        /// <summary>
        /// Testar att l�gga till i Kontaktlistan i applicationen och 
        /// kollar s� att det finns n�gon kontakt i kontaktpersoner
        /// </summary>
        [Fact]
        public void AddToItemList()
        {
            //arrange
            KontaktPerson item = sut.Create(Guid.NewGuid(), "Sam Olofsg�rd", "socker", "12312323", "Hidden");
            

            //action
            sut.AddToKontaktList(item);

            //Assert
            Assert.NotNull(item);
            Assert.True(sut.KontaktPersoner.Any());

        }
        /// <summary>
        /// Testar om man kan h�mta kontakter fr�n  Kontaktlistan
        /// </summary>
        [Fact]
        public void GetKontaktPersoner()
        {
            //arrange
            KontaktPerson item = sut.Create(Guid.NewGuid(), "Sam Olofsg�rd", "socker", "12312323", "Hidden");
            sut.AddToKontaktList(item);

            //action
            IEnumerable<KontaktPerson> kontaktPersoner = sut.KontaktPersoner;

            //Assert
            Assert.NotNull(kontaktPersoner);
            

        }

    }
}