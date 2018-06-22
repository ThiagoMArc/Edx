using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SakilaWebServer.Models {
    [Table("actor")]
    public class Actor {
        [Key]
        public int Actor_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
    }
}