using Microsoft.AspNetCore.Mvc;
using ProjKronos.Data;
using ProjKronos.Models;
using System.Linq;

namespace ProjKronos.Controllers
{
    public class ListItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string nome)
        {
            var processos = _context.Processos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                processos = processos.Where(p => p.Titulo!.Contains(nome));

            }
            var lista = processos.ToList();

            if (lista.Count == 0)
            {
                ViewBag.Mensagem = "Não foi encontrado nenhum processo.";
                ViewBag.Processos = processos.ToList();
            }

            ViewBag.Processos = lista;

            return View();
        }

    }
}
