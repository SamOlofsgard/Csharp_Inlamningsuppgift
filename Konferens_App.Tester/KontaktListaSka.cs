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

        [Fact]
        public void CreateKontakt()
        {
            //action
            KontaktPerson item = sut.Create(Guid.NewGuid(),"Sam Olofsgård","socker","12312323","Hidden" );
            //assert
            Assert.NotNull(item);


        }

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