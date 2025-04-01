using Opdracht_S6_ASPSEC_06.Data;
using System.ComponentModel.DataAnnotations;

namespace Opdracht_S6_ASPSEC_06.Models
{
    public class ToetsResultaat
    {
        [Key]
        public int ResultaatId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int VakId { get; set; }
        public Vak Vak { get; set; }
        public decimal Cijfer { get; set; }
        public DateTime Datum { get; set; }
    }
}
