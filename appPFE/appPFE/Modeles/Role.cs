using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace appPFE.Modeles
{
    public class Role
    {
        [Key]
        public int Role_id { get; set; }
        public string nomRole { get; set; } = string.Empty;

        public ICollection<UserRole>? UserRoles { get; set; }

       
    }
}

