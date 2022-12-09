using CadastroDeContatos.Domain.Contato;

namespace CadastroDeContatos.BLL.Interfaces
{
    public interface IBLLContatos
    {
        List<string> ListarContatos();
        List<Contato> ListarContatosComInformacoes();
        bool InserirContato(Contato contato);
        bool DesativaContato(int id);
        bool AtivaContato(int id);
        public bool DeletaContato(int id);
    }
}
