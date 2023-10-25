using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Repository
{
    public class SongRepository : Repository<Song>, IRepository<Song>
    {
        public SongRepository(MyMusicDbContext ctx) : base(ctx)
        {
        }

        public override Song Read(int id)
        {
            return ctx.Songs.FirstOrDefault(t => t.SongID == id);
        }

        public override void Update(Song item)
        {
            var old = Read(item.SongID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
