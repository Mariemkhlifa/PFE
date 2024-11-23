using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class Lit
    {
        [Key]
        public int Num_Lit { get; set; }
        public string nom_Dr { get; set; } = string.Empty;
        public ICollection<Secteur>? secteur { get; set; }

    }
}
