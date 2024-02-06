using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResults Add(User user);
        IDataResult<User> GetByUserId(int id);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(int user);
        IResults Delete(User user);
      // --------------------------------------------
        IResults Update(User user);
       IDataResult< List<OperationClaim>> GetClaims(User user);
        User GetByMail(string email);
    }
}
