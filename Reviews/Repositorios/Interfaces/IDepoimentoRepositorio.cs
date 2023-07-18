using Reviews.Models;

namespace Reviews.Repositorios.Interfaces
{
    public interface IDepoimentoRepositorio
    {
        Task<List<Depoimento>> BuscarTodosDepoimentos();
        Task<Depoimento> BuscarDepoimentoPorId(int id);
        Task<Depoimento> BuscarDepoimentoPorNome(string nome);
        Task<List<Depoimento>> TresDepoimentosAleatorios();
        Task<Depoimento> CriarDepoimento(Depoimento depoimento);
        Task<Depoimento> AtualizarDepoimento(Depoimento depoimentoAtualizado, int id);
        Task<bool> DeletarDepoimento(int id);
    }
}
