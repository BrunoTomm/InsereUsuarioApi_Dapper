
using CadastroDeContatos.BLL.Interfaces;
using CadastroDeContatos.DAL;
using CadastroDeContatos.DAL.Interfaces;
using CadastroDeContatos.Domain.Contato;

namespace CadastroDeContatos.BLL
{
    public class BLLContatos : IBLLContatos
    {
        public IDALContatos Repositorio { get; set; }

        public BLLContatos()
        {
            Repositorio = new DALContatos();
        }

        public List<string> ListarContatos()
        {
            return Repositorio.ListarContatos();
        }

        public List<Contato> ListarContatosComInformacoes()
        {
            return Repositorio.ListarContatosComInformacoes();
        }

        public bool InserirContato(Contato contato)
        {
            int maiorIdade = 18;
            contato.Idade = DateTime.Now.Year - contato.DataDeNascimento.Year;

            if (contato.Idade >= maiorIdade && contato.Idade != 0 && contato.DataDeNascimento < DateTime.Now)
            {
                return Repositorio.InserirContato(contato);     
            }

            return false;
        }

        public bool DesativaContato(int id)
        {
            return Repositorio.DesativaContato(id);
        }

        public bool AtivaContato(int id)
        {
            return Repositorio.AtivaContato(id);
        }

        public bool DeletaContato(int id)
        {
            return Repositorio.DeletaContato(id);
        }
    }
}
