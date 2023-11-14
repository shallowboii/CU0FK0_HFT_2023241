using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Test
{
    [TestFixture]
    public class ArtistLogicTester
    {
        ArtistLogic logic;
        Mock<IRepository<Artist>> mockArtistRepo;

        [SetUp]
        public void Init()
        {
            mockArtistRepo = new Mock<IRepository<Artist>>();
            mockArtistRepo.Setup(a => a.ReadAll()).Returns(new List<Artist>()
            {
                new Artist(1,"Tyler The Creator","Male"),
                new Artist(2,"Frank Ocean","Male"),
                new Artist(5, "Cardi B", "Female"),
                new Artist( 9,  "Nicki Minaj",  "Female")



            }.AsQueryable());
            logic = new ArtistLogic(mockArtistRepo.Object);

            
        }
        [Test]
        public void CreateArtistTestWithCorrectName()
        {
            //ACT
            var artist = new Artist() { ArtistName = "Beton.Hofi"};
            try
            {
                logic.Create(artist);
            }
            catch (Exception)
            {

                throw;
            }
            //ASSERT
            mockArtistRepo.Verify(r => r.Create(artist), Times.Once());
        }
        [Test]
        public void CreateArtistTestWithWrongName()
        {
            //ACT
            string wrongName = "12";
            var artist = new Artist() { ArtistName = wrongName };
            try
            {
                logic.Create(artist);
            }
            catch
            {
            }
            //ASSERT
            Assert.That(() => logic.Create(artist), Throws.TypeOf<ArgumentException>());
        }

        


    }
}
