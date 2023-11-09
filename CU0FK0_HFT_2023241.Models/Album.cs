using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Models
{
    public class Album
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AlbumID { get; set; }

        [Required]
        [StringLength(50)]
        public string AlbumTitle { get; set; }
        public double Rating { get; set; }

        public int ArtistID { get; set; }
        public int ReleaseYear { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual Artist Artist { get; set; }

        public Album()
        {

        }
        public Album(int AlbumID,string AlbumTitle, int ArtistID, double rating,int ReleaseYear)
        {
            this.AlbumID = AlbumID;
            this.AlbumTitle = AlbumTitle;
            this.ArtistID = ArtistID;
            Rating = rating;
            this.ReleaseYear = ReleaseYear;
        }


    }
}
