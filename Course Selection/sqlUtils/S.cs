namespace Course_Selection.sqlUtils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class S
    {
        [Key]
        [StringLength(9)]
        public string sno { get; set; }

        [Required]
        [StringLength(10)]
        public string sname { get; set; }

        [StringLength(2)]
        public string ssex { get; set; }

        [StringLength(5)]
        public string scodeno { get; set; }

        [Column("class")]
        [StringLength(6)]
        public string _class { get; set; }
    }
}
