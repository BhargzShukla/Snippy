using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Snippy.Data;
using Snippy.Dtos;
using Snippy.Models;

namespace Snippy.Controllers
{
    // "api/snippets"
    // [Route("api/[controller]")] <- Wildcard; will calculate value based on current controller name
    [Route("api/snippets")]
    [ApiController]
    public class SnippetsController : ControllerBase
    {
        private readonly ISnippyRepo _repository;
        private readonly IMapper _mapper;

        public SnippetsController(ISnippyRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/snippets
        [HttpGet]
        public ActionResult<IEnumerable<SnippetReadDto>> GetAllSnippets()
        {
            var snippetItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<SnippetReadDto>>(snippetItems));
        }

        // GET api/snippets/5
        [HttpGet("{id}", Name = "GetSnippetById")]
        public ActionResult<SnippetReadDto> GetSnippetById(int id)
        {
            var snippetItem = _repository.GetSnippetById(id);
            if (snippetItem != null)
            {
                return Ok(_mapper.Map<SnippetReadDto>(snippetItem));
            }
            return NotFound();
        }

        // POST api/snippets
        [HttpPost]
        public ActionResult<SnippetReadDto> CreateSnippet(SnippetCreateOrUpdateDto snippetCreateOrUpdateDto)
        {
            var snippetModel = _mapper.Map<Snippet>(snippetCreateOrUpdateDto);
            _repository.CreateSnippet(snippetModel);
            _repository.SaveChanges();

            var snippetReadDto = _mapper.Map<SnippetReadDto>(snippetModel);

            return CreatedAtRoute(nameof(GetSnippetById), new { Id = snippetReadDto.Id }, snippetReadDto);
        }

        // PUT api/snippets/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSnippet(int id, SnippetCreateOrUpdateDto snippetUpdateDto)
        {
            var snippetModelFromRepo = _repository.GetSnippetById(id);
            if (snippetModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(snippetUpdateDto, snippetModelFromRepo);
            _repository.UpdateSnippet(snippetModelFromRepo);
            _repository.SaveChanges();
            return NoContent();
        }

        // PATCH api/snippets/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialSnippetUpdate(int id, JsonPatchDocument<SnippetCreateOrUpdateDto> patchDocument)
        {
            var snippetModelFromRepo = _repository.GetSnippetById(id);
            if (snippetModelFromRepo == null)
            {
                return NotFound();
            }

            var snippetToPatch = _mapper.Map<SnippetCreateOrUpdateDto>(snippetModelFromRepo);
            patchDocument.ApplyTo(snippetToPatch, ModelState);

            if (!TryValidateModel(snippetToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(snippetToPatch, snippetModelFromRepo);
            _repository.UpdateSnippet(snippetModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/snippets/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteSnippet(int id)
        {
            var snippetItem = _repository.GetSnippetById(id);
            if (snippetItem == null)
            {
                return NotFound();
            }
            _repository.DeleteSnippet(snippetItem);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}