using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class Patient
    {
        [Key]
        public int Ipp { get; set; }
        public string matricule { get; set; } = string.Empty;
        public string nom { get; set; } = string.Empty;
        public string prenom { get; set; } = string.Empty;
        public DateTime dateNaiss { get; set; }
        public string adresse { get; set; } = string.Empty;
        public string lieu { get; set; } = string.Empty;
        public string  sexe { get; set; } = string.Empty;
        public int priseChargeSociale { get; set; }
        public int tel_Mere { get; set; }
        public int tel_Pere { get; set; }

        public ICollection<PatientUser>? PatientUsers { get; set; }
        public ICollection<AntecedentPersonnels>? AntecedentPersonnels { get; set; } = new List<AntecedentPersonnels>();
        public ICollection<ExamenClinique>? ExamenCliniques { get; set; } = new List<ExamenClinique>();
        public ICollection<AntecedentsFamiliaux> AntecedentsFamiliaux { get; set; } = new List<AntecedentsFamiliaux>();
        public ICollection<Admission> Admissions { get; set; } = new List<Admission>();





    }
}
