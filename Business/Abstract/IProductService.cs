﻿using Core.Utilities.Results;
using Entities.Concrete;


namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);

        IDataResult<List<Product>> GetList();

        IResult Add(Product product);

        IResult Update(Product product);

        IResult Delete(Product product);
    }
}
