using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManeger : IUserService
    {
        IUser _user;
        public UserManeger(IUser userdal)
        {
            _user=userdal;
        }
        [ValidationAspect(typeof(UserValidation))]
        public IDataResult< List<OperationClaim>> GetClaims(User user)
        {
            return new SuccsessDataResult<List<OperationClaim>> (_user.GetClaims(user), "mesaj");
        }

        
        public User GetByMail(string email)
        {
            return _user.Get(u => u.Email == email);
        }
       // ----------------------
        public IResults Add(User user)
        {
            _user.Add(user);

            return new SuccessResult(Messages.CarAdded);
        }

        public IResults Delete(User user)
        {
            _user.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccsessDataResult<List<User>>(_user.GetAll(), Messages.CartsListed);
        }

        public IDataResult<User> GetById(int user)
        {
            return new SuccsessDataResult<User>(_user.Get(u => u.UserId == user), Messages.CartsListed);
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccsessDataResult<User>(_user.Get(p => p.UserId == id), Messages.CartsListed);
            //  return new SuccsessDataResult<Rental>(_rental.Get( p => p.RentalId == id),Messages.CartsListed);
            // return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==id),Messages.UserDetailBrought);
        }

        public IResults Update(User user)
        {
          _user.Update(user);
            return new SuccessResult();

        }
    }
}
