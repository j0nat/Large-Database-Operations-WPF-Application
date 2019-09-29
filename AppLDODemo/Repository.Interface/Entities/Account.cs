using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Repository.Interface.Entities
{
    [Table("account")]
    public class Account
    {
        [Key]
        [Column("id")]
        public Int64 id { get; set; }

        [Column("name")]
        public string name { get; set; }
    }
}
