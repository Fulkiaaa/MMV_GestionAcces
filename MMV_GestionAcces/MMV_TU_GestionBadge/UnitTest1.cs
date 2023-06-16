    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Windows;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MMV_GestionBadge;
    using Telerik.JustMock;
    using Telerik.JustMock.Helpers;

namespace MMV_TU_GestionBadge
{
    public class UnitTest1
    {
        [Fact]
        public void GetPersonnes_ShouldReturnList()
        {
            // Arrange
            var expected = new List<Personne>
        {
            new Personne { PER_ID = 1, PER_NOM = "MORIN", PER_PRENOM = "Clara" },
            new Personne { PER_ID = 2, PER_NOM = "Lebron", PER_PRENOM = "James" }
        };

            var mockDataService = Mock.Create<IDataService>();
            Mock.Arrange(() => mockDataService.GetPersonnes()).Returns(expected);

            // Act
            var actual = mockDataService.GetPersonnes();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [Fact]
        public void GetBatiments_ShouldReturnList()
        {
            // Arrange
            var expected = new List<Batiment>
        {
            new Batiment { BAT_ID = 1, BAT_NOM = "Lycée la chataigneraie", BAT_DESC = "Situé à Mesnil-Esnard" },
            new Batiment { BAT_ID = 2, BAT_NOM = "Accor Arena", BAT_DESC = "Situé à Paris" }
        };

            var mockDataService = Mock.Create<IDataService>();
            Mock.Arrange(() => mockDataService.GetBatiments()).Returns(expected);

            // Act
            var actual = mockDataService.GetBatiments();

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

