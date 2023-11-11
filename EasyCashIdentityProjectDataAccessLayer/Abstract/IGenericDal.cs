using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProjectDataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class 
    {
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
        T GetById(Guid id);
        List<T> GetList();



    }

}

