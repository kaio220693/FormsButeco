using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBoteco.Classes
{
    internal class Funcionario
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string celular { get; set; }
        public string cep { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string cargo { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\Desktop\\AppBoteco\\AppBoteco\\DbBoteco.mdf;Integrated Security=True");

        public List<Funcionario> listaFuncionario()
        {
            List<Funcionario> li = new List<Funcionario>();
            string sql = "SELECT * FROM Funcionario";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Funcionario c = new Funcionario();
                c.Id = (int)dr["Id"];
                c.nome = dr["nome"].ToString();
                c.cpf = dr["cpf"].ToString();
                c.celular = dr["celular"].ToString();
                c.cep = dr["cep"].ToString();
                c.endereco = dr["endereco"].ToString();
                c.bairro = dr["bairro"].ToString();
                c.cidade = dr["cidade"].ToString();
                c.cargo = dr["cargo"].ToString();
                li.Add(c);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string cpf, string celular,string cep, string endereco, string bairro, string cidade, string cargo)
        {
            string sql = "INSERT INTO Funcionario(nome,cpf,celular,cep,endereco,bairro,cidade,cargo) VALUES ('" + nome + "','" + cpf + "','" + celular + "','"+cep+ "','"+endereco+"','"+bairro+"','"+cidade+"','"+cargo+"')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id, string nome, string cpf, string celular, string cep, string endereco, string bairro, string cidade, string cargo)
        {
            string sql = "UPDATE Funcionario SET nome='" + nome + "',cpf='" + cpf + "',celular='" + celular + "',cep='" + cep + "',endereco='" + endereco + "',bairro='" + bairro + "',cidade='" + cidade + "',cargo='" + cargo + "' WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Funcionario WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Funcionario WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                cpf = dr["cpf"].ToString();
                celular = dr["celular"].ToString();
                cep = dr["cep"].ToString();
                endereco = dr["endereco"].ToString();
                bairro = dr["bairro"].ToString();
                cidade = dr["cidade"].ToString();
                cargo = dr["cargo"].ToString();
            }
            dr.Close();
            con.Close();
        }

        public bool RegistroRepetido(string cpf)
        {
            string sql = "SELECT * FROM Funcionario WHERE cpf='" + cpf + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return (int)result > 0;
            }
            con.Close();
            return false;
        }
    }
}