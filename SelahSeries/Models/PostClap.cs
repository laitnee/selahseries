using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SelahSeries.Models
{
    
    public class PostClap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostClapId { get; set; }
        public Post Post { get; set; }
        public int Claps { get; set; }
    }
}
