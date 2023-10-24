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

        [ForeignKey("ArtistID")]
        public int ArtistID { get; set; }

        public int SongLenght { get; set; }
        public virtual ICollection<Artist> Collaborators { get; set; } // can be null

        public Song()
        {

        }

    }
}
