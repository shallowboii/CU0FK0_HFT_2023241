using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CU0FK0_HFT_2023241.Test
{
    

    [TestFixture]
    public class AlbumLogicTester
    {
        AlbumLogic logic;
        Mock<IRepository<Album>> mockAlbumRepo;

        [SetUp]
        public void Init()
        {
            mockAlbumRepo = new Mock<IRepository<Album>>();
            mockAlbumRepo.Setup(a => a.ReadAll()).Returns(new List<Album>()
            {
                new Album(1,"Igor",1,4.7,2019),
                new Album(2,"FlowerBoy",1,4.4,2017),
                new Album(3,"Blonde",2,4.5,2016),
                new Album(14, "Pink Friday", 9, 4.4, 2010),
                new Album(15, "The Pinkprint", 9, 4.5,  2014),
                new Album(7, "Invasion of Privacy", 5, 4.6, 2018),
            }.AsQueryable());
            logic = new AlbumLogic(mockAlbumRepo.Object);
        }

        [Test]
        public void BestAlbumOfArtistTest()
        {
            //ARRANGE
            IEnumerable<Album> expectedResult;
            expectedResult = new List<Album>()
            {
                new Album(1,"Igor",1,4.7,2019)
            };
            int testArtistID = 1;
            //ACT
            var album = logic.BestAlbumOfArtist(testArtistID);
            //ASSERT
            Assert.That(album, Is.EqualTo(expectedResult));
        }

        [Test]
        public void FemaleAlbumsLaterThan2012Test()
        {
            //ARRANGE
            IEnumerable<Album> expectedResult;
            expectedResult = new List<Album>()
            { 
                new Album(15, "The Pinkprint", 9, 4.5, 2014),
                new Album(7, "Invasion of Privacy", 5, 4.6, 2018),
            };
            //ACT
            var album = logic.FemaleAlbumsLaterThan2012();
            //ASSERT
            Assert.That(album, Is.EqualTo(expectedResult));
        }

        [Test]
        public void CreateAlbumTestWithCorrectTitle()
        {
            var album = new Album() { AlbumTitle = "PLAYBANIA" };
            try
            {
                //ACT
                
                logic.Create(album);
            }
            catch 
            {

                throw;
            }

            //ASSERT 
            mockAlbumRepo.Verify(r=>r.Create(album),Times.Once());
        }
        [Test]
        public void CreateAlbumTest_WithTooShortTitle()
        {
            var album = new Album() { AlbumTitle = "20" };
            try
            {
                //ACT

                logic.Create(album);
            }
            catch
            {

                throw;
            }

            //ASSERT 
            Assert.That(()=> logic.Create(album),Throws.TypeOf<ArgumentException>());
        }

    }
}
