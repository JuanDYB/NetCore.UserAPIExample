using InnoCV.DatabaseModel.Database.Model;
using InnoCV.DatabaseModel.ModelMapping;
using InnoCV.Model.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InnoCV.Test
{
    /// <summary>
    /// Example Unit testing class
    /// </summary>
    [TestClass]
    public class UserMappingTest
    {
        [TestMethod]
        public void ToEntityTest()
        {
            T_USER UserEntity = new T_USER
            {
                OID = 0,
                NAME = "Juan",
                BIRTH_DATE = DateTime.Now,
            };
            User UserView = new UserMapper().MapToView(UserEntity);

            Assert.AreEqual(UserEntity.OID, UserView.Id);
            Assert.AreEqual(UserEntity.NAME, UserView.Name);
            Assert.AreEqual(UserEntity.BIRTH_DATE, UserView.BirthDate);
        }

        [TestMethod]
        public void ToViewTest()
        {
            User UserView = new User
            {
                Id = 0,
                Name = "Juan",
                BirthDate = new DateTime(1989, 05, 03),
            };
            T_USER UserEntity = new UserMapper().MapToEntity(UserView);

            Assert.AreEqual(UserView.Id, UserEntity.OID);
            Assert.AreEqual(UserView.Name, UserEntity.NAME);
            Assert.AreEqual(UserView.BirthDate, UserEntity.BIRTH_DATE);
        }
    }
}
