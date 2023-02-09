using Microsoft.AspNetCore.Mvc;
using _20220921.Models;
using _20220921.Dtos;
using _20220921.Repository;


namespace _20220921.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : ControllerBase
    {
        private readonly CardRepository _cardRepository;
        public CardController()
        {
            this._cardRepository = new CardRepository();
        }
        [HttpGet]
        public IEnumerable<CardDto> GetList()
        {
            return this._cardRepository.GetList();
        }

        [HttpGet]
        [Route("{id}")]
        public CardDto? Get([FromRoute] int id)
        {
            var result = this._cardRepository.Get(id);
            if (result is null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return result;
        }
        [HttpPost]
        public IActionResult Insert([FromBody] CardDto parameter)
        {
            var result = this._cardRepository.Create(parameter);
            if (result > 0)
            {
                return Ok();
            }
            return StatusCode(500);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(
               [FromRoute] int id,
               [FromBody] CardDto parameter)
        {
            var targetCard = this._cardRepository.Get(id);
            if (targetCard is null)
            {
                return NotFound();
            }
            var isUpdateSuccess = this._cardRepository.Update(id, parameter);
            if (isUpdateSuccess)
            {
                return Ok();
            }
            return StatusCode(500);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            this._cardRepository.Delete(id);
            return Ok();
        }
        [HttpPatch]
        [Route("{id}")]
        public IActionResult PartialUpdate(
                [FromRoute] int id,
                [FromBody] CardPartialDto parameter)

        {
            var targetCard = this._cardRepository.Get(id);
            if (targetCard is null)
            {
                return NotFound();
            }
            var isUpdateSuccess = this._cardRepository.PartialUpdate(id, parameter);
            if (isUpdateSuccess)
            {
                return Ok();
            }
            return StatusCode(500);
        }



    }

}
