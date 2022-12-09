using CadastroDeContatos.Domain.Contato;

namespace CadastroDeContatos.DAL.Interfaces
{
    public interface IDALContatos
    {
        public List<Contato> ListarContatos();
    }
}
