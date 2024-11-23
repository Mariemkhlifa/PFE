using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class AntecedentPersonnels
    {
        [Key]
        public int Id_AntecP { get; set; }
        public string types { get; set; } = string.Empty;

        public int AntIpp { get; set; }
        public Patient? Patient { get; set; }

        public int IdAcc { get; set; }
        public Accouchement? accouchement { get; set; }
    }
}
