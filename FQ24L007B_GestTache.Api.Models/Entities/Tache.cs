using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FQ24L007B_GestTache.Api.Models.Entities
{
    public class Tache
    {
        public int Id { get; }
        public string Titre { get; set; }
        public DateTime Creation { get; }
        public bool Termine { get; set; }

        internal Tache(int id, string titre, DateTime creation, bool termine)
        {
            Id = id;
            Titre = titre;
            Creation = creation;
            Termine = termine;
        }
    }
}
