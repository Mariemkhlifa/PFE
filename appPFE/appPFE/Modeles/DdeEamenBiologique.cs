using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class DdeEamenBiologique
    {
        [Key]
        public int Num_Dde { get; set; }
        public int ipp { get; set; }
        public DateOnly dateDde  {get;set;}
        public string description { get; set; } = string.Empty;
    }
}
