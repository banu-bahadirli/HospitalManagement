using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class StoreService : IStoreService
    {
        private IStoreDal _storeDal;

        public StoreService(IStoreDal storeDal)
        {
            _storeDal = storeDal;
        }
        public IResult Add(Store store)
        {
            _storeDal.Add(store);
            return new SuccessResult(Messages.StoreAdded);
        }

        public IResult Delete(Store store)
        {
            _storeDal.Delete(store);
            return new SuccessResult(Messages.StoreDeleted);
        }

        public IDataResult<Store> GetById(int storeId)
        {
            return new SuccessDataResult<Store>(_storeDal.Get(p => p.StoreId == storeId));
        }

        public IDataResult<List<Store>> GetList()
        {
            return new SuccessDataResult<List<Store>>(_storeDal.GetList().ToList());
        }

        public IResult Update(Store store)
        {
            _storeDal.Update(store);
            return new SuccessResult(Messages.StoreUpdated);
        }
    }
}
