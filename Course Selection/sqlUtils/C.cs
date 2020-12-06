namespace Course_Selection.sqlUtils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class C
    {
        [Key]
        [StringLength(7)]
        public string cno { get; set; }

        [Required]
        [StringLength(20)]
        public string cname { get; set; }

        public int? classh { get; set; }
    }
}
