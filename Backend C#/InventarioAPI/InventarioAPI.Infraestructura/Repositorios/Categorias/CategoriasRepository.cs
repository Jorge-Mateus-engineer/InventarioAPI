using InventarioAPI.Infraestructura.Database.Contextos;
using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Categorias
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly InventarioContext _context;

        public CategoriasRepository(InventarioContext context)
        {
            _context = context;
        }

        public void Delete(CategoriaEntity entity)
        {
            _context.Categorias.Remove(entity);
            _context.SaveChanges();
        }

        public List<CategoriaEntity> GetAll()
        {
            return _context.Categorias.ToList();
        }

        public CategoriaEntity GetByName(string name)
        {
            return _context.Categorias.Where(c => c.nombre == name).Single();
        }

        public CategoriaEntity GetById(int id)
        {
            return _context.Categorias.Where(c => c.id_categoria == id).Single();
        }

        public CategoriaEntity Insert(CategoriaEntity entity)
        {
            _context.Categorias.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public CategoriaEntity Update(CategoriaEntity entity)
        {
            _context.Categorias.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
