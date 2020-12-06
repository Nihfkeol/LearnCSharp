namespace Course_Selection.sqlUtils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SLogin")]
    public partial class SLogin
    {
        [Key]
        [StringLength(9)]
        public string sno { get; set; }

        [Required]
        [StringLength(20)]
        public string spaw { get; set; }
    }
}
