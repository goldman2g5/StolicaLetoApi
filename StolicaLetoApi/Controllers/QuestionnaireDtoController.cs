using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StolicaLetoApi.Models;

namespace StolicaLetoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireDtoController : ControllerBase
    {
        private readonly GovnoDbContext _context;

        public QuestionnaireDtoController(GovnoDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionnaireDto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionnaireDto>>> GetQuestionnaireDtos()
        {
          if (_context.QuestionnaireDtos == null)
          {
              return NotFound();
          }
            return await _context.QuestionnaireDtos.ToListAsync();
        }

        // GET: api/QuestionnaireDto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionnaireDto>> GetQuestionnaireDto(int id)
        {
          if (_context.QuestionnaireDtos == null)
          {
              return NotFound();
          }
            var questionnaireDto = await _context.QuestionnaireDtos.FindAsync(id);

            if (questionnaireDto == null)
            {
                return NotFound();
            }

            return questionnaireDto;
        }

        // PUT: api/QuestionnaireDto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionnaireDto(int id, QuestionnaireDto questionnaireDto)
        {
            if (id != questionnaireDto.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionnaireDto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionnaireDtoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuestionnaireDto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QuestionnaireDto>> PostQuestionnaireDto(QuestionnaireDto questionnaireDto)
        {
          if (_context.QuestionnaireDtos == null)
          {
              return Problem("Entity set 'GovnoDbContext.QuestionnaireDtos'  is null.");
          }
            _context.QuestionnaireDtos.Add(questionnaireDto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionnaireDto", new { id = questionnaireDto.Id }, questionnaireDto);
        }

        // DELETE: api/QuestionnaireDto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestionnaireDto(int id)
        {
            if (_context.QuestionnaireDtos == null)
            {
                return NotFound();
            }
            var questionnaireDto = await _context.QuestionnaireDtos.FindAsync(id);
            if (questionnaireDto == null)
            {
                return NotFound();
            }

            _context.QuestionnaireDtos.Remove(questionnaireDto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QuestionnaireDtoExists(int id)
        {
            return (_context.QuestionnaireDtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
