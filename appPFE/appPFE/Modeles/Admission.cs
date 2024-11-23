using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class Admission
    {

        [Key]
        public int id_adm { get; set; }
        public int Num_adm { get; set; }
        public DateTime dateDebut { get; set; }
        public string description { get; set; } = string.Empty;
        public string auTotal { get; set; } = string.Empty;
        public string conduiteATenir { get; set; } = string.Empty;
        public string discussionDiagnostique { get; set; } = string.Empty;
        public string pronosticImmediat { get; set; } = string.Empty;
        public string pronosticMoyenTerme { get; set; } = string.Empty;
        public string pronosticLongTerme { get; set; } = string.Empty;
        public string codePathologique { get; set; } = string.Empty;
        public DateTime dateSortie { get; set; } 
        public string motif { get; set; } = string.Empty;

        public int AdmissionIpp { get; set; }
        public Patient? Patient { get; set; }

        public ICollection<Evolution>? Evolutions { get; set; } = new List<Evolution>();
        public ICollection<ConditionsTransfert>? ConditionsTransferts { get; set; } = new List<ConditionsTransfert>();


    }
}
