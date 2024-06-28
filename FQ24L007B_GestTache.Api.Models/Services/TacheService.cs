using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;
using BStorm.Tools.Database;
using FQ24L007B_GestTache.Api.Models.Commands;
using FQ24L007B_GestTache.Api.Models.Entities;
using FQ24L007B_GestTache.Api.Models.Mappers;
using FQ24L007B_GestTache.Api.Models.Queries;
using FQ24L007B_GestTache.Api.Models.Repositories;
using System.Data.Common;

namespace FQ24L007B_GestTache.Api.Models.Services
{
    public class TacheService : ITacheRepository
    {
        private readonly DbConnection _dbConnection;

        public TacheService(DbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public ICommandResult Execute(CreerTacheCommand command)
        {
            try
            {
                _dbConnection.Open();
                int rows = _dbConnection.ExecuteNonQuery("CSP_CreerTache", true, command);

                if (rows == 0)
                {
                    return ICommandResult.Failure("Pas de données insérée", null);
                }

                return ICommandResult.Success();
            }
            catch (Exception ex)
            {
                return ICommandResult.Failure(ex.Message, ex);
            }
            finally
            { 
                _dbConnection.Close(); 
            }
        }

        public IQueryResult<IEnumerable<Tache>> Execute(RetourneLesTacheQuery query)
        {
            try
            {
                _dbConnection.Open();
                IEnumerable<Tache> taches = _dbConnection.ExecuteReader("CSP_RetourneLesTaches", r => r.ToTache(), true, query);
                return IQueryResult<IEnumerable<Tache>>.Success(taches.ToArray());
            }
            catch (Exception ex)
            {
                return IQueryResult<IEnumerable<Tache>>.Failure(ex.Message, ex);
            }
            finally
            {
                _dbConnection.Close();
            }
        }
    }
}
