using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class ColorManeger : IColorService
    {
        IColorDal _colorDal;
        public ColorManeger(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidation))]
        public IResults Add(Color color)
        {
           _colorDal.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResults Delete(Color color)
        {
           _colorDal.Delete(color);
            return new SuccessResult(Messages.CarDelete);
        }

        public IDataResult< List<Color>> GetAll()
        {
           return new SuccsessDataResult<List<Color>> (_colorDal.GetAll() , Messages.CartsListed );
            
        }

        public IDataResult<List<Color>> GetByColordId(int id)
        {
           return new SuccsessDataResult<List<Color>> (_colorDal.GetAll(p=>p.ColourId == id));

        }

        public IDataResult<Color> GetById(int color)
        {
            return new SuccsessDataResult<Color>(_colorDal.Get(b => b.ColourId == color),Messages.CartsListed);
        }

        public IResults Update(Color color)
        {
           _colorDal.Update(color);
            return new SuccessResult(Messages.CarUpdate);

        }
    }
}
