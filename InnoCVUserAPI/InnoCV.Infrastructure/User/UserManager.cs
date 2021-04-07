using InnoCV.DatabaseModel.Database;
using InnoCV.DatabaseModel.Database.Model;
using InnoCV.DatabaseModel.ModelMapping;
using InnoCV.Model.ExceptionModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InnoCV.Infrastructure.User
{
    /// <summary>
    /// Class to manage system users
    /// </summary>
    public class UserManager
    {
        private readonly InnoCVEntities Db;
        private readonly UserMapper UMapper = new UserMapper();

        /// <summary>
        /// Constructor of UserManager
        /// </summary>
        /// <param name="Db">Database Context</param>
        public UserManager(InnoCVEntities Db)
        {
            this.Db = Db;
        }

        /// <summary>
        /// Add new user to database
        /// </summary>
        /// <param name="User"></param>
        public void AddUser(Model.ViewModel.User User)
        {
            T_USER UserEntity = UMapper.MapToEntity(User);
            if (!UserNameExists(UserEntity.NAME))
            {
                //Set Id to zero because database is set to autoincrement
                UserEntity.OID = 0;
                Db.T_USER.Add(UserEntity);
                Db.SaveChanges();
            }
            else
            {
                throw new UserAlreadyExistsException();
            }
        }

        /// <summary>
        /// Modify User
        /// </summary>
        /// <param name="User"></param>
        public void ModifyUser(Model.ViewModel.User User)
        {
            if (UserIdExists(User.Id))
            {
                T_USER NewUserEntity = UMapper.MapToEntity(User);
                Db.Attach(NewUserEntity);
                Db.Entry(NewUserEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Db.SaveChanges();
            }
            else
            {
                throw new UserNotFoundException();
            }
        }

        /// <summary>
        /// Get user by User ID
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public Model.ViewModel.User GetUser(int UserId)
        {
            T_USER UserEntity = GetUserById(UserId);
            if (UserEntity != null)
            {
                return UMapper.MapToView(UserEntity);
            }
            else
            {
                throw new UserNotFoundException();
            }
        }

        /// <summary>
        /// Delete User specified by User ID
        /// </summary>
        /// <param name="UserId"></param>
        public void DeleteUser(int UserId)
        {
            T_USER UserEntity = GetUserById(UserId);
            if (UserEntity != null)
            {
                Db.T_USER.Remove(UserEntity);
                Db.SaveChanges();
            }
            else
            {
                throw new UserNotFoundException();
            }
        }

        /// <summary>
        /// Get all users 
        /// </summary>
        /// <returns></returns>
        public List<Model.ViewModel.User> GetUsers()
        {
            if (Db.T_USER.Any())
            {
                return Db.T_USER.Select(U => UMapper.MapToView(U)).ToList();
            }
            else
            {
                throw new UsersEmptyException();
            }
        }

        /// <summary>
        /// Get all users to call if you want to execute async
        /// </summary>
        /// <returns></returns>
        public Task<List<Model.ViewModel.User>> GetUsersAsyc()
        {
            return Task.FromResult(GetUsers());
        }

        /// <summary>
        /// Check if exists any user with the given name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool UserNameExists(string Name)
        {
            return Db.T_USER.Any(U => U.NAME.Equals(Name));
        }

        /// <summary>
        /// Check if User Id Exists
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private bool UserIdExists(int Id)
        {
            return Db.T_USER.Any(U => U.OID == Id);
        }

        /// <summary>
        /// Get User Entity by it's key
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private T_USER GetUserById(int Id)
        {
            return Db.T_USER.Find(Id);
        }
    }
}
