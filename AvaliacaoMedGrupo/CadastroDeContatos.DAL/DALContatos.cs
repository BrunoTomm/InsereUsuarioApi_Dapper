using CadastroDeContatos.DAL.Interfaces;
using CadastroDeContatos.Domain.Contato;

namespace CadastroDeContatos.DAL
{
    public class DALContatos : IDALContatos
    {
        public List<Contato> ListarContatos()
        {
            return new List<Contato>();
        }
    }
}
