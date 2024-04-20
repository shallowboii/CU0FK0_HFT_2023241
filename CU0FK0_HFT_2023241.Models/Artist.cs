using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CU0FK0_HFT_2023241.Models
{
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArtistID { get; set; }

        [Required]
        [StringLength(50)]
        public string ArtistName { get; set; }
        public string Gender { get; set; }
        [JsonIgnore]
        public virtual ICollection<Album> Albums { get; set; }
        
        
        public Artist()
        {

        }
        public Artist(int ArtistID,string ArtistName,string Gender)
        {
            this.ArtistID = ArtistID;
            this.ArtistName = ArtistName;
            this.Gender = Gender;
        }
        public override bool Equals(object obj)
        {
            Artist b = obj as Artist;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.ArtistID == b.ArtistID && this.ArtistName == b.ArtistName && this.Gender == b.Gender;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ArtistID, this.ArtistName,this.Gender);
        }


    }
}
