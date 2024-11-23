using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class EchographiesAnténatales
    {
        [Key]
        public int id_eco { get; set; }
        public int Num_eco { get; set; }
        public string nom_opérateur { get; set; } = string.Empty;
        public string résultat { get; set; } = string.Empty;
        public string type_datation { get; set; } = string.Empty;
        public string nomOp_datation { get; set; } = string.Empty;
        public string resultatOp_datation { get; set; } = string.Empty;
        public string type_morphologiquePrécoce { get; set; } = string.Empty;
        public string nomOp_morphologiquePrécoce { get; set; } = string.Empty;
        public string resultatOp_morphologiquePrécoce { get; set; } = string.Empty;
        public string type_morphologiqueTardive { get; set; } = string.Empty;
        public string nomOp_morphologiqueTardive { get; set; } = string.Empty;
        public string resultatOp_morphologiqueTardive { get; set; } = string.Empty;

        public int id_gros { get; set; }
        public Grossesse? Grossesse { get; set; }


    }
}
