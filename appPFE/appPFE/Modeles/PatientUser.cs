using Microsoft.AspNet.Identity;

namespace appPFE.Modeles
{
    public class PatientUser
    {
        public int Ipp{ get; set; }
        public Patient? Patient { get; set; }

        public int User_id { get; set; }
        public User? User { get; set; }
    }
}
