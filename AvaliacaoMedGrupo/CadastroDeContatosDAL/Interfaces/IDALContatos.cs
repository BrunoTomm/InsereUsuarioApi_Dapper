using CadastroDeContatos.Domain.Contato;

namespace CadastroDeContatos.DAL.Interfaces
{
    public interface IDALContatos
    {
        List<string> ListarContatos();
        bool InserirContato(Contato contato);
        public List<Contato> ListarContatosComInformacoes();
        bool DesativaContato(int id);
        bool AtivaContato(int id);
        bool DeletaContato(int id);
    }
}
