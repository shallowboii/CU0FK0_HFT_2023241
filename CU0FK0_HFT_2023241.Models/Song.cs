using Newtonsoft.Json;
using System.Text.Json.Serialization;
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
        public double SongRating { get; set; }

        public int AlbumID { get; set; }

        public int SongLenght { get; set; }
        public virtual Album Album { get; set; }


        public Song()
        {

        }
        public Song(int SongID,string SongTitle, int SongLenght, int albumID, double songRating)
        {
            this.SongID = SongID;
            this.SongTitle = SongTitle;
            this.SongLenght = SongLenght;
            AlbumID = albumID;
            SongRating = songRating;
        }
        public override bool Equals(object obj)
        {
            Song b = obj as Song;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.SongID == b.SongID && this.SongTitle == b.SongTitle;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.SongID, this.SongTitle);
        }

    }
}
