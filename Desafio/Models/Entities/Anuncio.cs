using System.Text.Json.Serialization;

namespace Desafio.Models.Entities
{
    public class Anuncio
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Description { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
    }
}
