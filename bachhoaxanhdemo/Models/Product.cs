namespace bachhoaxanhdemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int idProduct { get; set; }

        [StringLength(100)]
        public string productName { get; set; }

        public double? productPrice { get; set; }

        [StringLength(50)]
        public string tradeMark { get; set; }

        [StringLength(50)]
        public string madeIn { get; set; }

        [StringLength(500)]
        public string ingredient { get; set; }

        [StringLength(500)]
        public string howToUse { get; set; }

        public double? weight { get; set; }

        [StringLength(500)]
        public string preservation { get; set; }

        [StringLength(1000)]
        public string decription { get; set; }

        [StringLength(2000)]
        public string image { get; set; }

        public int? idProductTitle { get; set; }

        public virtual ProductTitle ProductTitle { get; set; }
    }
}
