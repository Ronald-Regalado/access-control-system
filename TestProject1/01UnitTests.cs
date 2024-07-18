using AccessControlSystem.Contracts;
using AccessControlSystem.Contracts.Units;
using AccessControlSystem.DataAccess.Contexts;
using AccessControlSystem.DataAccess.Repositories.Units;
using AccessControlSystem.DataAccess.Tests.Utilities;
using AccessControlSystem.Domain.Entities.Units;
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
    public class UnitTests
    {
        private IUnitRepository _unitRepository;
        private IUnitOfWork _unitOfWork;

        public UnitTests()
        {
            ApplicationContext context =new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitRepository = new UnitRepository(context);
            _unitOfWork = new UnitOfWork(context);
        }

        
        [DataRow("Schnaider Electric", "SE20")]
        [DataRow("Siemen", "S01")]
        [DataRow("ABB", "AB01")]
        [DataRow("Honeywell", "Hw02")]
        [DataRow("Endress Hauser", "EHs01")]
        [TestMethod]
        public void Can_Add_Unit(string maker,string code)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Unit unit = new Unit(              
                maker,
                code,
                id
                );

            // Execute
            _unitRepository.AddUnit(unit);
            _unitOfWork.SaveChanges();

            // Assert
            Unit? loadedUnit = _unitRepository.GetUnitById(id);
            Assert.IsNotNull(loadedUnit);
        }

        

        [DataRow(0)]
        [TestMethod]
        public void Can_Get_Unit_By_Id(int position)
        {
            // Arrange
            var units = _unitRepository.GetAllUnits().ToList();
            Assert.IsNotNull(units);
            Assert.IsTrue(position < units.Count);
            Unit unitToGet = units[position];

            // Execute
            Unit? loadedUnit = _unitRepository.GetUnitById(unitToGet.Id);

            // Assert
            Assert.IsNotNull(loadedUnit);
        }

     

         

        [TestMethod]
        public void Cannot_Get_Unit_By_Invalid_Id()
        {
            // Arrange

            // Execute
            Unit? loadedUnit = _unitRepository.GetUnitById(Guid.Empty);

            // Assert
            Assert.IsNull(loadedUnit);
        }

        [DataRow("Schnaider Electric",true , 0)]
        [TestMethod]
        public void Can_Update_Unit( string maker, bool isInUse, int position)
        {
            // Arrange
            var units = _unitRepository.GetAllUnits().ToList();
            Assert.IsNotNull(units);
           // Assert.IsTrue(position < units.Count);
            Unit unitToUpdate = units[position];

            // Execute
            unitToUpdate.Maker = maker;
            unitToUpdate.IsInUse = isInUse;
            _unitRepository.UpdateUnit(unitToUpdate);
            _unitOfWork.SaveChanges();

            // Assert
            Unit? loadedUnit = _unitRepository.GetUnitById(unitToUpdate.Id);
            Assert.IsNotNull(loadedUnit);
            Assert.AreEqual(loadedUnit.Maker, maker);
            Assert.AreEqual(loadedUnit.IsInUse, isInUse);
        }

        [DataRow(0)]
        [TestMethod]
        public void Can_Delete_Unit(int position)
        {
            // Arrange
            var units = _unitRepository.GetAllUnits().ToList();
            Assert.IsNotNull(units);
            Assert.IsTrue(position < units.Count);
            Unit unitToDelete = units[position];

            // Execute
            _unitRepository.DeleteUnit(unitToDelete);
            _unitOfWork.SaveChanges();

            // Assert
            Unit? loadedUnit = _unitRepository.GetUnitById(unitToDelete.Id);
            Assert.IsNull(loadedUnit);
        }


    }
}