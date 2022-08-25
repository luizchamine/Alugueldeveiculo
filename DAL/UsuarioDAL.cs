using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioDAL
    {
        public DataTable BuscarUsuarioPorNome(string _nome)//buscar nome utilizando um parametro string chamado nome
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Conexao.StringDeConexao;
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.Connection = cn;
                da.SelectCommand.CommandText = "sp_buscarusuariopornome";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter pnome = new SqlParameter("@Nome",SqlDbType.VarChar);
                pnome.Value = _nome;

                da.SelectCommand.Parameters.Add(pnome);

                cn.Open();//abrir coneccao
                da.Fill(dt);//buscar para preencher o datatable

                //SqlCommand cmd = new SqlCommand();

                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Sql Erro: "+ex.Message);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
