using AutoMapper;
using Labb3_RestApi.Models;
using Labb3_RestApi.Models.PersonDTO;
using Labb3_RestApi.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_RestApi.Controllers
{
    [Route("api/Labb3-RestApi")]
    [ApiController]
    public class PersonApiController : Controller
    {
        private readonly IRepository<Person> _PersonDb;
        private readonly IMapper _mapper;
        public PersonApiController(IRepository<Person> person, IMapper mapper)
        {
            _PersonDb = person;
            _mapper = mapper;
        }
        //GetAllPersons
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
            IEnumerable<Person> personList = await _PersonDb.GetAllAsync();

            return Ok(personList);
        }
        //GetSinglePerson
        [HttpGet("id:int", Name = "GetSinglePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetSinglePerson(int personId)
        {
            if (personId == 0)
            {
                return BadRequest();
            }
            var findPerson = await _PersonDb.GetAsync(p => p.PersonId == personId);
            if (findPerson == null)
            {
                return NotFound();
            }
            return Ok(findPerson);
        }
        //CreateAPerson
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CreatePerson([FromBody]Person personDto)
        {
            if (personDto == null)
            {
                return BadRequest(personDto);
            }
            Person person = _mapper.Map<Person>(personDto);
            await _PersonDb.CreateAsync(person);
            return CreatedAtAction("CreatePerson", new {id =person.PersonId}, person);
        }
        //PatchAPerson
        [HttpPut("Id:int", Name ="UpdatePerson"),]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Person>> UpdatePerson(int id, [FromBody] PersonUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.PersonId)
            {
                return BadRequest();
            }
            Person person = _mapper.Map<Person>(updateDto);
            await _PersonDb.UpdateAsync(person);
            return NoContent();
        }
        //DeleteAPerson
        [HttpDelete("Id:int", Name ="DeleteAPerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeletePerson(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var deleteMe = await _PersonDb.GetAsync(dm=>dm.PersonId == id);
            if (deleteMe == null)
            {
                return NotFound();
            }
            await _PersonDb.RemoveAsync(deleteMe);
            return NoContent();
        }

    }
}
