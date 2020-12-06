namespace Course_Selection.sqlUtils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SC")]
    public partial class SC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(9)]
        public string sno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string cno { get; set; }
    }
}
