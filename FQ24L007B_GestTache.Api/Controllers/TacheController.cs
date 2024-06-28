using FQ24L007B_GestTache.Api.Forms;
using FQ24L007B_GestTache.Api.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FQ24L007B_GestTache.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TacheController : Controller
    {
        private readonly ITacheRepository _tacheRepository;

        public TacheController(ITacheRepository tacheRepository)
        {
            _tacheRepository = tacheRepository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreerTacheForm form)
        {
            ICommandResult commandResult = _tacheRepository.Execute(new CreerTacheCommand(form.Titre));

            if(commandResult.IsFailure)
            {
                return BadRequest(new { commandResult.ErrorMessage });
            }

            return NoContent();
        }

        [HttpGet]
        public IActionResult Get()
        {
            IQueryResult<IEnumerable<Tache>> queryResult = _tacheRepository.Execute(new RetourneLesTacheQuery());

            if(queryResult.IsFailure)
                return BadRequest(new { queryResult.ErrorMessage });

            return Ok(queryResult.Result);
        }
    }
}
