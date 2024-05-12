using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace Business.Concrete
{
	internal class RoomService : IRoomService
	{
		private IRoomDal _roomDal;

		public RoomService(IRoomDal roomDal)
		{
            _roomDal = roomDal;
		}

		public IResult Add(Room room)
		{
			var existRoom = _roomDal.Get(p =>p.RoomName == room.RoomName);
			if (existRoom != null)
			{
				return new ErrorResult(Messages.RoomAlreadyExists);
			}
			_roomDal.Add(room);
            return new SuccessResult(Messages.RoomAdded);
        }

		public IResult Delete(Room room)
		{
            _roomDal.Delete(room);
            return new SuccessResult(Messages.RoomDeleted);
        }

		public IDataResult<Room> GetById(int roomId)
		{
            return new SuccessDataResult<Room>(_roomDal.Get(p => p.RoomId == roomId));
        }

		public IDataResult<List<Room>> GetList()
		{
			return new SuccessDataResult<List<Room>>(_roomDal.GetList().ToList());
		}

		public IResult Update(Room room)
		{
            var existRoom = _roomDal.Get(p => p.RoomName == room.RoomName);
            if (existRoom != null)
            {
                return new ErrorResult(Messages.RoomAlreadyExists);
            }
            _roomDal.Update(room);
            return new SuccessResult(Messages.RoomUpdated);
        }
	}
}
