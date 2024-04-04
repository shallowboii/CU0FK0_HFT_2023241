using CU0FK0_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CU0FK0_HFT_2023241.Repository
{
    public class MyMusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }


        public MyMusicDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
               
                builder.UseInMemoryDatabase("database")
                    .UseLazyLoadingProxies();
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(album => album
            .HasOne(album => album.Artist)
            .WithMany(artist => artist.Albums)
            .HasForeignKey(album => album.ArtistID)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Song>(song => song
            .HasOne(song => song.Album)
            .WithMany(album => album.Songs)
            .HasForeignKey(song => song.AlbumID)
            .OnDelete(DeleteBehavior.Cascade));


            //modelBuilder.Entity<Artist>(artist => artist
            //.HasMany(artist => artist.Albums)
            //.WithOne(album => album.Artist)
            //.HasForeignKey(artist => artist.AlbumID)
            //.OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album(1,"Igor",1,4.7,2019),//done
                new Album(2,"FlowerBoy",1,4.4,2017),//done
                new Album(3,"Blonde",2,4.5,2016),//done
                new Album(4, "good kid, m.A.A.d city", 4,  4.8,  2012),//done
                new Album(5, "To Pimp a Butterfly",  4,  4.9, 2015),//done
                new Album(6, "DAMN.",  4,  4.7,  2017),//done
                new Album(7, "Invasion of Privacy", 5, 3.2, 2018),//done
                new Album(8, "Take Care", 6, 3.8, 2011),//done
                new Album(9, "Views", 6, 3.2, 2016),//done
                new Album(10, "Scorpion", 6, 4.1, 2018),//done
                new Album(11, "Good News", 7, 3.4, 2020),//done
                new Album(12, "Rodeo", 8, 4.5, 2015),//done
                new Album(13, "Astroworld", 8, 4.8, 2018),//done
                new Album(14, "Pink Friday", 9, 3.3, 2010),//done
                new Album(15, "The Pinkprint", 9, 4.1, 2014),//done
                new Album(16, "2014 Forest Hills Drive", 10, 4.6, 2014),//done
                new Album(17, "KOD", 10, 4.3, 2018),//done
                new Album(18, "Cuz I Love You", 11, 2.8, 2019),//done
                new Album(19, "Montero", 12, 2.4, 2021),//done
                new Album(20, "Stoney", 13, 2.5, 2016),//done
                new Album(21, "Hollywood's Bleeding", 13, 2.7, 2019)



            }
                );

            modelBuilder.Entity<Song>().HasData(new Song[]
            {


                //Kendrick Lamar good kid, m.A.A.d city /4

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


                //Cardi B Invasion of Privacy /7
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


                //Drake Take Care /8
                new Song(26, "Over My Dead Body", 241, 8, 4.5),
                new Song(27, "Shot for Me", 225, 8, 4.3),
                new Song(28, "Headlines", 237, 8, 4.4),
                new Song(29, "Crew Love", 240, 8, 4.2),
                new Song(30, "Take Care", 263, 8, 4.5),
                new Song(31, "Marvin's Room", 323, 8, 4.7),
                new Song(32, "Buried Alive Interlude", 125, 8, 4.0),
                new Song(33, "Under Ground Kings", 232, 8, 4.3),
                new Song(34, "We'll Be Fine", 262, 8, 4.1),
                new Song(35, "Make Me Proud", 227, 8, 4.4),
                new Song(36, "Lord Knows", 308, 8, 4.6),
                new Song(37, "Cameras / Good Ones Go Interlude", 276, 8, 4.4),
                new Song(38, "Doing It Wrong", 276, 8, 4.2),
                new Song(39, "The Real Her", 275, 8, 4.3),
                new Song(40, "Look What You've Done", 253, 8, 4.5),
                new Song(41, "HYFR", 250, 8, 4.4),
                new Song(42, "Practice", 318, 8, 4.1),
                new Song(43, "The Ride", 277, 8, 4.3),


                  //Megan Thee Stallion Good News //11

                new Song(44, "Shots Fired", 272, 11, 4.2),
                new Song(45, "Circles", 182, 11, 4.1),
                new Song(46, "Cry Baby", 170, 11, 4.5),
                new Song(47, "Do It on the Tip", 173, 11, 4.3),
                new Song(48, "Sugar Baby", 172, 11, 4.0),
                new Song(49, "Movie", 202, 11, 4.2),
                new Song(50, "Freaky Girls", 190, 11, 4.4),
                new Song(51, "Butter", 145, 11, 4.6),
                new Song(52, "Ride or Die", 149, 11, 4.5),
                new Song(53, "Love You Tonight", 190, 11, 4.4),
                new Song(54, "Savage", 209, 11, 4.6),
                new Song(55, "Don't Rock Me to Sleep", 182, 11, 4.3),

                //Travis Scott Rodeo /12
                new Song(56, "Pornography", 287, 12, 4.2),
                new Song(57, "Oh My Dis Side", 328, 12, 4.3),
                new Song(58, "3500", 306, 12, 4.5),
                new Song(59, "Wasted", 187, 12, 4.4),
                new Song(60, "90210", 322, 12, 4.6),
                new Song(61, "Pray 4 Love", 354, 12, 4.3),
                new Song(62, "Nightcrawler", 241, 12, 4.2),
                new Song(63, "Piss On Your Grave", 121, 12, 4.0),
                new Song(64, "Antidote", 243, 12, 4.7),
                new Song(65, "Impossible", 255, 12, 4.5),
                new Song(66, "Maria I'm Drunk", 395, 12, 4.8),
                new Song(67, "Flying High", 132, 12, 4.3),
                new Song(68, "I Can Tell", 281, 12, 4.2),
                new Song(69, "Apple Pie", 352, 12, 4.4),


                //Nicki Minaj Pink Friday /14
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


                //Jcole 2014 Forest Hills Drive /16
                new Song(87, "Intro", 113, 16, 4.0),
                new Song(88, "January 28th", 252, 16, 4.1),
                new Song(89, "Wet Dreamz", 247, 16, 4.2),
                new Song(90, "03' Adolescence", 242, 16, 4.4),
                new Song(91, "A Tale of 2 Citiez", 242, 16, 4.3),
                new Song(92, "Fire Squad", 250, 16, 4.5),
                new Song(93, "St. Tropez", 269, 16, 4.3),
                new Song(94, "G.O.M.D.", 263, 16, 4.6),
                new Song(95, "No Role Modelz", 266, 16, 4.7),
                new Song(96, "Hello", 242, 16, 4.4),
                new Song(97, "Apparently", 271, 16, 4.5),
                new Song(98, "Love Yourz", 288, 16, 4.4),
                new Song(99, "Note to Self", 775, 16, 4.1),


                //Lizzo Cuz I love you /18
                new Song(100, "Cuz I Love You", 190, 18, 4.4),
                new Song(101, "Like a Girl", 182, 18, 4.3),
                new Song(102, "Juice", 191, 18, 4.5),
                new Song(103, "Soulmate", 156, 18, 4.2),
                new Song(104, "Jerome", 191, 18, 4.4),
                new Song(105, "Crybaby", 183, 18, 4.2),
                new Song(106, "Tempo", 197, 18, 4.6),
                new Song(107, "Exactly How I Feel", 174, 18, 4.4),
                new Song(108, "Better in Color", 153, 18, 4.3),
                new Song(109, "Heaven Help Me", 195, 18, 4.0),
                new Song(110, "Lingerie", 157, 18, 4.3),
                new Song(111, "Boys", 135, 18, 4.2),
                new Song(112, "Truth Hurts", 173, 18, 4.8),
                new Song(113, "Water Me", 175, 18, 4.6),
                new Song(114, "Good as Hell", 172, 18, 4.5),
                new Song(115, "Grrrls", 208, 18, 4.4),

                //Lil Nas X Montero /19
                new Song(116, "Montero (Call Me By Your Name)", 137, 19, 4.7),
                new Song(117, "Dead Right Now", 181, 19, 4.6),
                new Song(118, "Industry Baby", 206, 19, 4.6),
                new Song(119, "That’s What I Want", 137, 19, 4.7),
                new Song(120, "The Art of Realization", 206, 19, 4.4),
                new Song(121, "Scoop", 161, 19, 4.3),
                new Song(122, "One of Me", 187, 19, 4.5),
                new Song(123, "Lost in the Citadel", 184, 19, 4.4),
                new Song(124, "Dolla Sign Slime", 205, 19, 4.2),
                new Song(125, "Tales of Dominica", 137, 19, 4.4),
                new Song(126, "Sun Goes Down", 242, 19, 4.6),
                new Song(127, "Void", 168, 19, 4.3),
                new Song(128, "Don’t Want It", 170, 19, 4.2),
                new Song(129, "Life After Salem", 161, 19, 4.3),
                new Song(130, "Am I Dreaming", 143, 19, 4.0),

                //Post Malone Stoney / 20
                new Song(131, "White Iverson", 290, 20, 4.5),
                new Song(132, "Congratulations", 210, 20, 4.4),
                new Song(133, "Up There", 166, 20, 4.3),
                new Song(134, "Yours Truly, Austin Post", 171, 20, 4.2),
                new Song(135, "Leave", 166, 20, 4.0),
                new Song(136, "Hit This Hard", 237, 20, 4.2),
                new Song(137, "Money Made Me Do It", 215, 20, 4.4),
                new Song(138, "Feeling Whitney", 231, 20, 4.5),


                //Tyler The Creator Igor /1
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

                //Tyler The Creator Flowerboy /2

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


                //Frank Ocean Blonde /3
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

                //Kendrick To Pimp A Butterfly /5

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

                //Kendrick Damn /6

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
                                
                

                

                //Drake Views /9
                new Song(212, "Keep the Family Close", 233, 9, 4.6),
                new Song(213, "9", 226, 9, 4.5),
                new Song(214, "U with Me?", 221, 9, 4.6),
                new Song(215, "Feel No Ways", 248, 9, 4.7),
                new Song(216, "Hype", 196, 9, 4.6),
                new Song(217, "Weston Road Flows", 286, 9, 4.5),
                new Song(218, "Redemption", 238, 9, 4.7),
                new Song(219, "With You", 228, 9, 4.6),
                new Song(220, "Faithful", 287, 9, 4.8),
                new Song(221, "Still Here", 189, 9, 4.6),
                new Song(222, "Controlla", 245, 9, 4.5),
                new Song(223, "One Dance", 173, 9, 4.9),
                new Song(224, "Grammys", 190, 9, 4.6),
                new Song(225, "Childs Play", 251, 9, 4.7),
                new Song(226, "Pop Style", 222, 9, 4.6),
                new Song(227, "Too Good", 263, 9, 4.5),
                new Song(228, "Summers Over Interlude", 77, 9, 4.4),
                new Song(229, "Fire & Desire", 189, 9, 4.6),
                new Song(230, "Views", 244, 9, 4.5),
                new Song(231, "Hotline Bling", 267, 9, 4.7),

                //Drake Scorpion /10
                new Song(232, "Survival", 139, 10, 4.6),
                new Song(233, "Nonstop", 216, 10, 4.7),
                new Song(234, "Elevate", 197, 10, 4.5),
                new Song(235, "Emotionless", 298, 10, 4.6),
                new Song(236, "God's Plan", 199, 10, 4.8),
                new Song(237, "I'm Upset", 208, 10, 4.6),
                new Song(238, "8 Out of 10", 259, 10, 4.5),
                new Song(239, "Mob Ties", 172, 10, 4.7),
                new Song(240, "Can't Take a Joke", 171, 10, 4.6),
                new Song(241, "Sandra's Rose", 191, 10, 4.5),
                new Song(242, "Talk Up", 220, 10, 4.7),
                new Song(243, "Is There More", 229, 10, 4.6),
                new Song(244, "Peak", 217, 10, 4.5),
                new Song(245, "Summer Games", 235, 10, 4.6),
                new Song(246, "Jaded", 282, 10, 4.7),
                new Song(247, "Nice for What", 205, 10, 4.8),
                new Song(248, "Finesse", 134, 10, 4.6),
                new Song(249, "Ratchet Happy Birthday", 179, 10, 4.5),
                new Song(250, "That's How You Feel", 224, 10, 4.7),
                new Song(251, "Blue Tint", 138, 10, 4.6),
                new Song(252, "In My Feelings", 217, 10, 4.5),
                new Song(253, "Don't Matter to Me", 247, 10, 4.7),
                new Song(254, "After Dark", 257, 10, 4.6),
                new Song(255, "Final Fantasy", 145, 10, 4.5),
                new Song(256, "March 14", 284, 10, 4.6),
                    
               

                //Travis Scott AstroWorld /13

                new Song(257, "STARGAZING", 248, 13, 4.7),
                new Song(258, "CAROUSEL", 192, 13, 4.6),
                new Song(259, "SICKO MODE", 312, 13, 4.8),
                new Song(260, "R.I.P. SCREW", 222, 13, 4.7),
                new Song(261, "STOP TRYING TO BE GOD", 314, 13, 4.6),
                new Song(262, "NO BYSTANDERS", 235, 13, 4.7),
                new Song(263, "SKELETONS", 199, 13, 4.6),
                new Song(264, "WAKE UP", 163, 13, 4.5),
                new Song(265, "5% TINT", 166, 13, 4.7),
                new Song(266, "NC-17", 169, 13, 4.6),
                new Song(267, "ASTROTHUNDER", 184, 13, 4.7),
                new Song(268, "YOSEMITE", 200, 13, 4.6),
                new Song(269, "CAN'T SAY", 211, 13, 4.5),
                new Song(270, "WHO? WHAT!", 133, 13, 4.7),
                new Song(271, "BUTTERFLY EFFECT", 180, 13, 4.6),
                new Song(272, "HOUSTONFORNICATION", 207, 13, 4.7),
                new Song(273, "COFFEE BEAN", 183, 13, 4.6),
                     

                //Nicki Minaj The Pinkprint /15

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


                //Jcole KOD /17

                new Song(297, "Intro", 214, 17, 4.6),
                new Song(298, "KOD", 198, 17, 4.7),
                new Song(299, "Photograph", 216, 17, 4.6),
                new Song(300, "The Cut Off", 263, 17, 4.7),
                new Song(301, "ATM", 220, 17, 4.6),
                new Song(302, "Motiv8", 193, 17, 4.5),
                new Song(303, "Kevin's Heart", 205, 17, 4.6),
                new Song(304, "BRACKETS", 272, 17, 4.7),
                new Song(305, "Once an Addict (Interlude)", 145, 17, 4.6),
                new Song(306, "FRIENDS", 206, 17, 4.5),
                new Song(307, "Window Pain (Outro)", 277, 17, 4.6),


                //Post Malone Hollywood's Bleeding /21

                new Song(308, "Hollywood's Bleeding", 182, 21, 4.5),
                new Song(309, "Saint-Tropez", 159, 21, 4.6),
                new Song(310, "Enemies", 195, 21, 4.7),
                new Song(311, "Allergic", 149, 21, 4.6),
                new Song(312, "A Thousand Bad Times", 188, 21, 4.5),
                new Song(313, "Circles", 202, 21, 4.6),
                new Song(314, "Die for Me", 248, 21, 4.7),
                new Song(315, "On the Road", 239, 21, 4.6),
                new Song(316, "Take What You Want", 245, 21, 4.5),
                new Song(317, "I'm Gonna Be", 183, 21, 4.6),
                new Song(318, "Staring at the Sun", 211, 21, 4.7),
                new Song(319, "Sunflower", 158, 21, 4.6),
                new Song(320, "Internet", 181, 21, 4.5),
                new Song(321, "Goodbyes", 210, 21, 4.6),
                new Song(322, "Myself", 141, 21, 4.7),
                new Song(323, "I Know", 172, 21, 4.6),
                new Song(324, "Wow.", 149, 21, 4.5)
                
            }
                );
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist(1,"Tyler The Creator","Male"),
                new Artist(2,"Frank Ocean","Male"),
                new Artist(3,"Madonna", "Female"),
                new Artist(4, "Kendrick Lamar","Male"),
                new Artist(5, "Cardi B", "Female"),
                new Artist(6, "Drake", "Male"),
                new Artist(7,"Megan Thee Stallion", "Female"),
                new Artist( 8, "Travis Scott", "Male"),
                new Artist( 9,  "Nicki Minaj",  "Female"),
                new Artist( 10,  "J. Cole","Male"),
                new Artist( 11, "Lizzo",  "Female"),
                new Artist( 12, "Lil Nas X",  "Male"),
                new Artist( 13, "Post Malone",  "Male")
            });
            
        }




    }
}
