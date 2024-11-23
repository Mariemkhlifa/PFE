using appPFE.Dtos;
using appPFE.Modeles;
using AutoMapper; 
namespace appPFE.Helper
    
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<UserDto, User>();
            CreateMap<PatientDto, Patient>();
            CreateMap<RoleDto, Role>();
            CreateMap<AntecedentFamiliauxDto, AntecedentsFamiliaux>();
            CreateMap<ExamenRespiratoireDto, ExamenRespiratoire>();
            CreateMap<EvolutionDto, Evolution>();
            CreateMap<AdmissionDto, Admission>();
            CreateMap<UserRoleDto, UserRole>();




        }
    }
}
