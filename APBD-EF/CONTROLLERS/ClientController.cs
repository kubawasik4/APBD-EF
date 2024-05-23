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
}