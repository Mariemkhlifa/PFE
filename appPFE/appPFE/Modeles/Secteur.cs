using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class Secteur
    {
        [Key]
        public int Num_Sec { get; set; }
        public string nom_Dr { get; set; }
        public ICollection<Lit>? lit { get; set; }

    }
}
