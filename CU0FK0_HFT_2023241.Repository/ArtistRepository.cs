using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Repository
{
    public class ArtistRepository : Repository<Artist>, IRepository<Artist>
    {
        public ArtistRepository(MyMusicDbContext ctx) : base(ctx)
        {
        }

        public override Artist Read(int id)
        {
            return ctx.Artists.FirstOrDefault(t => t.ArtistID == id);
        }

        public override void Update(Artist item)
        {
            var old = Read(item.ArtistID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
