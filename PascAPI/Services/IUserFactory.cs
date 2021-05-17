using PASC.DTO;
using PASC.VO;

namespace PASC.Services
{
    public interface IUserFactory
    {
        VO.User GenerateUser();
        DTO.User GenerateUserDto(VO.User user);
    }
}