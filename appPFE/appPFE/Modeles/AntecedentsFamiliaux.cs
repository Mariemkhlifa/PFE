using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class AntecedentsFamiliaux
    {
        [Key]
        public int Id_AntecF { get; set; }
         public string interrogation{ get; set; } = string.Empty;
        public DateOnly date_interogation { get; set; }
        public string nomPrenomPere { get; set; } = string.Empty;
        public string nomPrenomMere { get; set; } = string.Empty;
        public DateTime dateMariage { get; set; }
        public int nbreAnneeMariage { get; set; }
        public int AgePere { get; set; }
        public int AgeMere { get; set; }
        public DateTime dateNaissPere { get; set; }
        public DateTime dateNaissMere { get; set; }
        public string gouvernementPere { get; set; } = string.Empty;
        public string gouvernementMere { get; set; } = string.Empty;
        public string poidsPere { get; set; } = string.Empty;
        public string poidsMere { get; set; } = string.Empty;
        public string taillePere { get; set; } = string.Empty;
        public string tailleMere { get; set; } = string.Empty;
        public string gs_rhesusPere { get; set; } = string.Empty;
        public string gs_rhesusMere { get; set; } = string.Empty;
        public string niveauEtudeMere { get; set; } = string.Empty;
        public string niveauEtudePere { get; set; } = string.Empty;
        public string ProfessionSocialePere { get; set; } = string.Empty;
        public string ProfessionSocialeMere { get; set; } = string.Empty;
        public string militaire { get; set; } = string.Empty;
        public string consanguinite { get; set; } = string.Empty;
        public string addictionsSocialeP { get; set; } = string.Empty;
        public string addictionsSocialeM { get; set; } = string.Empty;
        public string antecedentpMedicauxPere { get; set; } = string.Empty;
        public string antecedentpMedicauxMere { get; set; } = string.Empty;
        public string antecedentChirurgicauxPere { get; set; } = string.Empty;
        public string antecedentChirurgicauxMere { get; set; } = string.Empty;
        public string gynecoObsetetricaux { get; set; } = string.Empty;


        public int PatientIpp { get; set; }
        public Patient? Patient { get; set; }




    }
}
