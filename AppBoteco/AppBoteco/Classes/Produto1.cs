using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AppBoteco.Classes
{
    internal class Produto1
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string tipo { get; set; }
        public string quantidade { get; set; }
        public string preco { get; set; }

        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Aluno\\Desktop\\AppBoteco\\AppBoteco\\DbBoteco.mdf;Integrated Security=True");

        public List<Produto1> listaprodutos()
        {
            List<Produto1> li = new List<Produto1>();
            string sql = "SELECT * FROM Produto";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Produto1 c = new Produto1();
                c.Id = (int)dr["Id"];
                c.nome = dr["nome"].ToString();
                c.tipo = dr["tipo"].ToString();
                c.quantidade = dr["quantidade"].ToString();
                c.preco = dr["preco"].ToString();
                li.Add(c);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string tipo, string quantidade, string preco)
        {
            string sql = "INSERT INTO Produto(nome,tipo,quantidade,preco) VALUES ('" + nome + "','" + tipo + "','" + quantidade + "','" + preco + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Atualizar(int Id, string nome, string tipo, string quantidade, string preco)
        {
            string sql = "UPDATE Produto SET nome='" + nome + "',tipo='" + tipo + "',quantidade='" + quantidade + "',preco='"+preco+"' WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int Id)
        {
            string sql = "DELETE FROM Produto WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int Id)
        {
            string sql = "SELECT * FROM Produto WHERE Id='" + Id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                nome = dr["nome"].ToString();
                tipo = dr["tipo"].ToString();
                quantidade = dr["quantidade"].ToString();
                preco = dr["preco"].ToString() ;
            }
            dr.Close();
            con.Close();
        }
    }
}