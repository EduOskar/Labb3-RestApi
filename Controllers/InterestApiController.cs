using AutoMapper;
using Labb3_RestApi.Models;
using Labb3_RestApi.Models.InterestDTO;
using Labb3_RestApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_RestApi.Controllers
{
    [Route("api/Labb3-RestApi/Interest")]
    [ApiController]
    public class InterestApiController : Controller
    {
        private readonly IRepository<Interest> _interestDb;
        private readonly IMapper _mapper;
        public InterestApiController(IRepository<Interest> interest, IMapper mapper)
        {
            _interestDb = interest;
            _mapper = mapper;
        }
        //GetallInterest
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Interest>>> GetPerson()
        {
            IEnumerable<Interest> interestList = await _interestDb.GetAllAsync();

            return Ok(interestList);
        }

        //CreateAnInterest
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<InterestDto>> CreateInterest([FromBody] InterestCreateDto InterestDto)
        {
             if (await _interestDb.GetAsync(l=>l.Title.ToUpper() == InterestDto.Title.ToUpper()) != null)
            {
                ModelState.AddModelError("Error", "Title already exist");
                return BadRequest(ModelState);
            }
            if (InterestDto == null)
            {
                return BadRequest(InterestDto);
            }
            Interest interest = _mapper.Map<Interest>(InterestDto);
            await _interestDb.CreateAsync(interest);
            return Ok(interest);
        }
        //DeleteAInterest
        [HttpDelete("Id:int", Name = "DeleteAnInterest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteInterest(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var deleteMe = await _interestDb.GetAsync(dm => dm.InterestId == id);
            if (deleteMe == null)
            {
                return NotFound();
            }
            await _interestDb.RemoveAsync(deleteMe);
            return NoContent();
        }
    }
}
