using Microsoft.EntityFrameworkCore;
using Reviews.Data;
using Reviews.Models;
using Reviews.Repositorios.Interfaces;

namespace Reviews.Repositorios
{
    public class DepoimentoRepositorio : IDepoimentoRepositorio
    {
        private readonly DepoimentoContext _dbContext;

        public DepoimentoRepositorio(DepoimentoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Depoimento> BuscarDepoimentoPorId(int id)
        {
            try
            {
                var depoimento = await _dbContext.Depoimentos.FindAsync(id);

                if (depoimento == null) throw new Exception("Depoimento não encontrado");

                return depoimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Depoimento> BuscarDepoimentoPorNome(string nome)
        {
            try
            {
                var depoimento = await _dbContext.Depoimentos.FirstOrDefaultAsync(x => x.Nome == nome);

                if (depoimento == null) throw new Exception("Depoimento não encontrado");

                return depoimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Depoimento>> BuscarTodosDepoimentos()
        {
            try
            {
                var depoimentos = await _dbContext.Depoimentos.ToListAsync();

                if (depoimentos.Count == 0) throw new Exception("Nenhum depoimento encontrado");

                return depoimentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Depoimento>> TresDepoimentosAleatorios()
        {
            try
            {
                var depoimentos = await _dbContext.Depoimentos.OrderBy(x => Guid.NewGuid()).Take(3).ToListAsync();

                if (depoimentos.Count == 0) throw new Exception("Nenhum depoimento encontrado");

                return depoimentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Depoimento> CriarDepoimento(Depoimento depoimento)
        {
            try
            {
                await _dbContext.Depoimentos.AddAsync(depoimento);
                await _dbContext.SaveChangesAsync();

                return depoimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Depoimento> AtualizarDepoimento(Depoimento depoimentoAtualizado, int id)
        {
            try
            {
                var depoimento = await _dbContext.Depoimentos.FindAsync(id);

                if (depoimento == null) throw new Exception($"Depoimento com o id {id} não foi encontrado");

                depoimento.Nome = depoimentoAtualizado.Nome;
                depoimento.DepoimentoTexto = depoimentoAtualizado.DepoimentoTexto;
                depoimento.FotoPessoa = depoimentoAtualizado.FotoPessoa;

                await _dbContext.SaveChangesAsync();

                return depoimento;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeletarDepoimento(int id)
        {
            try
            {
                var Depoimento = await _dbContext.Depoimentos.FindAsync(id);

                if (Depoimento == null) throw new Exception($"Depoimento com o id {id} não foi encontrado");

                _dbContext.Depoimentos.Remove(Depoimento);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
