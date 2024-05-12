using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IStoreService
    {
        IDataResult<Store> GetById(int storeıd);

        IDataResult<List<Store>> GetList();

        IResult Add(Store store);

        IResult Update(Store store);

        IResult Delete(Store store);
    }
}
