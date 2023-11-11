using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CU0FK0_HFT_2023241.Test
{
    public class FakeAlbumRepository : IRepository<Album>
    {
        public void Create(Album item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Album Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Album> ReadAll()
        {
            return new List<Album>()
            {
                new Album(1,"Igor",1,4.7,2019),
                new Album(2,"FlowerBoy",1,4.4,2017),
                new Album(3,"Blonde",2,4.5,2016),
            }.AsQueryable();
        }

        public void Update(Album item)
        {
            throw new NotImplementedException();
        }
    }




    [TestFixture]
    public class AlbumLogicTester
    {
        AlbumLogic logic;

        [SetUp]
        public void Init()
        {
            logic = new AlbumLogic(new FakeAlbumRepository());
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

    }
}
