using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Cliente.Models;
using BLL.Services;
using Cliente.Models.Screens;
using Models.Entities;

namespace Cliente.Controllers;

public class HomeController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public HomeController(IUsuarioService userService)
    {
        _usuarioService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        IQueryable<Usuario> _resultDB = await _usuarioService.GetAll();

        List<UsuarioScreen> _lista = _resultDB.Select(el => new UsuarioScreen()
        {
            Id = el.Id,
            FullName = el.FullName,
            Password = el.Password,
            Email = el.Email
        }).ToList();

        return StatusCode(StatusCodes.Status200OK, _lista);
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] UsuarioScreen data)
    {

        Usuario _dataReq = new ()
        {
            FullName = data.FullName == null ? "" : data.FullName,
            Password = data.Password == null ? "" : data.Password,
            Email = data.Email == null ? "" : data.Email
        };

        bool _responseService = await _usuarioService.Insert(_dataReq);

        return StatusCode(StatusCodes.Status200OK, new { state = _responseService });

    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UsuarioScreen data)
    {

        Usuario _dataReq = new ()
        {
            Id = data.Id,
            FullName = data.FullName == null ? "": data.FullName,
            Password = data.Password == null? "": data.Password,
            Email = data.Email == null ? "" : data.Email,
            Estado = 1
        };

        bool _responseService = await _usuarioService.Update(_dataReq); // return un true

        return StatusCode(StatusCodes.Status200OK, new { state = _responseService });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        bool _responseService = await _usuarioService.Delete(id);
        return StatusCode(StatusCodes.Status200OK, new { state = _responseService });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

