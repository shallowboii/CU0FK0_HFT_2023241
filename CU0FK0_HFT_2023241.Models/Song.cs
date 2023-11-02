using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Models
{
    public class Song
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongID { get; set; }

        [Required]
        [StringLength(50)]
        public string SongTitle { get; set; }
        public int SongRating { get; set; }

        public int AlbumID { get; set; }

        public int SongLenght { get; set; }
        public virtual Album Album { get; set; }


        public Song()
        {

        }
        public Song(int SongID,string SongTitle, int SongLenght, int albumID, int songRating)
        {
            this.SongID = SongID;
            this.SongTitle = SongTitle;
            this.SongLenght = SongLenght;
            AlbumID = albumID;
            SongRating = songRating;
        }

    }
}
