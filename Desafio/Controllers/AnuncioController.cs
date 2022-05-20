using Desafio.Models.Entities;
using Desafio.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AnuncioController : ControllerBase
    {
        private readonly IAnuncioRepository _repository;
        public AnuncioController(IAnuncioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var anuncios = await _repository.GetAnunciosAsync();
            return anuncios.Any()
                ? Ok(anuncios)
                : BadRequest("Sem anuncios");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var anuncio = await _repository.GetByIdAsync(id);
            return anuncio != null
                ? Ok(anuncio)
                : BadRequest("Anuncio não encontrado");
        }

        [HttpPost]
        public async Task<IActionResult> Post(string CEP, string Titulo, string Description, string Complemento, string Numero)
        {

            HttpClient client = new HttpClient();

            if (CEP != null)
            {

                var response = await client.GetAsync($"https://viacep.com.br/ws/{CEP}/json/");
                var getresult = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<Anuncio>(getresult);

                if (result != null)
                {
                    var anuncioCriado = new Anuncio();

                    anuncioCriado.Titulo = Titulo;
                    anuncioCriado.Description = Description;
                    anuncioCriado.Logradouro = result.Logradouro;
                    anuncioCriado.Bairro = result.Bairro;
                    anuncioCriado.Localidade = result.Localidade;
                    anuncioCriado.UF = result.UF;
                    anuncioCriado.Complemento = Complemento;
                    anuncioCriado.Numero = Numero;
                    anuncioCriado.CEP = CEP;

                    _repository.Add(anuncioCriado);

                    return await _repository.SaveChangesAsync()
                        ? Ok("Anuncio adicionado com sucesso")
                        : BadRequest("Erro ao adicionar anuncio");
                }
                else
                {
                    return BadRequest("CEP Inválido");
                }
            }
            return BadRequest("Digite um CEP");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, Anuncio model)
        {
            var anuncio = await _repository.PutAsync(id);

            if (anuncio == null)
                return NotFound();

            anuncio.Titulo = model.Titulo;
            anuncio.Description = model.Description;
            anuncio.Logradouro = model.Logradouro;
            anuncio.Bairro = model.Bairro;
            anuncio.Localidade = model.Localidade;
            anuncio.UF = model.UF;
            anuncio.Complemento = model.Complemento;
            anuncio.Numero = model.Numero;
            anuncio.CEP = model.CEP;

            _repository.Update(anuncio);

            return await _repository.SaveChangesAsync()
                ? Ok("Anuncio atualizado com sucesso")
                : BadRequest("Erro ao atualizar anuncio");
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var anuncio = await _repository.DeleteAsync(id);

            _repository.Delete(anuncio);

            return await _repository.SaveChangesAsync()
                ? Ok("Anuncio excluido com sucesso")
                : BadRequest("Erro ao excluir anuncio");
        }
        
    }
}
