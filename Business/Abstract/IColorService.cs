using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
         IDataResult<List<Color>> GetByColordId(int id);
        IDataResult<Color> GetById(int color);
        IResults Add(Color  color);
        IResults Delete(Color color);
        IResults Update(Color color);

    }
}
