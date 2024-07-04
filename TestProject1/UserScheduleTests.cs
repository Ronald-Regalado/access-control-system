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
using AccessControlSystem.Domain.Entities.UserSchedules;
using AccessControlSystem.Contracts.UserSchedules;
using AccessControlSystem.DataAccess.Repositories.UserSchedules;
namespace AccessControlSystem.DataAccess.Tests.UserSchedulesTests
{
    [TestClass]
    public class UserScheduleTests
    {

        private IUserScheduleRepository _userScheduleRepository;

        private IUnitOfWork _unitOfWork;


        public UserScheduleTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _userScheduleRepository = new UserScheduleRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Ronald", "Regalado Batista", "01022065449")]
        [DataRow("Carlos", "Fernández Ramos", "01102968165")]
        [TestMethod]
        public void Can_Add_UserSchedule(
            string firstName,
            string lastName,
            string ci
            )
          

        {
            // Arrange
            Guid id = Guid.NewGuid();
            UserSchedule userSchedule = new UserSchedule
            (
             new User(firstName, lastName, ci, Guid.NewGuid()),
            
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

        [DataRow("Carlos Daniel", "Fernandez Ramos", "01102968165", 4)]
        [TestMethod]
        public void Can_Update_UserSchedule(User user, int position)
        {
            // Arrange
            var userSchedules = _userScheduleRepository.GetAllUserSchedules().ToList();
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