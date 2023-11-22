using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IRepository<Artist> repo;
        
        #region CRUD_Methods
        public ArtistLogic(IRepository<Artist> repo)
        {
            this.repo = repo;
        }

        public void Create(Artist item)
        {
            if (item?.ArtistName.Length <= 2 || item is null)
            {
                throw new ArgumentException();
            }
            else
            {
                repo.Create(item);
            }
        }
        public void Delete(int id)
        {
            var artist = repo.Read(id);
            if (artist == null)
            {
                throw new ArgumentException();//Exception handling
            }
            else
            {
                repo.Delete(id);
            }
        }
        public Artist Read(int id)
        {
            var artist = repo.Read(id);
            if (artist == null)
            {
                throw new ArgumentException();
            }
            return repo.Read(id);
        }
        public IQueryable<Artist> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Artist item)
        {
            try
            {
                Read(item.ArtistID);
                this.repo.Update(item);
            }
            catch (Exception)
            {

                throw new ArgumentException();
            }
        }
        #endregion

        #region Non-CRUD_Methods
        //An artist's best album? 

        public IEnumerable<Album> AnArtistsBestAlbum(int artistID) //client tested+, tested
        {
            //need to test if an artist id is not found

            try
            {
                Read(artistID);
                var album = ReadAll()
                .Where(t => t.ArtistID == artistID)
                .Select(t => t.Albums.OrderByDescending(t => t.Rating).ToList())
                .FirstOrDefault()
                .FirstOrDefault();

                return new List<Album> { album };
            }
            catch (ArgumentException e)
            {

                throw e;
            }
        }


        public IEnumerable<double> ArtistsAvarageRating(int artistID)//client tested+
        {
            try
            {
                //Read(artistID); //this one throws an exception if the id is not found , Argument exception
                //repo.Read(artistID)  // this one doesnt work when the id is correct

                Read(artistID);// this one doesnt throw an exception
                               //this one doesnt work when the id is incorrect
                var artist = repo.ReadAll()
                .Where(t => t.ArtistID == artistID)
                .Select(t => t.Albums.Average(t => t.Rating))
                .AsEnumerable();
                return artist;

            }

            catch (ArgumentException e) // this one happens when an id is not found and was thrown by the Read method
            {

                throw e;
            }

        }
        #endregion

    }
}
