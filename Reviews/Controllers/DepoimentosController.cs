using Microsoft.AspNetCore.Mvc;
using Reviews.Models;
using Reviews.Repositorios.Interfaces;

namespace Reviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepoimentosController : ControllerBase
    {
        private readonly IDepoimentoRepositorio _depoimentoRepositorio;

        public DepoimentosController(IDepoimentoRepositorio depoimentoRepositorio)
        {
            _depoimentoRepositorio = depoimentoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Depoimento>>> BuscarTodosDepoimentos()
        {
            try
            {
                List<Depoimento> depoimentos = await _depoimentoRepositorio.BuscarTodosDepoimentos();

                return Ok(depoimentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Depoimento>> BuscarDepoimentoPorId(int id)
        {
            try
            {
                Depoimento depoimento = await _depoimentoRepositorio.BuscarDepoimentoPorId(id);

                if (depoimento == null)
                {
                    return NotFound();
                }

                return Ok(depoimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<Depoimento>> BuscarDepoimentoPorNome(string nome)
        {
            try
            {
                Depoimento depoimento = await _depoimentoRepositorio.BuscarDepoimentoPorNome(nome);

                if (depoimento == null)
                {
                    return NotFound();
                }

                return Ok(depoimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("home")]
        public async Task<ActionResult<List<Depoimento>>> TresDepoimentosAleatorios()
        {
            try
            {
                List<Depoimento> depoimentos = await _depoimentoRepositorio.TresDepoimentosAleatorios();

                if (depoimentos == null)
                {
                    return NotFound();
                }

                return Ok(depoimentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Depoimento>> CriarDepoimento(Depoimento depoimento)
        {
            try
            {
                Depoimento novoDepoimento = await _depoimentoRepositorio.CriarDepoimento(depoimento);

                return Ok(novoDepoimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Depoimento>> AtualizarDepoimento(Depoimento depoimentoAtualizado, int id)
        {
            try
            {
                Depoimento depoimento = await _depoimentoRepositorio.BuscarDepoimentoPorId(id);

                if (depoimento == null)
                {
                    return NotFound();
                }

                Depoimento depoimentoAtual = await _depoimentoRepositorio.AtualizarDepoimento(depoimentoAtualizado, id);

                return Ok(depoimentoAtual);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletarDepoimento(int id)
        {
            try
            {
                Depoimento depoimento = await _depoimentoRepositorio.BuscarDepoimentoPorId(id);

                if (depoimento == null)
                {
                    return NotFound();
                }

                bool depoimentoDeletado = await _depoimentoRepositorio.DeletarDepoimento(id);

                return Ok(depoimentoDeletado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("teste")]
        public async Task<ActionResult<string>> Teste()
        {
            try
            {
                return Ok("Teste");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
