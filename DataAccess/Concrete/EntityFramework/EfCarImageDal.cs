using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, Context>, ICarImageDal
    {
        public bool IsExist(int id)
        {
            using (Context context = new Context())
            {
                return context.CarImages.Any(c => c.ImageId == id);
            }
        }
    }
}
