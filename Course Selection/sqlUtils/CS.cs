namespace Course_Selection.sqlUtils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CS
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string scodeno { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(7)]
        public string cno { get; set; }
    }
}
