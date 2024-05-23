using System.Data.Entity;
using APBD_EF.CONTEXT;
using APBD_EF.DTOS;
using APBD_EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_EF.CONTROLLERS;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly Context _context;

    public ClientController(Context context)
    {
        _context = context;
    }

    [HttpDelete("{id")]
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _context.Client.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        var trips = await _context.ClientTrips.AnyAsync((e => e.ClientId == id));
        if (trips)
        {
            return BadRequest();
        }

        _context.Client.Remove(client);
        await _context.SaveChangesAsync();
        return Ok();

    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> PrzypiszKlienta(int id, [FromBody] DTOS.CreateClientDTO dto)
    {
        var trip = await _context.Trip.FindAsync(id);
        if (trip == null)
        {
            return NotFound();
        }

        var client = await _context.Client.SingleOrDefaultAsync(e => e.Pesel == dto.Pesel);
        if (client == null)
        {
            _context.Client.Add(new Client { Pesel = dto.Pesel, Name = dto.Name });
            await _context.SaveChangesAsync();
        }

        var tripExist = await _context.ClientTrips.AnyAsync(e => e.TripId == id && e.ClientId == client.Id);
        if (tripExist)
        {
            return BadRequest();
        }

        var clTrip = new ClientTrip { TripId = id, ClientId = client.Id, RegisteredAt = DateTime.Now };
        _context.ClientTrips.Add(clTrip);
        await _context.SaveChangesAsync();
        return Ok();
    }
}

