namespace HotelApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    [Table("HotelBuchung")]
    public partial class HotelBuchung: IEntityWithState
    {
        public int HotelBuchungId { get; set; }

        [Required]
        [StringLength(50)]
        public string Vorname { get; set; }

        [Required]
        [StringLength(50)]
        public string Nachname { get; set; }

        public int HotelId { get; set; }

        public DateTime? Ankunft { get; set; }

        public bool? Fruehstueck { get; set; }

        public DateTime? Datum { get; set; }

        public int? Naechte { get; set; }

        public decimal? Preis { get; set; }

        public virtual Hotel Hotel { get; set; }

        [NotMapped]
        public EntityState State { get; set; }
    }
}
