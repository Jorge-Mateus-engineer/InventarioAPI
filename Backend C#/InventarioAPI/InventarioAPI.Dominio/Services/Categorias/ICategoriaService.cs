using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Categorias
{
    public interface ICategoriaService
    {
        List<CategoriaContract> GetAll();
        CategoriaContract GetByName(string name);
        CategoriaContract Insert(CategoriaContract entity);
        CategoriaContract Update(CategoriaContract entity);
        void Delete(CategoriaContract entity);
    }
}
