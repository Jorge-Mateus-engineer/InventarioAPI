using InventarioAPI.Infraestructura.Database.Entidades;

namespace InventarioAPI.Infraestructura.Repositorios.Categorias
{
    public interface ICategoriasRepository
    {
        List<CategoriaEntity> GetAll();
        CategoriaEntity GetByName(string name);
        CategoriaEntity Insert(CategoriaEntity entity);
        CategoriaEntity Update(CategoriaEntity entity);
        void Delete(CategoriaEntity entity);
    }
}
