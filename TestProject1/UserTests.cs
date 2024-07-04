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
namespace AccessControlSystem.DataAccess.Tests.UnitTests
{
    [TestClass]
    public class UserTests
    {

        private IUserRepository _userRepository;

        private IUnitOfWork _unitOfWork;


        public UserTests()
        {
            ApplicationContext context =
                new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _userRepository = new UserRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        [DataRow("Ronald", "Regalado Batista", "01022065449")]
        [DataRow("Carlos", "Fernández Ramos","01102968165")]
        [TestMethod]
        public void Can_Add_User(
            string firstName,
            string lastName,
            string ci,
            Location location,
            Contact contact,
            string schoolLevel
           )
        {
            // Arrange
            Guid id = Guid.NewGuid();
            User user = new User(

                
           
                
                );

            // Execute
            _userRepository.AddUser(user);
            _unitOfWork.SaveChanges();

            // Assert
            User? loadedUser = _userRepository.GetUserById<User>(id);
            Assert.IsNotNull(loadedUser);
        }



        [DataRow(0)]
        [TestMethod]
        public void Can_Get_User_By_Id(int position)
        {
            // Arrange
            var users = _userRepository.GetAllUsers().ToList();
            Assert.IsNotNull(users);
            Assert.IsTrue(position < users.Count);
            User userToGet = users[position];

            // Execute
            User? loadedUser = _userRepository.GetUserById(userToGet.Id);

            // Assert
            Assert.IsNotNull(loadedUser);
        }





        [TestMethod]
        public void Cannot_Get_User_By_Invalid_Id()
        {
            // Arrange

            // Execute
            User? loadedUser = _userRepository.GetUserById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedUser);
        }

        [DataRow("Schnaider Electric", "SE2001", true, 4)]
        [TestMethod]
        public void Can_Update_User(string maker, string code, bool isInUse, int position)
        {
            // Arrange
            var users = _userRepository.GetAllUsers().ToList();
            Assert.IsNotNull(users);
            Assert.IsTrue(position < users.Count);
            User userToUpdate = users[position];

            // Execute
            userToUpdate.Maker = maker;
            userToUpdate.Code = code;
            userToUpdate.IsInUse = isInUse;
            _userRepository.UpdateUser(userToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            User? loadedUser = _userRepository.GetAllUsers<User>(userToUpdate.Id);
            Assert.IsNotNull(loadedUser);
            Assert.AreEqual(loadedUser.Maker, maker);
            Assert.AreEqual(loadedUser.Code, code);
            Assert.AreEqual(loadedUser.IsInUse, isInUse);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_User(int position)
        {
            // Arrange
            var users = _userRepository.GetAllUsers<User>().ToList();
            Assert.IsNotNull(users);
            Assert.IsTrue(position < users.Count);
            User userToDelete = users[position];

            // Execute
            _userRepository.DeleteUser(userToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            User? loadedUser = _userRepository.GetAllUsers<User>(userToDelete.Id);
            Assert.IsNull(loadedUser);
        }


    }
}