using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace demoForm.Models
{
    public class que
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Ques { get; set; }
        public string Op1 { get; set; }
        public string Op2 { get; set; }
        public string Op3 { get; set; }
        public string Op4 { get; set; }
       // public int Ans { get; set; }
    }
    public class queSet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int AccountID { get; set; }
        public string QuesSet { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageUpload { get; set; }
    }

        public class Survey : DbContext
    {

        public DbSet<que> Ques { get; set; }
        public DbSet<queSet> QueSet { get; set; }

    }
}