using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Units;
using AccessControlSystem.DataAccess.Repositories.Users;
using AccessControlSystem.DataAccess.Repositories.UserSessions;
using AccessControlSystem.DataAccess.Tests.Utilities;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Entities.UserSessions;
namespace AccessControlSystem.DataAccess.Tests.UserSessionTests
{
    [TestClass]
    public class UserSessionTests
    {

        private IUserSessionRepository _userSessionRepository;
        private IUserRepository _userRepository;
        private IUnitRepository _unitRepository;
        private IUnitOfWork _unitOfWork;


        public UserSessionTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _userSessionRepository = new UserSessionRepository(context);
            _userRepository = new UserRepository(context);
            _unitRepository = new UnitRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Add_UserSession(int position)

        {
            // Arrange
            Guid id = Guid.NewGuid();
            var units = _unitRepository.GetAllUnits().ToList();
            var users = _userRepository.GetAllUsers().ToList();
            UserSession userSession = new UserSession
            (
            users[position],
             units[position],
             id
            );

            // Execute
            _userSessionRepository.AddUserSession(userSession);
            _unitOfWork.SaveChanges();

            // Assert
            UserSession? loadedUserSession = _userSessionRepository.GetUserSessionById(id);
            Assert.IsNotNull(loadedUserSession);
        }



        [DataRow(0)]
        [TestMethod]
        public void Can_Get_UserSession_By_Id(int position)
        {
            // Arrange
            var userSessions = _userSessionRepository.GetAllUserSessions().ToList();
            Assert.IsNotNull(userSessions);
            Assert.IsTrue(position < userSessions.Count);
            UserSession userSessionToGet = userSessions[position];

            // Execute
            UserSession? loadedUserSession = _userSessionRepository.GetUserSessionById(userSessionToGet.Id);

            // Assert
            Assert.IsNotNull(loadedUserSession);
        }





        [TestMethod]
        public void Cannot_Get_UserSession_By_Invalid_Id()
        {
            // Arrange

            // Execute
            UserSession? loadedUserSession = _userSessionRepository.GetUserSessionById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedUserSession);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Update_UserSession( int position)
        {
            // Arrange
            var userSessions = _userSessionRepository.GetAllUserSessions().ToList();
            Assert.IsNotNull(userSessions);
            Assert.IsTrue(position < userSessions.Count);
            UserSession userSessionToUpdate = userSessions[position];

            // Execute
            DateTime endTime = DateTime.Now;
            userSessionToUpdate.EndTime = endTime;
            _userSessionRepository.UpdateUserSession(userSessionToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            UserSession? loadedUserSession = _userSessionRepository.GetUserSessionById(userSessionToUpdate.Id);
            Assert.AreEqual(loadedUserSession.EndTime, endTime);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_UserSession(int position)
        {
            // Arrange
            var userSessions = _userSessionRepository.GetAllUserSessions().ToList();
            Assert.IsNotNull(userSessions);
            Assert.IsTrue(position < userSessions.Count);
            UserSession userSessionToDelete = userSessions[position];

            // Execute
            _userSessionRepository.DeleteUserSession(userSessionToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            UserSession? loadedUserSession = _userSessionRepository.GetUserSessionById(userSessionToDelete.Id);
            Assert.IsNull(loadedUserSession);
        }


    }
}