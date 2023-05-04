using RegisterAndLoginApp.Models;

namespace RegisterAndLoginApp.Service
{
    public class SecurityService
    {
        SecurityDAO securityDAO = new SecurityDAO();
        public bool IsValid(UserModel user)
        {
            return securityDAO.GetByNameAndPassword(user);
        }

        
    }
}
