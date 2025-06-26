using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger) 
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View("Index");
    }

     public IActionResult Creditos()
    {
        return View("Creditos");
    }

     public IActionResult Tutorial()
    {
        return View("Tutorial");
    }

    public IActionResult EmpezarJuego()
    {
        SalaDeEscape nuevaPartida = new SalaDeEscape ();
        HttpContext.Session.SetString("JuegoActual", Objeto.ObjectToString(nuevaPartida));
        ViewBag.numeroSala = nuevaPartida.NumeroSala;
        ViewBag.pistas = nuevaPartida.Pistas;
        return View ("Sala1");
    }

     public IActionResult Registrarse()
    {
       SalaDeEscape nuevaPartida = Objeto.StringToObject<SalaDeEscape>(HttpContext.Session.GetString("JuegoActual"));
       return View ("Registrarse");
    }

    public IActionResult PasarAOtraSala(string respuesta)
    {
        SalaDeEscape nuevaPartida = Objeto.StringToObject<SalaDeEscape>(HttpContext.Session.GetString("JuegoActual"));
        if(respuesta!= null)
        {
            nuevaPartida.CompararRespuesta(respuesta);
        }
        HttpContext.Session.SetString("JuegoActual", Objeto.ObjectToString(nuevaPartida));
        ViewBag.numeroSala = nuevaPartida.NumeroSala;
        ViewBag.pistas = nuevaPartida.Pistas;
        return View("Sala" + nuevaPartida.NumeroSala);
    }

    public IActionResult FinJuego(int NumeroSala, SalaDeEscape nuevaPartida)
    {
        if (NumeroSala >= 5)
        {
            return View("FinJuego");
        }
        else
        {
            return View("FinJuego");
        }
    }

    public IActionResult DevolverPista()
    {
        SalaDeEscape nuevaPartida = Objeto.StringToObject<SalaDeEscape>(HttpContext.Session.GetString("JuegoActual"));
        ViewBag.Pista = nuevaPartida.DarPista();
        HttpContext.Session.SetString("JuegoActual", Objeto.ObjectToString(nuevaPartida));
        ViewBag.numeroSala = nuevaPartida.NumeroSala;
        return View ("Pistas");

    }
}


