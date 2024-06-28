using FQ24L007B_GestTache.Api.Models.Entities;
using System.Data;

namespace FQ24L007B_GestTache.Api.Models.Mappers
{
    internal static class DataRecordExtensions
    {
        internal static Tache ToTache(this IDataRecord dataRecord)
        {
            return new Tache((int)dataRecord["Id"], (string)dataRecord["Titre"], (DateTime)dataRecord["Creation"], (bool)dataRecord["Termine"]);
        }
    }
}
