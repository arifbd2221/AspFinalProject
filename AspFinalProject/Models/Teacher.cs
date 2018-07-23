namespace AspFinalProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string department { get; set; }

        [StringLength(50)]
        public string designation { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(50)]
        public string gender { get; set; }
    }
}
