using Microsoft.AspNetCore.Mvc;
using ProjKronos.Data;

namespace ProjKronos.Controllers
{
    public class FiltrarProcessos : Controller
    {

        private readonly ApplicationDbContext _context;

        public FiltrarProcessos(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? idCliente, int? idCategoria, int? idPrioridade)
        {
            var query = _context.Processos.AsQueryable();
            ViewBag.Clientes = _context.Clientes!.ToList();
            ViewBag.Categorias = _context.Categorias!.ToList();
            ViewBag.Prioridades = _context.Prioridades!.ToList();

            if (idCliente == null || idCategoria == null || idPrioridade == null)
            {
                var lista = query
                    .OrderByDescending(n => n.DataCriacao)
                    .ToList();
                ViewBag.Processos = lista;
            }

                       
            var ProcClientes = query.Where(n => 
            n.ClienteId == idCliente || 
            n.CategoriaId == idCategoria ||
            n.PrioridadeId == idPrioridade
            ).ToList();
            
            ViewBag.Processos = ProcClientes;

            return View();
        }

    }
}

