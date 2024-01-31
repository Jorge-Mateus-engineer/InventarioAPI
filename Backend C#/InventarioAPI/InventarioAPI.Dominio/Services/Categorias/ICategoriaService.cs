using InventarioAPI.Comunes.Clases.Contratos;

namespace InventarioAPI.Dominio.Services.Categorias
{
    public interface ICategoriaService
    {
        List<CategoriaContract> GetAll();
        CategoriaContract GetByName(string name);
        CategoriaContract GetById(int id);
        CategoriaContract Insert(CategoriaContract contract);
        CategoriaContract Update(CategoriaContract contract);
        void Delete(CategoriaContract contract);
    }
}
