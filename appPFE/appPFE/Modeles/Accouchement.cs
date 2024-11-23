using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class Accouchement
    {
        [Key]
        public int id_Acc { get; set; }
        public int Num_Acc { get; set; }
        public DateTime date_acc { get; set; }
        public string lieu { get; set; } = string.Empty;
        public string nom_Dr { get; set; } = string.Empty;
        public int num_tel { get; set; }
        public DateOnly date_Repture { get; set; }
        public int duree_repture { get; set; }
        public string type_Repture { get; set; } = string.Empty;
        public string abondanceLiquideAmniotique{get; set;} = string.Empty;
        public string couleurLiquideAmniotique { get; set; } = string.Empty;
        public string odeurLiquideAmniotique { get; set; } = string.Empty;
        public string type_travail { get; set; } = string.Empty;
        public int duree_travail { get; set; }
        public string passif { get; set; } = string.Empty;
        public string actif { get; set; } = string.Empty;
        public string rcf { get; set; } = string.Empty;
        public string mode_acc { get; set; } = string.Empty;
        public int dilatation { get; set; }
        public string typeCesarienne { get; set; } = string.Empty;
        public string indicationCesarienne { get; set; } = string.Empty;
        public string instrumentale { get; set; } = string.Empty;
        public string anesthesie { get; set; } = string.Empty;
        public string type_Presentation { get; set; } = string.Empty;
        public string etat_Cordon { get; set; } = string.Empty;
        public string preciserEtatCordon { get; set; } = string.Empty;
        public string etat_Placenta { get; set; } = string.Empty;
        public string preciserEtatPlacenta { get; set; } = string.Empty;
        public string desobstruction { get; set; } = string.Empty;
        public string O2_debit { get; set; } = string.Empty;
        public string aspiration_laryngoscope { get; set; } = string.Empty;
        public string ventilation_masque{ get; set; } = string.Empty;
        public string intubation { get; set; } = string.Empty;
        public string ventilation_tube { get; set; } = string.Empty;
        public string medicament { get; set; } = string.Empty;
        public int pn { get; set; }
        public int tn{ get; set; }
        public int pcn { get; set; }
        public string type_permeabiliteOrifices { get; set; } = string.Empty;
        public string type_prelevementMere { get; set; } = string.Empty;
        public string type_prelevementNN { get; set; } = string.Empty;


        public int AccId { get; set; }
        public AntecedentPersonnels? antecedentPersonnels { get; set; }


    }
}
