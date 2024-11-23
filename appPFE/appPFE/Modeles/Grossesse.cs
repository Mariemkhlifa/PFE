using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class Grossesse
    {
        [Key]

        public int id_gros { get; set; }
        public int num_gros { get; set; }
        public string type_gros { get; set; } = string.Empty;
        public DateOnly ddr { get; set; }
        public string termeNaissance { get; set; } = string.Empty;
        public DateOnly dateTransfertEmbryon { get; set; }
        public int nbrEmbryonsCongelés { get; set; }
        public string TermeGrossse { get; set; } = string.Empty;
        public string NomDr { get; set; } = string.Empty;
        public string Lieu { get; set; } = string.Empty;
        public string NbrConsulPrénatal { get; set; } = string.Empty;
        public DateOnly DateDernierConsul { get; set; }
        public string PathologieGrav_Ops { get; set; } = string.Empty;
        public DateOnly DateTransferEmbryen { get; set; }
        public string TypeTransfer { get; set; } = string.Empty;

        public ICollection<EchographiesAnténatales> EchographiesAnténatales { get; set; } = new List<EchographiesAnténatales>();
        public ICollection<StatuImmunitaire> StatuImmunitaire { get; set; } = new List<StatuImmunitaire>();
        public ICollection<BilanPrénatal> BilanPrénatal { get; set; } = new List<BilanPrénatal>();




    }
}
