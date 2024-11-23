using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class ConditionsTransfert
    {
        [Key]
        public int Num_Condition { get; set; }
        public DateOnly date_Transfert { get; set; }
        public string medicatise { get; set; } = string.Empty;
        public string identiteTransporteur { get; set; } = string.Empty;
        public string coordonnees  { get; set; } = string.Empty;
        public string accompagnateurs  { get; set; } = string.Empty;
        public string vehicule  { get; set; } = string.Empty;
        public string chaudModalites { get; set; } = string.Empty;
        public string chaudMoIncubateur { get; set; } = string.Empty;
        public string chaudRemarques { get; set; } = string.Empty;
        public string glucoseMVoieDabord { get; set; } = string.Empty;
        public string glucoseMSiege { get; set; } = string.Empty;
        public string glucoseRSondeGastrique { get; set; } = string.Empty;
        public string glucoseMNatureSolutes { get; set; } = string.Empty;
        public string oxygeneMTecnique { get; set; } = string.Empty;
        public string oxygeneRParametre { get; set; } = string.Empty;
        public string infromationMParents { get; set; } = string.Empty;
        public string infromationRTubeSongMere { get; set; } = string.Empty;
        public string asepieM { get; set; } = string.Empty;
        public string pendentTransfer { get; set; } = string.Empty;
        public string arriver { get; set; } = string.Empty;
        public string etatGeneral { get; set; } = string.Empty;





        public int CtAdm { get; set; }
        public Admission? Admission { get; set; }




    }
}
