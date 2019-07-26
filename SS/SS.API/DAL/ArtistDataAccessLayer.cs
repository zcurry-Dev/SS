
using Microsoft.EntityFrameworkCore;
using SS.API.EFModels;
using System.Collections.Generic;
using System.Linq;

namespace SS.API.DAL
{
    public class ArtistDataAccessLayer
    {
        SceneSwarm01Context db = new SceneSwarm01Context();

        public IEnumerable<Artists> GetAllArtists()
        {
            try
            {
                return db.Artists.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new artist record
        public int AddArtist(Artists artist)
        {
            try
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar artist  
        public int UpdateArtist(Artists artist)
        {
            try
            {
                db.Entry(artist).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }


        //Get the details of a particular artist  
        public Artists GetArtistData(int id)
        {
            try
            {
                Artists artist = db.Artists.Find(id);
                return artist;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular artist  
        public int DeleteArtist(int id)
        {
            try
            {
                Artists artist = db.Artists.Find(id);
                db.Artists.Remove(artist);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }
}
