using BStorm.Tools.CommandQuerySeparation.Commands;

namespace FQ24L007B_GestTache.Api.Models.Commands
{
    public class CreerTacheCommand : ICommandDefinition
    {
        public string Titre { get; }

        public CreerTacheCommand(string titre)
        {
            if (string.IsNullOrWhiteSpace(titre))
                throw new ArgumentException("Titre invalide");

            Titre = titre;
        }
    }
}
