using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Users;
using AccessControlSystem.DataAccess.Repositories.UserSchedules;
using AccessControlSystem.DataAccess.Tests.Utilities;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSchedules;
namespace AccessControlSystem.DataAccess.Tests.UserSchedulesTests
{
    [TestClass]
    public class UserScheduleTests
    {

        private IUserScheduleRepository _userScheduleRepository;
        private IUserRepository _userRepository;

        private IUnitOfWork _unitOfWork;


        public UserScheduleTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _userScheduleRepository = new UserScheduleRepository(context);
            _userRepository = new UserRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow(0)]
        [DataRow(1)]
        [TestMethod]
        public void Can_Add_UserSchedule(int position)
        {
            // Arrange

            Guid id = Guid.NewGuid();
            var users = _userRepository.GetAllUsers().ToList();

            UserSchedule userSchedule = new UserSchedule
            (users[position],
            id
            );

            // Execute
            _userScheduleRepository.AddUserSchedule(userSchedule);
            _unitOfWork.SaveChanges();

            // Assert
            UserSchedule? loadedUserSchedule = _userScheduleRepository.GetUserScheduleById(id);
            Assert.IsNotNull(loadedUserSchedule);
        }



        [DataRow(0)]
        [TestMethod]
        public void Can_Get_UserSchedule_By_Id(int position)
        {
            // Arrange
            var userSchedules = _userScheduleRepository.GetAllUserSchedules().ToList();
            Assert.IsNotNull(userSchedules);
            Assert.IsTrue(position < userSchedules.Count);
            UserSchedule userScheduleToGet = userSchedules[position];

            // Execute
            UserSchedule? loadedUserSchedule = _userScheduleRepository.GetUserScheduleById(userScheduleToGet.Id);

            // Assert
            Assert.IsNotNull(loadedUserSchedule);
        }





        [TestMethod]
        public void Cannot_Get_UserSchedule_By_Invalid_Id()
        {
            // Arrange

            // Execute
            UserSchedule? loadedUserSchedule = _userScheduleRepository.GetUserScheduleById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedUserSchedule);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Update_UserSchedule(int position)
        {
            // Arrange
            var userSchedules = _userScheduleRepository.GetAllUserSchedules().ToList();
            User user= _userRepository.GetAllUsers().First();
            Assert.IsNotNull(userSchedules);
            Assert.IsTrue(position < userSchedules.Count);
            UserSchedule userScheduleToUpdate = userSchedules[position];

            // Execute
            userScheduleToUpdate.User = user;

            _userScheduleRepository.UpdateUserSchedule(userScheduleToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            UserSchedule? loadedUserSchedule = _userScheduleRepository.GetUserScheduleById(userScheduleToUpdate.Id);
            Assert.IsNotNull(loadedUserSchedule);
            Assert.AreEqual(loadedUserSchedule.User, user);

        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_UserSchedule(int position)
        {
            // Arrange
            var userSchedules = _userScheduleRepository.GetAllUserSchedules().ToList();
            Assert.IsNotNull(userSchedules);
            Assert.IsTrue(position < userSchedules.Count);
            UserSchedule userScheduleToDelete = userSchedules[position];

            // Execute
            _userScheduleRepository.DeleteUserSchedule(userScheduleToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            UserSchedule? loadedUserSchedule = _userScheduleRepository.GetUserScheduleById(userScheduleToDelete.Id);
            Assert.IsNull(loadedUserSchedule);
        }


    }
}