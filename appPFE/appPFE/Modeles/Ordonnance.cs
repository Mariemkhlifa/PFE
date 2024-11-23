using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class Ordonnance
    {
        [Key]
        public int num_Ord { get; set; }
        public DateOnly date_ordonnance { get; set; }
    }
}
