using Microsoft.AspNetCore.Mvc;
using ProjKronos.Models;
using ProjKronos.Data;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace ProjKronos.Controllers
{
    public class Login : Controller
    {
        private readonly ApplicationDbContext _context;

        public Login(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string? nome, string? senha)
        {

            if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(senha))
            {
                var utilizador = _context.Utilizador.FirstOrDefault(m => 
                m.NomeUtilizador == nome &&
                m.Senha == senha
                );

                if (utilizador != null)
                {
                    HttpContext.Session.SetString("Nome: ", utilizador.NomeUtilizador!);
                    HttpContext.Session.SetInt32("ID: ", utilizador.Id);
                    
                    return View(Process);
                }
            }

            return View();
        }
    }
}
