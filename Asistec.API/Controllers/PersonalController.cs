using Asistec.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Asistec.API.Repositories;

namespace Asistec.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonalController : ControllerBase
    {
        private readonly IPersonalRepository _repository;

        public PersonalController(IPersonalRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet("{idPersonal}", Name = "GetDiscount")]
        [ProducesResponseType(typeof(Personal), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Personal>> GetPersonal(int idPersonal)
        {
            await _repository.GetPersonal(idPersonal);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(Personal), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Personal>> CreatePersonal([FromBody] Personal personal)
        {
            //await _repository.CreateDiscount(personal);
            //return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
            await _repository.CreatePersonal(personal);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(typeof(Personal), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Personal>> UpdatePersonal([FromBody] Personal personal)
        {
            //return Ok(await _repository.UpdateDiscount(personal));
            await _repository.UpdatePersonal(personal);
            return Ok();
        }

        [HttpDelete("{idPersonal}", Name = "DeleteDiscount")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeletePersonal(int idPersonal)
        {
            //return Ok(await _repository.DeleteDiscount(productName));
            await _repository.DeletePersonal(idPersonal);
            return Ok();
        }
    }
}
