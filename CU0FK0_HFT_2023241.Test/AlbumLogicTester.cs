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
        AlbumLogic Albumlogic;
        ArtistLogic Artistlogic;
        SongLogic Songlogic;
        Mock<IRepository<Album>> mockAlbumRepo;
        Mock<IRepository<Artist>> mockArtistRepo;
        Mock<IRepository<Song>> mockSongRepo;

        [SetUp]
        public void Init()
        {
            
            List<Album> albumList = new List<Album>() {

                new Album(1, "Igor", 1, 4.7, 2019),
                new Album(2, "FlowerBoy", 1, 4.4, 2017),
                new Album(3, "Blonde", 2, 4.5, 2016),
                new Album(14, "Pink Friday", 9, 4.4, 2010),
                new Album(15, "The Pinkprint", 9, 4.5, 2014),
                new Album(7, "Invasion of Privacy", 5, 4.6, 2018),
                new Album(4, "good kid, m.A.A.d city", 4,  4.8,  2012),
                new Album(5, "To Pimp a Butterfly",  4,  4.9, 2015),
                new Album(6, "DAMN.",  4,  4.7,  2017),
            };

            List<Artist> artistList = new List<Artist>
            {
                new Artist(1, "Tyler The Creator", "Male"),
                new Artist(2, "Frank Ocean", "Male"),
                new Artist(5, "Cardi B", "Female"),
                new Artist(9, "Nicki Minaj", "Female"),
                new Artist(4, "Kendrick Lamar","Male"),
            };
            List<Song> songList = new List<Song>
            {
                #region Kendrick Lamar
                new Song(1, "Bitch, Don't Kill My Vibe", 316, 4, 4.6),
                new Song(2, "Backseat Freestyle", 204, 4, 4.4),
                new Song(3, "The Art of Peer Pressure", 349, 4, 4.5),
                new Song(4, "Money Trees", 397, 4, 4.7),
                new Song(5, "Swimming Pools (Drank)", 235, 4, 4.8),
                new Song(6, "m.A.A.d city", 288, 4, 4.7),
                new Song(7, "Poe Man's Dreams (His Vice)", 200, 4, 4.4),
                new Song(8, "good kid", 191, 4, 4.5),
                new Song(9, "m.A.A.d city (Part II)", 286, 4, 4.6),
                new Song(10, "Sing About Me, I'm Dying of Thirst", 811, 4, 4.9),
                new Song(11, "Real", 191, 4, 4.4),
                new Song(12, "Compton", 290, 4, 4.6),

                new Song(182, "Wesley's Theory", 240, 5, 4.6),
                new Song(183, "For Free? (Interlude)", 128, 5, 4.3),
                new Song(184, "King Kunta", 234, 5, 4.7),
                new Song(185, "Institutionalized", 315, 5, 4.5),
                new Song(186, "These Walls", 325, 5, 4.6),
                new Song(187, "u", 294, 5, 4.7),
                new Song(188, "Alright", 186, 5, 4.8),
                new Song(189, "For Sale? (Interlude)", 130, 5, 4.4),
                new Song(190, "Momma", 273, 5, 4.6),
                new Song(191, "Hood Politics", 271, 5, 4.5),
                new Song(192, "How Much a Dollar Cost", 297, 5, 4.7),
                new Song(193, "Complexion (A Zulu Love)", 280, 5, 4.5),
                new Song(194, "The Blacker the Berry", 324, 5, 4.8),
                new Song(195, "You Ain't Gotta Lie (Momma Said)", 194, 5, 4.6),
                new Song(196, "i", 300, 5, 4.7),
                new Song(197, "Mortal Man", 775, 5, 4.5),

                new Song(198, "BLOOD.", 180, 6, 4.7),
                new Song(199, "DNA.", 185, 6, 4.8),
                new Song(200, "YAH.", 160, 6, 4.6),
                new Song(201, "ELEMENT.", 215, 6, 4.5),
                new Song(202, "FEEL.", 204, 6, 4.6),
                new Song(203, "LOYALTY.", 226, 6, 4.7),
                new Song(204, "PRIDE.", 224, 6, 4.6),
                new Song(205, "HUMBLE.", 177, 6, 4.9),
                new Song(206, "LUST.", 305, 6, 4.6),
                new Song(207, "LOVE.", 213, 6, 4.5),
                new Song(208, "XXX.", 266, 6, 4.7),
                new Song(209, "FEAR.", 389, 6, 4.8),
                new Song(210, "GOD.", 230, 6, 4.6),
                new Song(211, "DUCKWORTH.", 194, 6, 4.7),

                #endregion

                #region Tyler The Creator
                new Song(139, "IGOR'S THEME", 204, 1, 4.7),
                new Song(140, "EARFQUAKE", 190, 1, 4.8),
                new Song(141, "I THINK", 210, 1, 4.6),
                new Song(142, "EXACTLY WHAT YOU RUN FROM YOU END UP CHASING", 268, 1, 4.5),
                new Song(143, "RUNNING OUT OF TIME", 137, 1, 4.6),
                new Song(144, "NEW MAGIC WAND", 202, 1, 4.7),
                new Song(145, "A BOY IS A GUN*", 209, 1, 4.7),
                new Song(146, "PUPPET", 196, 1, 4.6),
                new Song(147, "WHAT'S GOOD", 122, 1, 4.6),
                new Song(148, "GONE, GONE / THANK YOU", 278, 1, 4.7),
                new Song(149, "I DON'T LOVE YOU ANYMORE", 215, 1, 4.6),
                new Song(150, "ARE WE STILL FRIENDS?", 315, 1, 4.8),

                new Song(151, "Foreword", 199, 2, 4.5),
                new Song(152, "Where This Flower Blooms", 191, 2, 4.4),
                new Song(153, "Sometimes...", 203, 2, 4.3),
                new Song(154, "See You Again", 185, 2, 4.6),
                new Song(155, "Who Dat Boy", 121, 2, 4.7),
                new Song(156, "Pothole", 227, 2, 4.4),
                new Song(157, "Garden Shed", 194, 2, 4.5),
                new Song(158, "Boredom", 256, 2, 4.6),
                new Song(159, "I Ain't Got Time!", 173, 2, 4.7),
                new Song(160, "911 / Mr. Lonely", 210, 2, 4.6),
                new Song(161, "Droppin' Seeds", 54, 2, 4.3),
                new Song(162, "November", 184, 2, 4.4),
                new Song(163, "Glitter", 229, 2, 4.5),
                new Song(164, "Enjoy Right Now, Today", 116, 2, 4.2),





                #endregion

                #region Frank Ocean
                new Song(165, "Nikes", 290, 3, 4.6),
                new Song(166, "Ivy", 260, 3, 4.7),
                new Song(167, "Pink + White", 207, 3, 4.8),
                new Song(168, "Be Yourself", 43, 3, 4.4),
                new Song(169, "Solo", 235, 3, 4.5),
                new Song(170, "Skyline To", 223, 3, 4.3),
                new Song(171, "Self Control", 251, 3, 4.7),
                new Song(172, "Good Guy", 57, 3, 4.2),
                new Song(173, "Nights", 328, 3, 4.8),
                new Song(174, "Solo (Reprise)", 75, 3, 4.6),
                new Song(175, "Pretty Sweet", 112, 3, 4.4),
                new Song(176, "Facebook Story", 49, 3, 4.3),
                new Song(177, "Close to You", 156, 3, 4.5),
                new Song(178, "White Ferrari", 189, 3, 4.6),
                new Song(179, "Seigfried", 274, 3, 4.7),
                new Song(180, "Godspeed", 174, 3, 4.8),
                new Song(181, "Futura Free", 473, 3, 4.5),

                #endregion

                #region Nicki Minaj
                new Song(274, "All Things Go", 188, 15, 4.5),
                new Song(275, "I Lied", 254, 15, 4.6),
                new Song(276, "The Crying Game", 242, 15, 4.5),
                new Song(277, "Get On Your Knees", 178, 15, 4.6),
                new Song(278, "Feeling Myself", 229, 15, 4.7),
                new Song(279, "Only", 234, 15, 4.6),
                new Song(280, "Want Some More", 188, 15, 4.5),
                new Song(281, "Four Door Aventador", 201, 15, 4.6),
                new Song(282, "Favorite", 224, 15, 4.5),
                new Song(283, "Buy a Heart", 190, 15, 4.6),
                new Song(284, "Trini Dem Girls", 224, 15, 4.7),
                new Song(285, "Anaconda", 227, 15, 4.6),
                new Song(286, "The Night Is Still Young", 189, 15, 4.5),
                new Song(287, "Pills N Potions", 235, 15, 4.6),
                new Song(288, "Bed of Lies", 218, 15, 4.7),
                new Song(289, "Grand Piano", 231, 15, 4.6),
                new Song(290, "Big Daddy", 186, 15, 4.5),
                new Song(291, "Shanghai", 187, 15, 4.6),
                new Song(292, "Win Again", 194, 15, 4.5),
                new Song(293, "Truffle Butter", 229, 15, 4.6),
                new Song(294, "Mona Lisa", 155, 15, 4.7),
                new Song(295, "Put You in a Room", 199, 15, 4.6),
                new Song(296, "Tragik", 163, 15, 4.5),

                new Song(70, "I'm the Best", 196, 14, 4.5),
                new Song(71, "Roman's Revenge", 298, 14, 4.4),
                new Song(72, "Did It On'em", 189, 14, 4.3),
                new Song(73, "Right Thru Me", 227, 14, 4.2),
                new Song(74, "Fly", 232, 14, 4.0),
                new Song(75, "Save Me", 235, 14, 4.2),
                new Song(76, "Moment 4 Life", 290, 14, 4.6),
                new Song(77, "Check It Out", 219, 14, 4.3),
                new Song(78, "Blazin", 279, 14, 4.5),
                new Song(79, "Here I Am", 227, 14, 4.4),
                new Song(80, "Dear Old Nicki", 202, 14, 4.3),
                new Song(81, "Your Love", 235, 14, 4.2),
                new Song(82, "Last Chance", 297, 14, 4.4),
                new Song(83, "Super Bass", 203, 14, 4.6),
                new Song(84, "Blow Ya Mind", 219, 14, 4.5),
                new Song(85, "Muny", 236, 14, 4.4),
                new Song(86, "Girls Fall Like Dominoes", 192, 14, 4.3),
                #endregion

                #region Cardi B
                new Song(13, "Get Up 10", 214, 7, 4.6),
                new Song(14, "Drip", 244, 7, 4.5),
                new Song(15, "Bickenhead", 180, 7, 4.4),
                new Song(16, "Bodak Yellow", 200, 7, 4.9),
                new Song(17, "Be Careful", 229, 7, 4.5),
                new Song(18, "Best Life", 256, 7, 4.6),
                new Song(19, "I Like It", 253, 7, 4.6),
                new Song(20, "Ring", 236, 7 , 4.4),
                new Song(21, "Money Bag", 190, 7, 4.3),
                new Song(22, "Bartier Cardi", 220, 7, 4.4),
                new Song(23, "She Bad", 191, 7, 4.2),
                new Song(24, "Thru Your Phone", 211, 7, 4.1),
                new Song(25, "I Do", 224, 7, 4.0),
                #endregion
            };

            mockAlbumRepo = new Mock<IRepository<Album>>();
            mockAlbumRepo.Setup(a => a.ReadAll()).Returns(albumList.AsQueryable());
            Albumlogic = new AlbumLogic(mockAlbumRepo.Object);

            mockArtistRepo = new Mock<IRepository<Artist>>();
            mockArtistRepo.Setup(a => a.ReadAll()).Returns(artistList.AsQueryable());
            Artistlogic = new ArtistLogic(mockArtistRepo.Object);

            mockSongRepo = new Mock<IRepository<Song>>();
            mockSongRepo.Setup(a => a.ReadAll()).Returns(songList.AsQueryable());
            Songlogic = new SongLogic(mockSongRepo.Object);

            //connection setup
            //Albums to Artist
            albumList.ForEach(album => { album.Artist = artistList.Find(x => x.ArtistID == album.ArtistID); });
            //Songs to Album
            songList.ForEach(song => { song.Album = albumList.Find(x => x.AlbumID == song.AlbumID); });

            //Album to songs
            albumList.ForEach(album => { album.Songs = songList.FindAll(song => song.AlbumID == album.AlbumID); });
            //Artist to Albums
            artistList.ForEach(artist => { artist.Albums = albumList.FindAll(album => album.ArtistID == artist.ArtistID); });

        }

        #region NON_CRUD Tests
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
            var album = Albumlogic.FemaleAlbumsLaterThan2012();
            //ASSERT
            Assert.That(album, Is.EqualTo(expectedResult));
        }
        [Test]
        public void EverySongFromAlbumBetterThanTest()
        {
            //ARRANGE
            IEnumerable<Song> expectedResult;
            int testInput = 0;
            expectedResult=Songlogic.ReadAll().OrderBy(t=>t.AlbumID).AsEnumerable();
            
            //ACT
            var songs =Albumlogic.EverySongFromAlbumBetterThan(testInput);
            //ASSERT
            Assert.That(songs, Is.EqualTo(expectedResult));
        }

        #endregion

        #region CRUD_Tests
        [Test]
        public void CreateAlbumTestWithCorrectTitle()
        {
            var album = new Album() { AlbumTitle = "PLAYBANIA" };
            try
            {
                //ACT
                
                Albumlogic.Create(album);
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

                Albumlogic.Create(album);
            }
            catch
            {
            }

            //ASSERT 
            Assert.That(()=> Albumlogic.Create(album),Throws.TypeOf<ArgumentException>());
            //mockAlbumRepo.Verify(r => r.Create(album), Times.Never);
        }
        #endregion
    }
}
