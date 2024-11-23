using System.ComponentModel.DataAnnotations;

namespace appPFE.Modeles
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public string nom_user { get; set; } = string.Empty;
        public int num_tel { get; set; }
        public string prenom_user { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string situation { get; set; } = string.Empty;
        public int createdby { get; set; }
        public DateTime createdat { get; set; } 
        public int updatedby { get; set; }
        public DateTime updatedat { get; set; } 
        public bool statut { get; set; }
        public string token { get; set; } = string.Empty;
        public string refreshToken { get; set; } = string.Empty;
        public DateTime refreshTokenExpiryTime { get; set; }


        public ICollection<UserRole>? UserRoles { get; set; }

        public ICollection<PatientUser>? PatientUsers { get; set; }





    }
}
