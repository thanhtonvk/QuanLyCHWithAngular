namespace QuanLyCHWithAngular.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Details { get; set; }

        [Column(TypeName = "ntext")]
        public string Image { get; set; }

        public int? Cost { get; set; }

        public int? IDCategory { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual Category Category { get; set; }
    }
}
