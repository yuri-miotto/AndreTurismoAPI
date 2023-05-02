using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreTurismoAPI.AddressService.Data;
using AndreTurismoAPI.Models;
using AndreTurismoAPI.AddressService.Services;
using System.Net;

namespace AndreTurismoAPI.AddressService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoesController : ControllerBase
    {
        private readonly AndreTurismoAPIAddressServiceContext _context;
        private readonly PostOfficesService _postOfficesService;

        public EnderecoesController(AndreTurismoAPIAddressServiceContext context, PostOfficesService postOfficesService)
        {
            _context = context;
            _postOfficesService = postOfficesService;
        }

        // GET: api/Enderecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
          if (_context.Endereco == null)
          {
              return NotFound();
          }
            //return await _context.Endereco.ToListAsync();
            return await _context.Endereco.Include(a => a.Cidade).ToListAsync();
        }

        // GET: api/Enderecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
          if (_context.Endereco == null)
          {
              return NotFound();
          }
            //var endereco = await _context.Endereco.FindAsync(id);
            var endereco = await _context.Endereco.Include(a => a.Cidade).Where(a => a.IdEndereco == id).FirstOrDefaultAsync();

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Enderecoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Endereco>> PutAddress(int id, Endereco endereco)
        {
            if (id != endereco.IdEndereco)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return endereco;
        }

        // POST: api/Enderecoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
        {
          if (_context.Endereco == null)
          {
              return Problem("Entity set 'AndreTurismoAPIAddressServiceContext.Endereco'  is null.");
          }
            /*
            _context.Endereco.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEndereco", new { id = endereco.IdEndereco }, endereco);
            */
            EnderecoDTO enderecoDto = _postOfficesService.GetAddress(endereco.CEP).Result;
            var enderecoCompleto = new Endereco(enderecoDto);
            _context.Endereco.Add(enderecoCompleto);

            await _context.SaveChangesAsync();

            return enderecoCompleto;
        }

        // DELETE: api/Enderecoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> DeleteAddress(int id)
        {
            if (_context.Endereco == null)
            {
                return NotFound();
            }
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return (_context.Endereco?.Any(e => e.IdEndereco == id)).GetValueOrDefault();
        }
    }
}
