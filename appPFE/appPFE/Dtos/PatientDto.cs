using System.ComponentModel.DataAnnotations;

namespace appPFE.Dtos
{
    public class PatientDto
    {
        [Key]
        public int Ipp { get; set; }
        public string matricule { get; set; } = string.Empty;
        public string nom { get; set; } = string.Empty;
        public string prenom { get; set; } = string.Empty;
        public DateTime dateNaiss { get; set; }
        public string adresse { get; set; } = string.Empty;
        public string lieu { get; set; } = string.Empty;
        public string sexe { get; set; } = string.Empty;
        public int priseChargeSociale { get; set; }
        public int tel_Mere { get; set; }
        public int tel_Pere { get; set; }
    }
}
