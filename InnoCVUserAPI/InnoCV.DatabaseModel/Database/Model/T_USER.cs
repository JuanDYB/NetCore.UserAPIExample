using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoCV.DatabaseModel.Database.Model
{
    public class T_USER
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OID { get; set; }

        [Required]
        [MaxLength(100)]
        public string NAME { get; set; }
        
        [Required]
        public DateTime BIRTH_DATE { get; set; }
    }
}
