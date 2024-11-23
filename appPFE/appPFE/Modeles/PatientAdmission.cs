namespace appPFE.Modeles
{
    public class PatientAdmission
    {

        public int Ipp { get; set; }
        public Patient? Patient { get; set; }

        public int Num_adm { get; set; }
        public Admission? Admission { get; set; }
    }
}
