using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using TesteEsigSoftware.Data;
using TesteEsigSoftware.Entity;

namespace TesteEsigSoftware.Repositories
{
    public class Repository
    {

        public DataTable ListarPessoasComSalario()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand(@"
                SELECT p.nome, p.cidade, p.email, p.cep, p.endereco, p.pais, p.usuario, p.telefone, 
                       ps.salario_liquido, ps.descontos, ps.salario_bruto, c.nome as CargoNome
                FROM pessoa p
                LEFT JOIN pessoa_salario ps ON p.id = ps.pessoa_id
                JOIN cargo c ON c.id = p.cargo_id
                ORDER BY p.nome", conn);

                var adaptador = new OracleDataAdapter(cmd);
                var dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
        }

        public void CalcularSalarios()
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand("SP_CALCULAR_SALARIOS", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable BuscarPessoa(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand(@"
                SELECT p.nome, p.cidade, p.email, p.cep, p.endereco, p.pais, p.usuario, p.telefone, 
                       ps.salario_liquido, ps.descontos, ps.salario_bruto, c.nome as CargoNome
                FROM pessoa p
                LEFT JOIN pessoa_salario ps ON p.id = ps.pessoa_id
                JOIN cargo c ON c.id = p.cargo_id   
                WHERE p.id = :Id
                ORDER BY p.nome
                ", conn);

                cmd.Parameters.Add(new OracleParameter("Id", id));

                var adaptador = new OracleDataAdapter(cmd);
                var dt = new DataTable();
                adaptador.Fill(dt);
                return dt;
            }
        }
        public void CadastrarPessoa(Pessoa pessoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand(@"
                INSERT INTO pessoa 
                    (nome, cidade, email, cep, endereco, pais, usuario, telefone, data_nascimento, cargo_id, senha_hash) 
                VALUES 
                    (:nome, :cidade, :email, :cep, :endereco, :pais, :usuario, :telefone, :data_nascimento, :cargo_id, :senha_hash)
                ", conn);

                cmd.Parameters.Add(new OracleParameter("nome", pessoa.Nome));
                cmd.Parameters.Add(new OracleParameter("cidade", pessoa.Cidade));
                cmd.Parameters.Add(new OracleParameter("email", pessoa.Email));
                cmd.Parameters.Add(new OracleParameter("cep", pessoa.CEP));
                cmd.Parameters.Add(new OracleParameter("endereco", pessoa.Endereco));
                cmd.Parameters.Add(new OracleParameter("pais", pessoa.Pais));
                cmd.Parameters.Add(new OracleParameter("usuario", pessoa.Usuario));
                cmd.Parameters.Add(new OracleParameter("telefone", pessoa.Telefone));
                cmd.Parameters.Add(new OracleParameter("data_nascimento", pessoa.DataNascimento));
                cmd.Parameters.Add(new OracleParameter("cargo_id", pessoa.CargoId));

                string hash = null;
                if (!string.IsNullOrEmpty(pessoa.SenhaHash))
                {
                    hash = GerarHashMD5(pessoa.SenhaHash);
                }
                cmd.Parameters.Add(new OracleParameter("senha_hash", hash));

                cmd.ExecuteNonQuery();
            }
        }
        
        public void EditarPessoa(Pessoa pessoa)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand(@"
               UPDATE pessoa SET 
                   nome = :nome, cidade = :cidade, email = :email, cep = :cep,
                   endereco = :endereco, pais = :pais, usuario = :usuario,
                   telefone = :telefone, data_nascimento = :data_nascimento,
                   cargo_id = :cargo_id, senha_hash = :senha_hash
               WHERE id = :id
                ", conn);

                cmd.Parameters.Add(new OracleParameter("nome", pessoa.Nome));
                cmd.Parameters.Add(new OracleParameter("cidade", pessoa.Cidade));
                cmd.Parameters.Add(new OracleParameter("email", pessoa.Email));
                cmd.Parameters.Add(new OracleParameter("cep", pessoa.CEP));
                cmd.Parameters.Add(new OracleParameter("endereco", pessoa.Endereco));
                cmd.Parameters.Add(new OracleParameter("pais", pessoa.Pais));
                cmd.Parameters.Add(new OracleParameter("usuario", pessoa.Usuario));
                cmd.Parameters.Add(new OracleParameter("telefone", pessoa.Telefone));
                cmd.Parameters.Add(new OracleParameter("data_nascimento", pessoa.DataNascimento));
                cmd.Parameters.Add(new OracleParameter("cargo_id", pessoa.CargoId));

                string hash = null;
                if (!string.IsNullOrEmpty(pessoa.SenhaHash))
                {
                    hash = GerarHashMD5(pessoa.SenhaHash);
                }
                cmd.Parameters.Add(new OracleParameter("senha_hash", hash));

                cmd.Parameters.Add(new OracleParameter("id", pessoa.Id));

                cmd.ExecuteNonQuery();
            }
        }

        public void RemoverPessoa(int id)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                var cmd = new OracleCommand(@"
                BEGIN
                    DELETE FROM pessoa_salario WHERE Pessoa_id = :Id;
                    DELETE FROM pessoa WHERE id = :Id;
                END;
            ", conn);

                cmd.Parameters.Add(new OracleParameter("Id", id));

                cmd.ExecuteNonQuery();

            }
        }

        public string GerarHashMD5(string texto)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public bool ValidarUsuario(string usuario, string senha)
        {
            string hashDoBanco = null;

            using (var conn = Database.GetConnection())
            {
                string query = "SELECT senha_hash FROM pessoa WHERE usuario = :usuario";
                using (OracleCommand cmd = new OracleCommand(query, conn))
                {
                    cmd.Parameters.Add(new OracleParameter("usuario", usuario));
                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            hashDoBanco = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            } 
            if (hashDoBanco == null)
            {
                return false;
            }

            string hashDaSenhaDigitada = GerarHashMD5(senha);

            return hashDoBanco == hashDaSenhaDigitada;
        }
    }
}