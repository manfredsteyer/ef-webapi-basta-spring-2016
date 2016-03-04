namespace HotelApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hotel")]
    public partial class Hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hotel()
        {
            HotelBuchung = new HashSet<HotelBuchung>();
        }

        public int HotelId { get; set; }

        [Required]
        [StringLength(50)]
        public string Bezeichnung { get; set; }

        public int Sterne { get; set; }

        public int RegionId { get; set; }

        [StringLength(255)]
        public string BildPfad { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] LastUpdate { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        public decimal? Preis { get; set; }

        public virtual Region Region { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HotelBuchung> HotelBuchung { get; set; }
    }
}
