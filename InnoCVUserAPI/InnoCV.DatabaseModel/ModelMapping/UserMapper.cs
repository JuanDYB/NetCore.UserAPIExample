using InnoCV.DatabaseModel.Database.Model;
using InnoCV.Model.ViewModel;

namespace InnoCV.DatabaseModel.ModelMapping
{
    public class UserMapper : IMapper<T_USER, User>
    {
        public T_USER MapToEntity(User VModel)
        {
            return new T_USER
            {
                OID = VModel.Id,
                NAME = VModel.Name.Trim(),
                BIRTH_DATE = VModel.BirthDate
            };
        }

        public User MapToView(T_USER Entity)
        {
            return new User
            {
                Id = Entity.OID,
                Name = Entity.NAME,
                BirthDate = Entity.BIRTH_DATE
            };
        }
    }
}
