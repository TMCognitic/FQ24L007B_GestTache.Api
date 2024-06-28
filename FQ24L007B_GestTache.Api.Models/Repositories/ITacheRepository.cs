using BStorm.Tools.CommandQuerySeparation.Commands;
using BStorm.Tools.CommandQuerySeparation.Queries;
using FQ24L007B_GestTache.Api.Models.Commands;
using FQ24L007B_GestTache.Api.Models.Entities;
using FQ24L007B_GestTache.Api.Models.Queries;

namespace FQ24L007B_GestTache.Api.Models.Repositories
{
    public interface ITacheRepository :
        ICommandHandler<CreerTacheCommand>,
        IQueryHandler<RetourneLesTacheQuery, IEnumerable<Tache>>
    {
    }
}
