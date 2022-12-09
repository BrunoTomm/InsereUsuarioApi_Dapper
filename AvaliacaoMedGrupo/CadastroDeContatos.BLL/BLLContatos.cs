using CadastroDeContatos.BLL.Interfaces;
using CadastroDeContatos.DAL.Interfaces;
using CadastroDeContatos.Domain.Contato;

namespace CadastroDeContatos.BLL
{
    public class BLLContatos : IBLLContatos
    {
        public IDALContatos Repositorio { get; set; }
        public List<Contato> ListarContatos()
        {
            return this.Repositorio.ListarContatos();
        }
    }
}
