using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;


namespace Business.Concrete
{
    public class BuildingService : IBuildingService
    {
        private IBuildingDal _buildingDal;

        public BuildingService(IBuildingDal buildingDal)
        {
            _buildingDal = buildingDal;
        }

        public IResult Add(Building building)
        {
			var existBuilding = _buildingDal.Get(p => p.BuildingName == building.BuildingName);
			if (existBuilding != null)
			{
				return new ErrorResult(Messages.BuildingAlreadyExists);
			}
			_buildingDal.Add(building);
            return new SuccessResult(Messages.BuildingAdded);
        }

        public IResult Delete(Building building)
        {
            _buildingDal.Delete(building);
            return new SuccessResult(Messages.BuildingDeleted);
        }

        public IDataResult<Building> GetById(int buildingId)
        {
            return new SuccessDataResult<Building>(_buildingDal.Get(p => p.BuildingId == buildingId));
        }

        public IDataResult<List<Building>> GetList()
        {
            return new SuccessDataResult<List<Building>>(_buildingDal.GetList().ToList());
        }

        public IResult Update(Building building)
        {
            _buildingDal.Update(building);
            return new SuccessResult(Messages.BuildingUpdated);
        }
    }

}
