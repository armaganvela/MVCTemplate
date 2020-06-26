using Test.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUserService
    {
        List<ApplicationUser> GetUsers();

        void Update(ApplicationUser user);

        ApplicationUser GetUser(string userId);
    }
}
