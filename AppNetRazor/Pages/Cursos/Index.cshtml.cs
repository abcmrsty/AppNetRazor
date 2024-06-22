using AppNetRazor.Datos;
using AppNetRazor.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AppNetRazor.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _contexto;

        public IndexModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public IEnumerable<Curso> Cursos { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        public async Task OnGet()
        {
            Cursos = await _contexto.Curso.ToListAsync();
        }

        public async Task<IActionResult> OnPostBorrar(int id)
        {
            var Curso = await _contexto.Curso.FindAsync(id);
            if (Curso == null)
            {
                return NotFound();
            }
            
            _contexto.Curso.Remove(Curso);
            await _contexto.SaveChangesAsync();
            Mensaje = "Curso borrado correctamente";
            return RedirectToPage("Index");
        }
    }
}
