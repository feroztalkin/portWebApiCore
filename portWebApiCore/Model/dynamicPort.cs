using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace portWebApiCore.Model
{
    [Table("dynamicPort")]
    public class dynamicPort
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string uniqueCode { get; set; }
        public int httpport { get; set; }
        public int httpsport { get; set; }
    }
}
