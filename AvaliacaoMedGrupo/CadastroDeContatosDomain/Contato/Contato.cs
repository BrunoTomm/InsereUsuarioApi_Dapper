namespace CadastroDeContatos.Domain.Contato
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string NomeDoContato { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public bool Ativo { get; set; }
    }
}
