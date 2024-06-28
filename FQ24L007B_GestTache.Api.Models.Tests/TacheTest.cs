
using FQ24L007B_GestTache.Api.Models.Entities;
using FQ24L007B_GestTache.Api.Models.Queries;
using Microsoft.Data.SqlClient;
using System.Windows.Input;

namespace FQ24L007B_GestTache.Api.Models.Tests
{
    public class TacheTest
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FQ24L007B_GestTache.Database;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";

        [Fact]
        public void CreerTacheNull()
        {
            //Arrange Act Assert

            //Arrange
            CreerTacheCommand command;
            //Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => command = new CreerTacheCommand(null));
            Assert.Equal("Titre invalide", ex.Message);
        }

        [Fact]
        public void CreerTacheVide()
        {
            //Arrange
            CreerTacheCommand command;
            //Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => command = new CreerTacheCommand(""));
            Assert.Equal("Titre invalide", ex.Message);
        }

        [Fact]
        public void CreerTacheEspaces()
        {
            //Arrange
            CreerTacheCommand command;
            //Act & Assert
            ArgumentException ex = Assert.Throws<ArgumentException>(() => command = new CreerTacheCommand("     "));
            Assert.Equal("Titre invalide", ex.Message);
        }

        [Fact]
        public void CreerTache()
        {
            //Arrange
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            ITacheRepository tacheRepository = new TacheService(sqlConnection);

            CreerTacheCommand command = new CreerTacheCommand("Ma xème tache");
            //Act
            ICommandResult result = tacheRepository.Execute(command);
            //Assert

            Assert.True(result.IsSuccess);
            
        }

        [Fact]
        public void TestRetourneLesTachesQuery()
        {
            //Arrange
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            ITacheRepository tacheRepository = new TacheService(sqlConnection);

            RetourneLesTacheQuery query = new RetourneLesTacheQuery();

            //act
            IQueryResult<IEnumerable<Tache>> result = tacheRepository.Execute(query);

            //assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Result);
        }
    }
}