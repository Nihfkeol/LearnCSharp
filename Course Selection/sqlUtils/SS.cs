namespace Course_Selection.sqlUtils
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SS")]
    public partial class SS
    {
        [Key]
        [StringLength(5)]
        public string scodeno { get; set; }

        [Required]
        [StringLength(30)]
        public string ssname { get; set; }
    }
}
