using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Repository
{
    public class AlbumRepository : Repository<Album>,IRepository<Album>
    {
        public AlbumRepository(MyMusicDbContext ctx) : base(ctx)
        {
        }

        public override Album Read(int id)
        {
            return ctx.Albums.FirstOrDefault(t => t.AlbumID == id);
        }

        public override void Update(Album item)
        {
            var old = Read(item.AlbumID);
            foreach ( var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
