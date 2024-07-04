using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Users;
using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Users;
using AccessControlSystem.DataAccess.Tests.Utilities;
using AccessControlSystem.Domain.Entities.Users;
using AccessControlSystem.Domain.Common;
using AccessControlSystem.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessControlSystem.DataAccess;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;
using AccessControlSystem.Domain.Entities.UserSessions;
using AccessControlSystem.Domain.Entities.Units;
using AccessControlSystem.Contracts.UserSessions;
using AccessControlSystem.DataAccess.Repositories.UserSessions;
namespace AccessControlSystem.DataAccess.Tests.UserSessionTests
{
    [TestClass]
    public class UserSessionTests
    {

        private IUserSessionRepository _userSessionRepository;

        private IUnitOfWork _unitOfWork;


        public UserSessionTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _userSessionRepository = new UserSessionRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Ronald", "Regalado Batista", "01022065449", "Schnaider Electric", "SE2001")]
        [DataRow("Carlos", "Fernández Ramos", "01102968165", "Siemens", "S0102")]
        [TestMethod]
        public void Can_Add_UserSession(
            string firstName,
            string lastName,
            string ci,
             string maker,
            string code)
           
        {
            // Arrange
            Guid id = Guid.NewGuid();
            UserSession userSession = new UserSession
            (
             new User(firstName,lastName,ci,Guid.NewGuid()) ,  
             new Unit(maker,code, Guid.NewGuid())  ,
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

        [DataRow("Carlos Daniel", "Fernandez Ramos", "01102968165", 4)]
        [TestMethod]
        public void Can_Update_UserSession(User user, Unit unit, DateTime startTime,DateTime endTime ,int position)
        {
            // Arrange
            var userSessions = _userSessionRepository.GetAllUserSessions().ToList();
            Assert.IsNotNull(userSessions);
            Assert.IsTrue(position < userSessions.Count);
            UserSession userSessionToUpdate = userSessions[position];

            // Execute
            userSessionToUpdate.User = user;
            userSessionToUpdate.BusyUnit = unit;
            userSessionToUpdate.StartTime = startTime;
            userSessionToUpdate.EndTime = endTime;
            _userSessionRepository.UpdateUserSession(userSessionToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            UserSession? loadedUserSession = _userSessionRepository.GetUserSessionById(userSessionToUpdate.Id);
            Assert.IsNotNull(loadedUserSession);
            Assert.AreEqual(loadedUserSession.User, user);
            Assert.AreEqual(loadedUserSession.BusyUnit, unit);
            Assert.AreEqual(loadedUserSession.StartTime, startTime);
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