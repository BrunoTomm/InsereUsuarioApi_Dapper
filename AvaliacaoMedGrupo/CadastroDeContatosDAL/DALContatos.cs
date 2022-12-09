using CadastroDeContatos.DAL.Interfaces;
using CadastroDeContatos.Domain.Contato;
using Dapper;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace CadastroDeContatos.DAL
{
    public class DALContatos : IDALContatos
    {
        private IDbConnection _connection;
        public DALContatos()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AvaliacaoMedGrupo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public List<string> ListarContatos()
        {
            try
            {
                _connection.Open();

                string sql = $@"SELECT NomeDoContato FROM ContatosMedGrupo WHERE Ativo = 1";

                return _connection.Query<string>(sql).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _connection.Close();
            }
        }
        public List<Contato> ListarContatosComInformacoes()
        {
            try
            {
                _connection.Open();

                string sql = $@"SELECT * FROM ContatosMedGrupo WHERE Ativo = 1";

                return _connection.Query<Contato>(sql).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                _connection.Close();
            }

        }

        public bool InserirContato(Contato contato)
        {
            _connection.Open();

            try
            {
                var culture = new CultureInfo("pt-BR", false);
                var dataDeNascimentoConvertida = DateTime.ParseExact(contato.DataDeNascimento.ToString(), "dd/MM/yyyy HH:mm:ss", culture).ToString("yyyy-MM-dd HH:mm:ss");

                string sql = $@"INSERT INTO ContatosMedGrupo(NomeDoContato, DataDeNascimento, Sexo, Idade, Ativo) 
                                            VALUES (@NomeDoContato, @DataDeNascimento, @Sexo, @Idade, @Ativo); 
                                            SELECT CAST (SCOPE_IDENTITY() AS INT);";

                var contatoQuery = new
                {
                    NomeDoContato = contato.NomeDoContato,
                    DataDeNascimento = dataDeNascimentoConvertida,
                    Sexo = contato.Sexo,
                    Idade = contato.Idade,
                    Ativo = contato.Ativo,
                };

                contato.ContatoId = _connection.Query<int>(sql, contatoQuery).Single();

                return true;

            }
            catch (Exception ex)
            {
                return false;

                throw ex;
            }
            finally { _connection.Close(); }
        }

        public bool DesativaContato(int id)
        {
            _connection.Open();

            try
            {
                string sql = $@"update ContatosMedGrupo set Ativo = 0 where ContatoId = @Id";

                _connection.Query<int>(sql, new { Id = id });

                return true;

            }
            catch (Exception ex)
            {
                return false;

                throw ex;
            }
            finally { _connection.Close(); }
        }

        public bool AtivaContato(int id)
        {
            _connection.Open();

            try
            {
                string sql = $@"update ContatosMedGrupo set Ativo = 1 where ContatoId = @Id";

                _connection.Query<int>(sql, new { Id = id });

                return true;

            }
            catch (Exception ex)
            {
                return false;

                throw ex;
            }
            finally { _connection.Close(); }
        }

        public bool DeletaContato(int id)
        {
            _connection.Open();

            try
            {
                string sql = $@"DELETE ContatosMedGrupo WHERE ContatoId = @Id";

                _connection.Query<int>(sql, new { Id = id });

                return true;

            }
            catch (Exception ex)
            {
                return false;

                throw ex;
            }
            finally { _connection.Close(); }
        }
    }
}
