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
        /// Testar att skapa en ny kontakt via KontaktPerson och kollar så att item inte är tom
        /// </summary>
        [Fact]
        public void CreateKontakt()
        {
            //action
            KontaktPerson item = sut.Create(Guid.NewGuid(),"Sam Olofsgård","socker","12312323","Hidden" );
            //assert
            Assert.NotNull(item);


        }
        /// <summary>
        /// Testar att lägga till i Kontaktlistan i applicationen och 
        /// kollar så att det finns någon kontakt i kontaktpersoner
        /// </summary>
        [Fact]
        public void AddToItemList()
        {
            //arrange
            KontaktPerson item = sut.Create(Guid.NewGuid(), "Sam Olofsgård", "socker", "12312323", "Hidden");
            

            //action
            sut.AddToKontaktList(item);

            //Assert
            Assert.NotNull(item);
            Assert.True(sut.KontaktPersoner.Any());

        }
        /// <summary>
        /// Testar om man kan hämta kontakter från  Kontaktlistan
        /// </summary>
        [Fact]
        public void GetKontaktPersoner()
        {
            //arrange
            KontaktPerson item = sut.Create(Guid.NewGuid(), "Sam Olofsgård", "socker", "12312323", "Hidden");
            sut.AddToKontaktList(item);

            //action
            IEnumerable<KontaktPerson> kontaktPersoner = sut.KontaktPersoner;

            //Assert
            Assert.NotNull(kontaktPersoner);
            

        }

    }
}