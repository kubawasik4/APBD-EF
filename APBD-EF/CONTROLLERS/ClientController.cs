using System.Data.Entity;
using APBD_EF.CONTEXT;
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
}