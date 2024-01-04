using Microsoft.AspNetCore.Mvc;
using BLL.Services;
using Cliente.Models.Screens;
using Models.Entities;
using Cliente.Models;
using System.Diagnostics;

namespace Cliente.Controllers;

public class LoginController : Controller
{
    private readonly IUsuarioService _usuarioService;

    public LoginController(IUsuarioService userService)
    {
        _usuarioService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Auth([FromBody] LoginScreen data)
    { 
        string _emailReq = data.Email == null ? "" : data.Email;
        string _passwordReq = data.Password == null ? "" : data.Password;

        Usuario _resultLogin = await _usuarioService.Login(_emailReq, _passwordReq);

        if (_resultLogin == null) return StatusCode(StatusCodes.Status200OK, new { state = false });
        else {
            _resultLogin.Password = "";
            return StatusCode(StatusCodes.Status200OK, new { state = true, userlogin = _resultLogin });
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}