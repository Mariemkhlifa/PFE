using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class StatuImmunitaire
    {
        [Key]
        public int num_statut { get; set; }
        public string type_statut { get; set; } = String.Empty;
        public DataType dateToxoplasme { get; set; }
        public string termeToxoplasme { get; set; } = String.Empty;
        public string resultatToxoplasme { get; set; } = String.Empty;
        public DataType dateRubecole { get; set; }
        public string termeRubecole { get; set; } = String.Empty;
        public string resultatRubecole { get; set; } = String.Empty;
        public DataType dateSyphilis { get; set; }
        public string termeSyphilis { get; set; } = String.Empty;
        public string resultatSyphilis { get; set; } = String.Empty;
        public DataType dateAgHBs { get; set; }
        public string termeAgHBs { get; set; } = String.Empty;
        public string resultatAgHBs { get; set; } = String.Empty;
        public DataType dateHVC { get; set; }
        public string termeHVC { get; set; } = String.Empty;
        public string resultatHVC { get; set; } = String.Empty;
        public DataType dateHIC { get; set; }
        public string termeHIC { get; set; } = String.Empty;
        public string resultatHIC { get; set; } = String.Empty;
        public DataType dateCMV { get; set; }
        public string termeCMV { get; set; } = String.Empty;
        public string resultatCMV { get; set; } = String.Empty;


        public int id_gros { get; set; }
        public Grossesse? Grossesse { get; set; } 





    }
}
