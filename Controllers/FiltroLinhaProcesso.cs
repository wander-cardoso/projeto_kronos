using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjKronos.Data;
using ProjKronos.Models;

namespace ProjKronos.Controllers
{
    public class FiltroLinhaProcesso : Controller
    {
        private readonly ApplicationDbContext _context;

        public FiltroLinhaProcesso(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? id)
        {
         
            //Aqui lista todos os processos.
            ViewBag.Processos = _context.Processos.ToList();

            if(id == null) ViewBag.linhasFiltradas = _context.LinhaProcessos.ToList();

            else
            {
                var linhaFiltradaProcesso = _context.LinhaProcessos.Where(n => n.ProcessoId == id).ToList();

                ViewBag.linhasFiltradas = linhaFiltradaProcesso;
            }
            
                
            
                return View();
        }
    }
}
