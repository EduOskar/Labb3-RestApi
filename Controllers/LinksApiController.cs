using AutoMapper;
using Azure;
using Labb3_RestApi.Models;
using Labb3_RestApi.Models.LinkDto;
using Labb3_RestApi.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Labb3_RestApi.Controllers
{
    [Route("api/Labb3-RestApi/Links")]
    [ApiController]
    public class LinksApiController : Controller
    {
        private readonly IRepository<Links> _LinkDb;
        private readonly IMapper _mapper;
        public LinksApiController(IRepository<Links> links, IMapper mapper)
        {
            _LinkDb = links;
            _mapper = mapper;
        }
        //GetAllLinks
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Links>>> GetLinks()
        {
            IEnumerable<Links> linkList = await _LinkDb.GetAllAsync();
            return Ok(linkList);
        }
        //GetSpecifikPersonIdLink
        [HttpGet("id:int")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Links>>> GetSpecificLink(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }
            IEnumerable<Links> model = await _LinkDb.GetAllAsync(m => m.FKPersonId == id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }
        //CreateLink
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LinksDto>> CreateLink([FromBody] LinkCreateDto linkDto)
        {
            if (await _LinkDb.GetAsync(l=>l.URL.ToUpper() == linkDto.URL.ToUpper()) != null)
            {
                ModelState.AddModelError("Error", "Url already exist");
                return BadRequest(ModelState);
            }
            if (linkDto == null)
            {
                return BadRequest(linkDto);
            }
            Links links = _mapper.Map<Links>(linkDto);
            await _LinkDb.CreateAsync(links);
            return CreatedAtAction(nameof(GetSpecificLink), new {id = links.LinkId}, links);
        }
        //PatchLink
        [HttpPatch("Int:id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ChangeUrl(int id, JsonPatchDocument<LinkUpdateDto> patchDto)
        {
            if (patchDto == null || id==0)
            {
                return BadRequest();
            }
            var link = await _LinkDb.GetAsync(l => l.LinkId == id);
            LinkUpdateDto linkUpdate = _mapper.Map<LinkUpdateDto>(link);
            if (link == null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(linkUpdate, ModelState);
            Links model = _mapper.Map<Links>(linkUpdate);
            await _LinkDb.UpdateAsync(model);
            return NoContent();
        }

    }
}
