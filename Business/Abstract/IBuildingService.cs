using Core.Utilities.Results;
using Entities.Concrete;


namespace Business.Abstract
{
    public interface IBuildingService
    {
        IDataResult<Building> GetById(int buildingId);

        IDataResult<List<Building>> GetList();

        IResult Add(Building building);

        IResult Update(Building building);

        IResult Delete(Building building);
    }
}
