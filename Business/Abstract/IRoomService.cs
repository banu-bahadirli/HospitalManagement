using Core.Utilities.Results;
using Entities.Concrete;


namespace Business.Abstract
{
	public interface IRoomService
	{
		IDataResult<Room> GetById(int roomId);

		IDataResult<List<Room>> GetList();

		IResult Add(Room room);

		IResult Update(Room room);

		IResult Delete(Room room);
	}
}
