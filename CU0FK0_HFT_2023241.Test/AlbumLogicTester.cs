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
                new Album(1,"Igor",1,4.7,2019),//done
                new Album(2,"FlowerBoy",1,4.4,2017),//done
                new Album(3,"Blonde",2,4.5,2016),//done
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
            //ACT
            var album = logic.BestAlbumOfArtist(1);
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
        public void CreateAlbumTestWithWrongTitle()
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
            mockAlbumRepo.Verify(r => r.Create(album), Times.Never());
        }

    }
}
