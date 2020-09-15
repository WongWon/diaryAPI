using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using diaryAPI.Model;

namespace diaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiariesController : ControllerBase
    {
        private readonly diaryContext _context;

        public DiariesController(diaryContext context)
        {
            _context = context;
        }

        // GET: api/Diaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diary>>> GetDiary()
        {
            return await _context.Diary.ToListAsync();
        }

        // GET: api/Diaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diary>> GetDiary(int id)
        {
            var diary = await _context.Diary.FindAsync(id);

            if (diary == null)
            {
                return NotFound();
            }

            return diary;
        }

        // PUT: api/Diaries/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiary(int id, Diary diary)
        {
            if (id != diary.Id)
            {
                return BadRequest();
            }

            _context.Entry(diary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiaryExists(id))
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

        // POST: api/Diaries
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Diary>> PostDiary(Diary diary)
        {
            _context.Diary.Add(diary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiary", new { id = diary.Id }, diary);
        }

        // DELETE: api/Diaries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Diary>> DeleteDiary(int id)
        {
            var diary = await _context.Diary.FindAsync(id);
            if (diary == null)
            {
                return NotFound();
            }

            _context.Diary.Remove(diary);
            await _context.SaveChangesAsync();

            return diary;
        }

        private bool DiaryExists(int id)
        {
            return _context.Diary.Any(e => e.Id == id);
        }
    }
}
